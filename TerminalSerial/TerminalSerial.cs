using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using PropertyChanged;

namespace TerminalSerial
{
    [AddINotifyPropertyChangedInterface]
    public class Serial : SerialPort
    {
        public int Received { get; set; } = 0;
        public int Sent { get; set; } = 0;

        // Token to delete a writing task
        private CancellationTokenSource cancellationTokenSource;
        // Thread to receive data from serial port. It keeps listening and post data to it's
        // Data received delegate
        private Thread ReceiveThread;

        // The actual receive thread instance:
        private TerminalSerialReceiveThread SerialReceiveTask;

        public TerminalSerialOnDataReceivedHandler OnDataReceived;

        private bool IsReading = false;

        new public void Close()
        {
            EndRead();
            base.Close();
        }

        public void BeginRead()
        {
            cancellationTokenSource = new CancellationTokenSource();
            if (SerialReceiveTask == null)
            {
                SerialReceiveTask = new TerminalSerialReceiveThread(this, OnDataReceived);
            }

            ReceiveThread = new Thread(new ParameterizedThreadStart(SerialReceiveTask.ReadTask));

            ReceiveThread.Start(cancellationTokenSource.Token);
            IsReading = true;
        }

        public void EndRead()
        {
            if(IsReading == false)
            {
                return;
            }
            // Send cancel signal to listen thread 
            cancellationTokenSource.Cancel();
            // Wait for thread to join
            ReceiveThread.Join();

            // Release resources
            ReceiveThread = null;
            cancellationTokenSource = null;
            IsReading = false;
        }

        public new void Dispose()
        {
            cancellationTokenSource?.Cancel();
            ReceiveThread?.Join();
            ReceiveThread = null;
            cancellationTokenSource = null;
            if (base.IsOpen)
            {
                base.Close();
            }
        }

        /* Write methods */
        public new void Write(byte[] buffer, int offset, int count)
        {
            try
            {
                base.Write(buffer, offset, count);
                Sent += count;
            } catch (Exception)
            {
                throw;
            }
        }

        public new void Write(char[] buffer, int offset, int count)
        {
            try
            {
                base.Write(buffer, offset, count);
                Sent += count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public new void Write(string str)
        {
            try
            {
                base.Write(str);
                Sent += str.Length;
            } catch (Exception)
            {
                throw;
            }
        }

        public new void WriteLine(string str)
        {
            try
            {
                base.WriteLine(str);
                Sent += (str.Length + base.NewLine.Length);
            } catch (Exception)
            {
                throw;
            }
        }

        /* Read methods */
        public new int Read(byte[] buffer, int offset, int count)
        {
            try
            {
                int read = base.Read(buffer, offset, count);
                Received += read;
                return read;
            } catch (Exception)
            {
                throw;
            }
        }

        public new int Read(char[] buffer, int offset, int count)
        {
            try
            {
                int read = base.Read(buffer, offset, count);
                Received += read;
                return read;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public new int ReadByte()
        {
            try
            {
                int readByte = base.ReadByte();
                if (readByte != -1)
                {
                    Received += 1;
                }
                return readByte;
            } catch (Exception)
            {
                throw;
            }
        }

        public new int ReadChar()
        {
            try
            {
                int readChar = base.ReadChar();
                Received += 1;
                return readChar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public new string ReadExisting()
        {
            try
            {
                string existingData = base.ReadExisting();
                Received += existingData.Length;
                return existingData;
            } catch (Exception)
            {
                throw;
            }
        }

        public new string ReadLine()
        {
            try
            {
                string line = base.ReadLine();
                Received += line.Length;
                return line;
            } catch (Exception)
            {
                throw;
            }
        }

        public new string ReadTo(string value)
        {
            try
            {
                string read = base.ReadTo(value);
                Received += read.Length;
                return read;
            } catch (Exception)
            {
                throw;
            }
        }

        private readonly Dictionary<SerialError, string> SerialErrorStrings = new Dictionary<SerialError, string>()
            {
            {SerialError.RXOver, "Receive overrun" },
            {SerialError.Overrun, "Buffer overrun" },
            {SerialError.RXParity, "Parity error" },
            {SerialError.Frame, "Frame error" },
            {SerialError.TXFull, "Transmission buffer full" },
            };

        public delegate void TerminalSerialOnDataReceivedHandler(TerminalSerialDataEventArgs serialDataEventArgs);
        public delegate void TerminalSerialOnErrorReceivedHandler(TerminalSerialErrorEventArgs serialErrorEventArgs);

        public TerminalSerialOnErrorReceivedHandler OnError;

        /* Event handlers */
        private void OnSerialErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            OnError?.Invoke(new TerminalSerialErrorEventArgs { Error = e.EventType, ErrorString = SerialErrorStrings[e.EventType] });
        }

        public void WriteByte(byte data)
        {
            byte[] buf = new byte[2];
            buf[0] = data;
            Write(buf, 0, 1);
        }
    }

    public class TerminalSerialDataEventArgs : EventArgs
    {
        public int BytesRead;
        public byte[] DataRead;
    }

    public class TerminalSerialErrorEventArgs : EventArgs
    {
        public SerialError Error;
        public string ErrorString;
    }
}
