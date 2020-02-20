using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.MVP.Models;
using Logic.MVP.Views;

namespace Logic.MVP.Presenters
{
    public class SerialPresenter : ISerialPresenter
    {
        private readonly ISerialModel model;
        private readonly ISerialView view;

        private readonly Dictionary<string, Handshake> HandshakeDictionary = new Dictionary<string, Handshake>()
        {
            {"None", Handshake.None },
            {"RTS/CTS", Handshake.RequestToSend },
            {"XON/XOFF", Handshake.XOnXOff },
            {"RTS/CTS + XON/XOFF", Handshake.RequestToSendXOnXOff }
        };

        private readonly Dictionary<string, StopBits> StopbitsDictionary = new Dictionary<string, StopBits>()
        {
            {"1", StopBits.One },
            {"1.5", StopBits.OnePointFive },
            {"2", StopBits.Two },
        };

        private readonly Dictionary<string, int> DataBitsDictionary = new Dictionary<string, int>()
        {
            { "5", 5},
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
        };

        private readonly Dictionary<string, Parity> ParityDictionary = new Dictionary<string, Parity>()
        {
            {"None", Parity.None },
            {"Odd", Parity.Odd},
            {"Even", Parity.Even },
            {"Mark", Parity.Mark },
            {"Space", Parity.Space },
        };

        private readonly Dictionary<string, int> BaudrateDictionary = new Dictionary<string, int>()
        {
            {"600", 600 },
            { "2400", 2400},
            {"4800", 4800 },
            {"9600", 9600 },
            {"19200", 19200 },
            {"38400", 38400 },
            {"57600", 57600 },
            {"115200", 115200 },
            {"<custom>", 0000 },
        };

        public SerialPresenter(ISerialView view, ISerialModel model)
        {
            this.view = view;
            this.model = model;

            /* Register callbacks for view events */
            this.view.ConnectStatusChange += (sender, e) => OnConnect(sender, e);
            this.view.ReceiveClean += (sender, e) => OnReceiveClear(sender, e);
            this.view.TransmitClean += (sender, e) => OnTransmitClear(sender, e);

            /* Parity changed */
            this.view.PortNameChanged += (sender, e) => model.Port.PortName = e;
            this.view.BaudrateChanged += new EventHandler<string>(delegate (object o, string e)
            {
                if(BaudrateDictionary.ContainsKey(e))
                {
                    if(BaudrateDictionary[e] != 0000)
                    {
                        this.model.Port.BaudRate = BaudrateDictionary[e];
                        this.view.SetCustomBaudrateOption(false);
                    } else
                    {
                        this.view.SetCustomBaudrateOption(true);
                    }
                }
            });
            this.view.ParityChanged += new EventHandler<string>(delegate (object o, string e)
            {
                if(ParityDictionary.ContainsKey(e))
                {
                    this.model.Port.Parity = ParityDictionary[e];
                }
            });
            this.view.HandshakeChanged += new EventHandler<string>(delegate (object o, string e) 
            {
                if(HandshakeDictionary.ContainsKey(e))
                {
                    this.model.Port.Handshake = HandshakeDictionary[e];
                }
            });
            this.view.StopbitsChanged += new EventHandler<string>(delegate (object o, string e) 
            {
                if(StopbitsDictionary.ContainsKey(e))
                {
                    this.model.Port.StopBits = StopbitsDictionary[e];
                }
            });
            this.view.DataBitsChanged += new EventHandler<string>(delegate (object o, string e) 
            {
                if(DataBitsDictionary.ContainsKey(e))
                {
                    this.model.Port.DataBits = DataBitsDictionary[e];
                }
            });

            /* Send functions */
            this.view.SendFile += (sender, e) => OnSendFile(e);
            this.view.SendString += (sender, e) => OnSendString(e);
            this.view.SendKey += (sender, e) => OnSendKey(e);
            this.view.SendMacro += (sender, e) => OnSendString(e);

            /* Update functions */
            this.view.PortNameUpdateRequest += (sender, e) => OnComPortNamesUpdateRequest();
            this.view.BaudrateUpdateRequest += (sender, e) => OnBaudrateUpdateRequest();
            this.view.DataBitsUpdateRequest += (sender, e) => OnDataBitUpdateRequest();
            this.view.StopBitsUpdateRequest += (sender, e) => OnStopBitUpdateRequest();
            this.view.HandshakeUpdateRequest += (sender, e) => OnHandshakeUpdateRequest();
            this.view.ParityUpdateRequest += (sender, e) => OnParityUpdateRequest();
        }
        
        void OnComPortNamesUpdateRequest()
        {
            view.ComPortNamesUpdate(SerialPort.GetPortNames());
        }

        void OnDataBitUpdateRequest()
        {
            view.DataBitsUpdate(DataBitsDictionary.Keys.ToArray());
        }

        void OnStopBitUpdateRequest()
        {
            view.StopBitsUpdate(StopbitsDictionary.Keys.ToArray());
        }

        void OnHandshakeUpdateRequest()
        {
            view.HandshakeUpdate(HandshakeDictionary.Keys.ToArray());
        }

        void OnParityUpdateRequest()
        {
            view.ParityUpdate(ParityDictionary.Keys.ToArray());
        }

        void OnBaudrateUpdateRequest()
        {
            view.BaudrateUpdate(BaudrateDictionary.Keys.ToArray());
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
