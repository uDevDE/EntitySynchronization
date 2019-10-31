
namespace EntitySynchronizationPacket
{
    public class EntitySynchronizationPacket
    {
        public static readonly int HeaderSize = 20;
        public static readonly int DataSizeOffset = 0;
        public static readonly int AdditionalDataSizeOffset = 16;
        public static readonly int MaxAdditionalDataSize = 256;
    }
}
