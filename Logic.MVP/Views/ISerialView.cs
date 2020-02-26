using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MVP.Views
{
    public interface ISerialView
    {
        /* Transmission events */
        event EventHandler<string> SendFile;
        event EventHandler<string> SendString;
        event EventHandler<char> SendKey;
        event EventHandler<string> SendMacro;
        /* Receive settings event */
        event EventHandler<bool> ReceiveDataTypeChanged;
        /* Transmit settings event */
        event EventHandler<bool> TransmitCRAsLFChanged;

        /* Params events */
        event EventHandler<string> ParityChanged;
        event EventHandler<string> PortNameChanged;
        event EventHandler<string> BaudrateChanged;
        event EventHandler<string> HandshakeChanged;
        event EventHandler<string> StopbitsChanged;
        event EventHandler<string> DataBitsChanged;
        event EventHandler<string> CustomBaudrateChanged;

        /* Operation events */
        event EventHandler ConnectStatusChange;
        event EventHandler ReceiveClean;
        event EventHandler TransmitClean;

        /* User parameters (such as macros and request-response) */
        event EventHandler MacroSet;
        event EventHandler LogStart;
        event EventHandler SetRequestResponse;

        /* Settings events */
        event EventHandler<bool> LineStatusChanged;
        event EventHandler<bool> AutoDisconnectChanged;
        event EventHandler<bool> LogTimeChanged;
        event EventHandler<bool> NewLineCharacterChanged;
        event EventHandler<bool> LogStreamChanged;

        event EventHandler<bool> EchoChanged;

        /* Request Events */
        event EventHandler PortNameUpdateRequest;
        event EventHandler BaudrateUpdateRequest;
        event EventHandler DataBitsUpdateRequest;
        event EventHandler StopBitsUpdateRequest;
        event EventHandler HandshakeUpdateRequest;
        event EventHandler ParityUpdateRequest;

        /* Update methods */
        void AppendReceivedData(string str);
        void AppendReceivedData(byte[] buf, int offset, int count);

        void ComPortConnectedStatusUpdate(bool connectionStatus, string error);
        void ComPortErrorState(string error);
        void TransmitedUpdate(int transmited);
        void ReceivedUpdate(int received);

        void ComPortNamesUpdate(string[] portNames);
        void BaudrateUpdate(string[] baudrates);
        void DataBitsUpdate(string[] databits);
        void StopBitsUpdate(string[] stopbits);
        void HandshakeUpdate(string[] handshake);
        void ParityUpdate(string[] parity);
        void SetCustomBaudrateOption(bool enable);
    }
}
