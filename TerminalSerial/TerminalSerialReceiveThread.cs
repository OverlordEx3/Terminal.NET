using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SerialTerminal
{
    internal class TerminalSerialReceiveThread
    {
        private readonly SerialPort port;

        public event EventHandler<SerialTerminalReceivedData> DataReceived;

        public TerminalSerialReceiveThread(SerialPort port, EventHandler<SerialTerminalReceivedData> dataReceivedDelegate)
        {
            this.port = port;
            DataReceived = dataReceivedDelegate;
        }

        public TerminalSerialReceiveThread(SerialPort port)
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
                    DataReceived?.Invoke(this.port, new SerialTerminalReceivedData(rcvBuf, read));
                    /* Give time to process */
                    Thread.Sleep(50);
                }
            }
        }
    }
}
