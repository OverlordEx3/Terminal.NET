using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerialTerminal
{
    public class SerialTerminalPort : ISerialTerminalPort
    {
        private int received = 0;
        public int Received
        {
            get => received;
            set
            {
                if (received == value)
                {
                    return;
                }

                received = value;
                OnPropertyChanged();
            }
        }
        private int sent;
        public int Sent {
            get => sent;
            set 
            { 
                if(sent == value)
                {
                    return;
                }

                sent = value;
                OnPropertyChanged();
            } 
        }

        public bool IsOpen => Port.IsOpen;

        public string Name { get => Port.PortName; set => Port.PortName = value; }
        public int Baudrate { get => Port.BaudRate; set => Port.BaudRate = value; }
        public int DataBits { get => Port.DataBits; set => Port.DataBits = value; }
        public Parity Parity { get => Port.Parity; set => Port.Parity = value; }
        public Handshake Handshake { get => Port.Handshake; set => Port.Handshake = value; }
        public StopBits StopBits { get => Port.StopBits; set => Port.StopBits = value; }

        public event EventHandler<SerialTerminalReceivedData> OnDataReceived;
        public event EventHandler<SerialError> OnErrorReceived;
        public event PropertyChangedEventHandler PropertyChanged;

        // Token to delete a writing task
        private CancellationTokenSource CancellationTokenSource;
        // Thread to receive data from serial port. It keeps listening and post data to it's
        // Data received delegate
        private Thread ReceiveThread;

        // The actual receive thread instance:
        private TerminalSerialReceiveThread SerialReceiveTask;

        private readonly SerialPort Port;

        private bool IsReading = false;

        public SerialTerminalPort()
        {
            this.Port = new SerialPort();
            Port.ErrorReceived += (sender, e) => OnErrorReceived?.Invoke(this, e.EventType);
        }

        public void BeginRead()
        {
            CancellationTokenSource = new CancellationTokenSource();
            if (SerialReceiveTask == null)
            {
                SerialReceiveTask = new TerminalSerialReceiveThread(this.Port, OnDataReceived);
            }

            ReceiveThread = new Thread(new ParameterizedThreadStart(SerialReceiveTask.ReadTask));

            ReceiveThread.Start(CancellationTokenSource.Token);
            IsReading = true;
        }

        public void Close()
        {
            Port.Close();
        }

        public void EndRead()
        {
            if (IsReading == false)
            {
                return;
            }
            // Send cancel signal to listen thread 
            CancellationTokenSource.Cancel();
            // Wait for thread to join
            ReceiveThread.Join();

            // Release resources
            ReceiveThread = null;
            CancellationTokenSource.Dispose();
            CancellationTokenSource = null;
            IsReading = false;
        }

        public void Open()
        {
            Port.Open();
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            if(IsReading == true)
            {
                throw new InvalidOperationException("Read disabled");
            }

            return Port.Read(buffer, offset, count);
        }

        public int ReadByte()
        {
            if (IsReading == true)
            {
                throw new InvalidOperationException("Read disabled");
            }

            return Port.ReadByte();
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            Port.Write(buffer, offset, count);
        }

        public void Write(string str)
        {
            Port.Write(str);
        }

        private void OnPropertyChanged([CallerMemberName]string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
