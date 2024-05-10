using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows;

using Werewolf.Game;
using Werewolf.Network.Events;
using Werewolf.Network.Packets;

namespace Werewolf.Network
{
    public enum ClientRoomServerEvent
    {
        ROOM_USER_LIST_SET = 0,
        ROOM_USER_MESSAGE_SENT = 1,
        ROOM_USER_JOINED = 2,
        ROOM_USER_LEFT = 3
    }

    public class Client
    {
        #region Singleton
        private static Client instance = null;
        public static Client Instance
        {
            get
            {
                if (instance == null)
                    instance = new Client();
                return instance;
            }
        }
        #endregion Singleton

        private Socket Socket_Client;
        private PacketManager PManager_Packets;
        private bool is_Closing;

        public string Name { get; private set; }
        public bool IsHost => Server.Instance.Started;
        public string IPAddressString { get; private set; }
        public EventManager<ServerToClientEventArgs> ServerEvents { get; private set; }
        public Role Role { get; set; }

        private Client()
        {
            Reset();
        }

        private void Reset()
        {
            Socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            PManager_Packets = null;

            Name = string.Empty;
            IPAddressString = "<Not connected>";
            ServerEvents = new EventManager<ServerToClientEventArgs>();
            Role = null;
        }

        public bool Connect(string name, IPAddress ipAddress)
        {
            if (Socket_Client.Connected) return true;

            Socket_Client.Connect(ipAddress, Server.DEFAULT_PORT);
            PManager_Packets = new PacketManager(new NetworkStream(Socket_Client));

            PManager_Packets.Send(new Packet<string>(name));
            Packet<bool> packetIsNameTaken = PManager_Packets.Expect<Packet<bool>>();

            Name = name;
            IPAddressString = ipAddress.ToString();

            return !packetIsNameTaken.Data1;
        }

        public void ListenServerEvents()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        ServerEvents.RaiseEvent(ExpectEvent());
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
                    if (!is_Closing)
                    {
                        MessageBox.ShowError("Đã xảy ra lỗi: máy chủ không thể truy cập được nữa.", "Lỗi - Máy chủ không thể truy cập được", MessageBoxButton.OK, MessageBoxImage.Error);
                        Disconnect();
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ((MainWindow)Application.Current.MainWindow).SetView<MainView>();
                        });
                    }
                }
            });
        }

        public void SendEvent<TEventArgs>(TEventArgs args) where TEventArgs : ClientToServerEventArgs
        {
            PManager_Packets.Send(new PacketEvent(args));
        }

        public dynamic ExpectEvent()
        {
            return PManager_Packets.Expect<PacketEvent>().EventArgs;
        }

        public void Disconnect(bool isClosing = false)
        {
            is_Closing = isClosing;
            if (PManager_Packets != null)
                PManager_Packets.Close();

            if (Socket_Client.Connected)
            {
                try
                {
                    Socket_Client.Shutdown(SocketShutdown.Both);
                }
                catch { }
                finally
                {
                    Socket_Client.Close();
                }
            }

            if (!isClosing)
                Reset();
        }
    }
}