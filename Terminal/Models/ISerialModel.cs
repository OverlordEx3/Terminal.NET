using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Terminal.Models
{
    enum Encoding
    {
        ASCII,
        Hex,
    }

    public class RequestResponse
    {
        public string Request  { get; }
        public string Response { get; }

        RequestResponse(string request, string response)
        {
            Request = request;
            Response = response;
        }
    }

    public interface ISerialModel
    {
        /* Methods */
        void ClearSent();
        void ClearReceived();
        void SetMacro(int index, string Macro);
        string GetMacro(int index);
        bool StartLog(string filePath);
        void SetRequestResponse(int index, string request, string response);

        bool SendFile(string filePath);
        void SendKey(char key);
        void SendString(string str);

        void Connect();
        void Disconnect();
    }

    public class SerialModel : ISerialModel, INotifyPropertyChanged
    {
        bool AutoDisConnect;
        bool ShowTime;
        bool CRAsLF;

        bool EnableCTS;
        bool EnableDSR;
        bool EnableCD;
        bool EnableRI;

        bool SetRTS;
        bool SetDTR;

        /* Receive options */
        Encoding ReceiveEncoding;

        /* Transmit options */
        bool AppendLineFeed;
        bool EnableEcho;

        List<string> UserMacros;

        /* Log parameters */
        string LogFilePath;
        bool StreamLog;

        List<RequestResponse> RequestResponseCommands;

        SerialPort port;

        /* Transaction quantities */
        private int sentQty = 0;
        public int Sent {
            get => sentQty;
            private set
            {
                if(value == sentQty)
                {
                    return;
                }
                sentQty = value;
                OnNotifyPropertyChanged();
            }
        }
        private int receivedQty = 0;
        public int Received {
            get => receivedQty;
            private set
            {
                if(value == receivedQty)
                {
                    return;
                }

                receivedQty = value;
                OnNotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public void ClearReceived()
        {
            Received = 0;
        }

        public void ClearSent()
        {
            Sent = 0;
        }

        public void Connect()
        {
            port.Open();
        }

        public void Disconnect()
        {
            port.Close();
        }

        public string GetMacro(int index)
        {
            if(UserMacros.Count > index)
            {
                throw new IndexOutOfRangeException("Macro index out of range");
            }
            return UserMacros.ElementAt(index);
        }

        public bool SendFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void SendKey(char key)
        {
            if(port.IsOpen == false)
            {
                throw new InvalidOperationException("Comm port is closed");
            }
            port.Write(new byte[] { (byte)key }, 0, 1);
        }

        public void SendString(string str)
        {
            if (port.IsOpen == false)
            {
                throw new InvalidOperationException("Comm port is closed");
            }
            port.Write(str);
        }

        public void SetMacro(int index, string Macro)
        {
            UserMacros.Insert(index, Macro);
        }

        public void SetRequestResponse(int index, string request, string response)
        {
            throw new NotImplementedException();
        }

        public bool StartLog(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
