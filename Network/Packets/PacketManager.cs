using System.IO;

namespace Werewolf.Network.Packets
{
    public class PacketManager
    {
        private readonly Stream pri_Stream;

        public PacketManager(Stream stream)
        {
            pri_Stream = stream;
        }

        public void Send(Packet packet)
        {
            packet.Send(pri_Stream);
        }

        public TPacket Expect<TPacket>() where TPacket : Packet
        {
            return Packet.Receive<TPacket>(pri_Stream);
        }

        public void Close()
        {
            pri_Stream.Close();
        }
    }
}
