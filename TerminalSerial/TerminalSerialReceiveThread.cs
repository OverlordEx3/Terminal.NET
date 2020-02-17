using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static TerminalSerial.Serial;

namespace TerminalSerial
{
    internal class TerminalSerialReceiveThread
    {
        private readonly Serial port;

        public TerminalSerialOnDataReceivedHandler DataReceived { get; set; } = null;

        public TerminalSerialReceiveThread(Serial port, TerminalSerialOnDataReceivedHandler dataReceivedDelegate)
        {
            this.port = port;
            DataReceived = dataReceivedDelegate;
        }

        public TerminalSerialReceiveThread(Serial port)
        {
            this.port = port;
        }

        public void ReadTask(object arg)
        {
            CancellationToken cancellationToken = (CancellationToken)arg;
            byte[] rcvBuf = new byte[4096];

            while (cancellationToken.IsCancellationRequested == false)
            {
                int read = port.Read(rcvBuf, 0, rcvBuf.Length);
                if (read > 0)
                {
                    DataReceived?.Invoke(new TerminalSerialDataEventArgs { BytesRead = read, DataRead = rcvBuf });
                    /* Give time to process */
                    Thread.Sleep(50);
                }
            }
        }
    }
}
