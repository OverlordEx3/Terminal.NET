using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Models
{
    public class SerialModel : ISerialModel, INotifyPropertyChanged
    {
        private List<string> UserMacros;
        private List<RequestResponse> RequestResponseCommands;

        /* Transaction quantities */
        private int sentQty = 0;
        private int receivedQty = 0;

        public bool AutoDisConnect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ShowTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool CRAsLF { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableCTS { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableDSR { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableCD { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableRI { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool SetRTS { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool SetDTR { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Encoding ReceiveEncoding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AppendLineFeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableEcho { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LogFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool StreamLog { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SerialPort Port { get; set; }
        public int Sent 
        { 
            get => sentQty; 
            set 
            { 
                if(value == sentQty)
                {
                    return;
                }

                sentQty = value;
                OnNotifyPropertyChanged();
            } 
        }
        public int Received 
        { 
            get => receivedQty;
            set 
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
            Port.Open();
        }

        public void Disconnect()
        {
            Port.Close();
        }

        public string GetMacro(int index)
        {
            if (UserMacros.Count > index)
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
            if (Port.IsOpen == false)
            {
                throw new InvalidOperationException("Comm port is closed");
            }
            Port.Write(new byte[] { (byte)key }, 0, 1);
        }

        public void SendString(string str)
        {
            if (Port.IsOpen == false)
            {
                throw new InvalidOperationException("Comm port is closed");
            }
            Port.Write(str);
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
