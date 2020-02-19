using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Views
{
    public interface ISerialView
    {
        /* Transmission events */
        event EventHandler<string> SendFile;
        event EventHandler<string> SendString;
        event EventHandler<char> SendKey;
        event EventHandler<string> SendMacro;
        /* Receive settings event */
        event EventHandler ReceiveDataTypeChanged;
        /* Transmit settings event */
        event EventHandler<bool> TransmitCRAsLFChanged;

        /* Params events */
        event EventHandler<Parity> ParityChanged;
        event EventHandler<string> PortNameChanged;
        event EventHandler<int> BaudrateChanged;
        event EventHandler<Handshake> HandshakeChanged;
        event EventHandler<StopBits> StopbitsChanged;
        event EventHandler<int> DataBitsChanged;

        /* Operation events */
        event EventHandler ConnectStatusChange;
        event EventHandler ReceiveClean;
        event EventHandler TransmitClean;

        /* User parameters (such as macros and request-response) */
        event EventHandler MacroSet;
        event EventHandler LogStart;
        event EventHandler SetRequestResponse;

        /* Settings events */
        event EventHandler LineStatusChanged;
        event EventHandler AutoDisconnectChanged;
        event EventHandler LogTimeChanged;
        event EventHandler NewLineCharacterChanged;
        event EventHandler LogStreamChanged;

        event EventHandler EchoChanged;

        /* Update methods */
        void AppendReceivedData(string str);
        void AppendReceivedData(byte[] buf, int offset, int count);

        void ComPortConnectedStatusUpdate(bool succeed, string error);
        void ComPortErrorState(string error);
        void TransmitedUpdate(int transmited);
        void ReceivedUpdate(int received);

    }
}
