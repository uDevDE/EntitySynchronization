

namespace EntitySynchronizationPacket.Interfaces
{
    public interface IPacketHeader
    {
        int DataSize { get; }
        int Command { get; }
        int CommandType { get; }
        byte[] AdditionalData{ get; }
        int AdditionalDataSize { get; }
        int TotalSize { get; }
    }
}
