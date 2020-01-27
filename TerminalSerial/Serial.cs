using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace TerminalSerial
{
    public class Serial : SerialPort
    {
        public int Received { get; set; } = 0;
        public int Sent { get; set; } = 0;

        public TerminalSerialOnDataReceivedDelegate ReceivedDelegate;

        private CancellationTokenSource cts = null;
        private TerminalSerialThread TerminalSerialRead = null;
        private Thread ReceiveTask;

        /* Ctor */
        public Serial(string portName, int baudrate, Parity parity, int databits, StopBits stopbits)
        {
            PortName = portName;
            BaudRate = baudrate;
            Parity = parity;
            DataBits = databits;
            StopBits = stopbits;

            /* Handshake default */
            Handshake = Handshake.None;

            /* Misc options */
            DtrEnable = true;
            NewLine = Environment.NewLine;
            ReceivedBytesThreshold = 64;
        }

        public Serial()
        {
            PortName = "COM1";
            BaudRate = 600;
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.One;

            /* Handshake default */
            Handshake = Handshake.None;

            /* Misc options */
            DtrEnable = true;
            NewLine = Environment.NewLine;
            ReceivedBytesThreshold = 64;
        }

        new public void Open()
        {
            cts = new CancellationTokenSource();
            if(TerminalSerialRead == null)
            {
                TerminalSerialRead = new TerminalSerialThread(this, ReceivedDelegate);
            }
            
            ReceiveTask = new Thread(new ParameterizedThreadStart(TerminalSerialRead.TerminalSerialReadThead));

            base.Open();
            ReceiveTask.Start(cts.Token);
        }

        new public void Close()
        {
            cts.Cancel();
            ReceiveTask.Join();

            ReceiveTask = null;
            cts = null;

            base.Close();
        }

        new public void Write(byte[] buff, int offset, int count)
        {
            base.Write(buff, offset, count);
            Sent += count;
        }

        public async Task WriteAsync(byte[] buffer, int offset, int count)
        {
            await base.BaseStream.WriteAsync(buffer, offset, count);
            Sent += count;
        }

        public async Task<int> ReadAsync(byte[] buffer, int offset, int count)
        {
            int recv = await BaseStream.ReadAsync(buffer, offset, count);
            Received += recv;
            return recv;
        }

        public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellation)
        {
            int recv = 0;
            using (cancellation.Register(() => BaseStream.Close()))
            {
                try
                {
                    recv = await BaseStream.ReadAsync(buffer, offset, count);
                    Received += recv;
                } catch(TimeoutException timeout)
                {
                    recv = -1;
                } catch(Exception ex)
                {

                }
            }

            return recv;
        }
    }

    public class TerminalSerialDataEventArgs : EventArgs
    {
        public int BytesRead;
        public byte[] DataRead;
    }

    public delegate void TerminalSerialOnDataReceivedDelegate(TerminalSerialDataEventArgs serialDataEventArgs);

    public class TerminalSerialThread
    {
        TerminalSerialOnDataReceivedDelegate DataReceivedDelegate = null;
        Serial port;

        public TerminalSerialThread(Serial port, TerminalSerialOnDataReceivedDelegate dataReceivedDelegate)
        {
            this.port = port;
            DataReceivedDelegate = dataReceivedDelegate;
        }

        public async void TerminalSerialReadThead(object arg)
        {
            CancellationToken cancellationToken = (CancellationToken)arg;
            byte[] rcvBuf = new byte[4096];

            while(cancellationToken.IsCancellationRequested == false)
            {
                int read = await port.ReadAsync(rcvBuf, 0, rcvBuf.Length, cancellationToken);
                if(read > 0)
                {
                    if(DataReceivedDelegate != null)
                    {
                        DataReceivedDelegate(new TerminalSerialDataEventArgs { BytesRead = read, DataRead = rcvBuf }) ; 
                    }
                }
            }
        }

    }
}
