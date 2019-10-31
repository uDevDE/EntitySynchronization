
namespace EntitySynchronizationPacket.Interfaces
{
    public interface IPacket
    {
        PacketHeader Header { get; }
        byte[] Data { get; }
    }
}
