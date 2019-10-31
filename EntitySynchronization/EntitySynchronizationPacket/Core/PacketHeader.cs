using System;

namespace EntitySynchronizationPacket
{
    public class PacketHeader : Interfaces.IPacketHeader, IDisposable
    {
        private bool isDisposed;

        public int DataSize { get; private set; }
        public int Command { get; private set; }
        public int CommandType { get; private set; }
        public byte[] AdditionalData { get; private set; }
        public int AdditionalDataSize { get; private set; }
        public int TotalSize => DataSize + AdditionalDataSize;

        private PacketHeader() { }

        public PacketHeader(int dataSize, int command, int commandType, byte[] additionalData = null)
        {          
            Command = command;
            CommandType = commandType;

            if (additionalData != null)
            {
                var len = additionalData.Length;
                if (len > EntitySynchronizationPacket.MaxAdditionalDataSize)
                    throw new ArgumentException(string.Format("The size exceeds the maximum limit of {0:d}", EntitySynchronizationPacket.MaxAdditionalDataSize), "additionalData");

                AdditionalDataSize = len;
            }

            var datalen = int.MaxValue - (dataSize + AdditionalDataSize);
            if (datalen < 0)
                throw new ArgumentException(string.Format("The size exceeds the maximum limit of {0:d}", Math.Abs(datalen)), "dataSize");

            DataSize = dataSize;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing && AdditionalData != null)
                AdditionalData = null;

            isDisposed = true;
        }

        ~PacketHeader()
        {
            Dispose(false);
        }

    }
}
