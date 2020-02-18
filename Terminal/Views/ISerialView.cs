using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal.Views
{
    public interface ISerialView
    {
        event EventHandler dataReceived;
        event EventHandler parityChanged;
        event EventHandler PortNameChanged;
        event EventHandler BaudrateChanged;
        event EventHandler HandshakeChanged;
        event EventHandler StopbitsChanged;
        event EventHandler DataBitsChanged;
        event EventHandler Connect;


    }
}
