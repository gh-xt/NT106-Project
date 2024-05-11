using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Werewolf.Network.Events;
using Werewolf.Network.Exceptions;
using Werewolf.Utils;

namespace Werewolf.Network
{
    public class Server
    {
        #region Singleton
        private static Server instance = null;
        public static Server Instance
        {
            get
            {
                if (instance == null)
                    instance = new Server();
                return instance;
            }
        }
        #endregion Singleton

        public const int DEFAULT_PORT = 8888;

        private readonly Socket Socket_Server;
        private readonly List<User> List_Users;
        private readonly EventManager<ClientToServerEventArgs> User_Events;

        public bool Started { get; private set; }
        public EventManager<ServerEventArgs> ServerEvents { get; }

        private Server()
        {
            Socket_Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            List_Users = new List<User>();
            User_Events = new EventManager<ClientToServerEventArgs>();
            ServerEvents = new EventManager<ServerEventArgs>();

            User_Events.Add_Listener<SendChatMessageEventArgs>((sender, e) =>
            {
                SendEvent(new ChatMessageSentEventArgs(((User)sender).Name, e.Message));
            });

            ServerEvents.Add_Listener<ServerUserConnectedEventArgs>((sender, e) =>
            {
                SendEvent(new UserJoinedEventArgs(e.User.Name));
                List_Users.Add(e.User);
                ListenUserEvents(e.User);
                e.User.SendEvent(new ChatMessageSentEventArgs(string.Empty, $"Chào mừng đến trò chơi, {e.User.Name}!"));
                e.User.SendEvent(new UserListSetEventArgs(List_Users.Select((u) => u.Name).ToArray()));
                Game.Game.Instance.Add_Player(e.User);
            });

            ServerEvents.Add_Listener<ServerUserDisconnectedEventArgs>((sender, e) =>
            {
                List_Users.Remove(e.User);
                SendEvent(new UserLeftEventArgs(e.User.Name));
                Game.Game.Instance.Del_Players(e.User);
            });
        }
        private string GetIPAddress()
        {
            string IPAddress = string.Empty;
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }
        public void Start(int port = DEFAULT_PORT)
        {
            string ip = GetIPAddress();
            if (Socket_Server.Connected) return;
            Started = true;

            Socket_Server.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
            Socket_Server.Listen(10);
            ListenConnexions();
        }

        private void ListenConnexions()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        User user = null;

                        try
                        {
                            user = new User(Socket_Server.Accept(), List_Users.ToArray());
                            ServerEvents.Raise_Event(this, new ServerUserConnectedEventArgs((user)));
                        }
                        catch (NameAlreadyTakenException)
                        {
                            user.Disconnect();
                        }
                    }
                }
                catch (Exception e) when (
                    e is SocketException ||
                    e is ObjectDisposedException)
                {
                    MessageBox.ShowException(e);
                }
            });
        }

        private void ListenUserEvents(User user)
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        User_Events.Raise_Event(user, user.ExpectEvent());
                    }
                }
                catch (Exception e) when (
                    e is SerializationException ||
                    e is EndOfStreamException ||
                    e is ObjectDisposedException ||
                    e is IOException)
                {
                    MessageBox.ShowException(e);
                }
                finally
                {
                    if (!user.IsHost)
                        ServerEvents.Raise_Event(new ServerUserDisconnectedEventArgs((user)));
                }

            });
        }

        public void SendEvent<TEventArgs>(TEventArgs args) where TEventArgs : ServerToClientEventArgs
        {
            foreach (User user in List_Users)
                user.SendEvent(args);
        }

        public void Stop(bool isClosing = false)
        {
            foreach (User user in List_Users)
                user.Disconnect();
            List_Users.Clear();

            if (!Socket_Server.Connected) return;

            Socket_Server.Disconnect(!isClosing);
        }
    }
}