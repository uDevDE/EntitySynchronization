using System;

namespace EntitySynchronizationPacket.Core
{
    public class SenderPacket : Interfaces.IPacket, IDisposable
    {
        private bool isDisposed;

        public PacketHeader Header { get; private set; }
        public byte[] Data { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
                return;

            if (disposing)
            {
                Data = null;
                Header?.Dispose();
                Header = null;
            }

            isDisposed = true;
        }

        ~SenderPacket()
        {
            Dispose(false);
        }

    }
}
