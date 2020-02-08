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
    class TerminalSerial : SerialPort
    {
        public int Received { get; set; } = 0;
        public int Sent { get; set; } = 0;

        ///Token to delete a writing task
        private CancellationTokenSource cancellationTokenSource;
        // Thread to receive data from serial port. It keeps listening and post data to it's
        // Data received delegate
        private Thread ReceiveThread;

        // The actual receive thread instance:


        /* Overrided methods */
        new public void Open()
        {
            cancellationTokenSource = new CancellationTokenSource();
            if (TerminalSerialRead == null)
            {
                TerminalSerialRead = new TerminalSerialThread(this, ReceivedDelegate);
            }

            ReceiveThread = new Thread(new ParameterizedThreadStart(TerminalSerialRead.TerminalSerialReadThead));

            base.Open();
            ReceiveThread.Start(cancellationTokenSource.Token);
        }

        new public void Close()
        {
            // Send cancel signal to listen thread 
            cancellationTokenSource.Cancel();
            // Wait for thread to join
            ReceiveThread.Join();

            // Release resources
            ReceiveThread = null;
            cancellationTokenSource = null;

            base.Close();
        }

        public new void Dispose()
        {
            cancellationTokenSource?.Cancel();
            ReceiveThread?.Join();
            ReceiveThread = null;
            cancellationTokenSource = null;
            if(base.IsOpen)
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
            } catch(Exception)
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
            } catch(Exception)
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
            } catch(Exception)
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
            } catch(Exception)
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
    }
}
