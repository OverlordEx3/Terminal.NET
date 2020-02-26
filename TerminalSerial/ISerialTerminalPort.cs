using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.ComponentModel;

namespace SerialTerminal
{
    public class SerialTerminalReceivedData
    {
        public readonly byte[] Buffer;
        public readonly int Received;

        public SerialTerminalReceivedData(byte[] data, int quantity)
        {
            Buffer = data;
            Received = quantity;
        }
    }

    public interface ISerialTerminalPort: INotifyPropertyChanged
    {
        int Received { get; set; }
        int Sent { get; set; }
        bool IsOpen { get; }

        /* Configuration */
        string Name { get; set; }
        int Baudrate { get; set; }
        int DataBits { get; set; }
        Parity Parity { get; set; }
        Handshake Handshake { get; set; }
        StopBits StopBits { get; set; }

        /* Events */
        event EventHandler<SerialTerminalReceivedData> OnDataReceived;
        event EventHandler<SerialError> OnErrorReceived;

        /* Port controlling functions */
        void Open();
        void Close();
        void BeginRead();
        void EndRead();

        /* Send methods */
        void Write(byte[] buffer, int offset, int count);
        void Write(string str);

        /* Receive non interrupted */
        int Read(byte[] buffer, int offset, int count);
        int ReadByte();
    }
}
