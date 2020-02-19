using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logic.MVP.Models
{
    public enum Encoding
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
        bool AutoDisConnect { get; set; }
        bool ShowTime { get; set; }
        bool CRAsLF { get; set; }

        bool EnableCTS { get; set; }
        bool EnableDSR { get; set; }
        bool EnableCD { get; set; }
        bool EnableRI { get; set; }

        bool SetRTS { get; set; }
        bool SetDTR { get; set; }

        /* Receive options */
        Encoding ReceiveEncoding { get; set; }

        /* Transmit options */
        bool AppendLineFeed { get; set; }
        bool EnableEcho { get; set; }

        /* Log parameters */
        string LogFilePath { get; set; }
        bool StreamLog { get; set; }

        SerialPort Port { get; set; }

        /* Transaction quantities */
        int Sent { get; set; }
        int Received { get; set; }
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
}
