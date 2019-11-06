
namespace EntitySynchronization.Packet
{
    public class EntitySynchronizationPacket
    {
        public static readonly int HeaderSize = 20;
        public static readonly int DataSizeOffset = 0;
        public static readonly int AdditionalDataSizeOffset = 16;
        public static readonly int MaxAdditionalDataSize = 256;

        public static byte[] Int32ToLittleEndian(int data)
        {
            byte[] result = new byte[4];
            result[0] = (byte)data;
            result[1] = (byte)(((uint)data >> 8) & 0xFF);
            result[2] = (byte)(((uint)data >> 16) & 0xFF);
            result[3] = (byte)(((uint)data >> 24) & 0xFF);
            return result;
        }
    }
}
