using System;
using System.Linq;
using System.Net.Sockets;

using Werewolf.Network.Exceptions;
using Werewolf.Network.Packets;

namespace Werewolf.Network
{
    public class User : IEquatable<User>
    {
        private readonly Socket Socket_Client;
        private readonly PacketManager PManager_Packets;

        public string Name { get; set; }
        public bool IsHost { get; }

        public User(Socket client, User[] users)
        {
            Socket_Client = client;
            PManager_Packets = new PacketManager(new NetworkStream(Socket_Client));

            Packet<string> packetName = PManager_Packets.Expect<Packet<string>>();

            Name = packetName.Data1;
            IsHost = users.Length == 0;
            bool isNameTaken = users.Any((user) => Equals(user));

            PManager_Packets.Send(new Packet<bool>(isNameTaken));

            if (isNameTaken)
                throw new NameAlreadyTakenException(Name);
        }

        public void SendEvent<TEventArgs>(TEventArgs args) where TEventArgs : EventArgs
        {
            PManager_Packets.Send(new PacketEvent(args));
        }

        public dynamic ExpectEvent()
        {
            return PManager_Packets.Expect<PacketEvent>().EventArgs;
        }

        public void Disconnect()
        {
            PManager_Packets.Close();
            Socket_Client.Disconnect(false);
        }

        public bool Equals(User other) => Name.Equals(other.Name);
    }
}