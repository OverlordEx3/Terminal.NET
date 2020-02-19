using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Models;
using Terminal.Views;

namespace Terminal.Presenters
{
    class SerialPresenter : ISerialPresenter
    {
        private ISerialModel model;
        private ISerialView view;

        SerialPresenter(ISerialView view, ISerialModel model)
        {
            this.view = view;
            this.model = model;

            /* Register callbacks for view events */
            this.view.ConnectStatusChange += (sender, e) => OnConnect(sender, e);
            this.view.ReceiveClean += (sender, e) => OnReceiveClear(sender, e);
            this.view.TransmitClean += (sender, e) => OnTransmitClear(sender, e);

            /* Parity changed */
            this.view.ParityChanged += (sender, e) => model.Port.Parity = e;
            this.view.PortNameChanged += (sender, e) => model.Port.PortName = e;
            this.view.BaudrateChanged += (sender, e) => model.Port.BaudRate = e;
            this.view.HandshakeChanged += (sender, e) => model.Port.Handshake = e;
            this.view.StopbitsChanged += (sender, e) => model.Port.StopBits = e;
            this.view.DataBitsChanged += (sender, e) => model.Port.DataBits = e;

            /* Send functions */
            this.view.SendFile += (sender, e) => OnSendFile(e);
            this.view.SendString += (sender, e) => OnSendString(e);
            this.view.SendKey += (sender, e) => OnSendKey(e);
            this.view.SendMacro += (sender, e) => OnSendString(e);
        }

        void OnConnect(object sender, EventArgs e)
        {
            if(model.Port.IsOpen == true)
            {
                model.Disconnect();
                view.ComPortConnectedStatusUpdate(false, "");
            } else
            {
                model.Connect();
                view.ComPortConnectedStatusUpdate(true, "Connected");
            }
        }

        void OnReceiveClear(object sender, EventArgs e)
        {
            model.ClearReceived();
        }
        void OnTransmitClear(object sender, EventArgs e)
        {
            model.ClearSent();
        }

        void OnSendFile(string filePath)
        {
            model.SendFile(filePath);
        }

        void OnSendString(string str)
        {
            model.SendString(str);
        }

        void OnSendKey(char key)
        {
            model.SendKey(key);
        }

    }
}
