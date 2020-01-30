using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerminalSerial;
using System.IO.Ports;
using System.IO;
using Terminal.BindableComponents;

namespace Terminal
{
    public partial class Form1 : Form
    {
        private Serial Serial;
        private UpdatableFields miscData = new UpdatableFields();
        private bool ShowAscii = true;

        
        private Dictionary<String, Parity> parityDictionary = new Dictionary<string, Parity>()
        {
            {"None", Parity.None },
            {"Odd", Parity.Odd},
            {"Even", Parity.Even },
            {"Mark", Parity.Mark },
            {"Space", Parity.Space },
        };

        private Dictionary<String, StopBits> stopbitsDictionary = new Dictionary<string, StopBits>()
        {
            {"1", StopBits.One },
            {"1.5", StopBits.OnePointFive },
            {"2", StopBits.Two },
        };

        private Dictionary<String, Handshake> handshakeDictionary = new Dictionary<string, Handshake>()
        {
            {"None", Handshake.None },
            {"RTS/CTS", Handshake.RequestToSend },
            {"XON/XOFF", Handshake.XOnXOff },
            {"RTS/CTS + XON/XOFF", Handshake.RequestToSendXOnXOff }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindableToolStripLabel bindableToolStripLabel;
            Serial = new Serial();

            comPortCb.Items.AddRange(SerialPort.GetPortNames());
            if (comPortCb.Items.Count > 0)
            {
                comPortCb.SelectedIndex = 0;
                connectBtn.Enabled = true;
            }

            ParityCb.DataSource = new BindingSource(parityDictionary, null);
            ParityCb.DisplayMember = "Key";
            ParityCb.ValueMember = "Value";
            StopbitCb.DataSource = new BindingSource(stopbitsDictionary, null);
            StopbitCb.DisplayMember = "Key";
            StopbitCb.ValueMember = "Value";
            HandshakeCb.DataSource = new BindingSource(handshakeDictionary, null);
            HandshakeCb.DisplayMember = "Key";
            HandshakeCb.ValueMember = "Value";

            BaudrateCb.SelectedIndex = 3;
            DatabitCb.SelectedIndex = 3;
            ParityCb.SelectedIndex = 0;
            StopbitCb.SelectedIndex = 0;
            HandshakeCb.SelectedIndex = 0;

            /* Bind items */
            /* Status text */
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.DataBindings.Add(new Binding("Text", miscData, "ErrorString"));
            statusStrip1.Items.Add(bindableToolStripLabel);

            /* Split */
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.Text = "|";
            statusStrip1.Items.Add(bindableToolStripLabel);

            /* Rx */
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.Text = "RX: ";
            statusStrip1.Items.Add(bindableToolStripLabel);
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.DataBindings.Add(new Binding("Text", Serial, "Received"));
            statusStrip1.Items.Add(bindableToolStripLabel);

            /* Split */
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.Text = "|";
            statusStrip1.Items.Add(bindableToolStripLabel);

            /* Tx */
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.Text = "TX: ";
            statusStrip1.Items.Add(bindableToolStripLabel);
            bindableToolStripLabel = new BindableToolStripLabel();
            bindableToolStripLabel.DataBindings.Add(new Binding("Text", Serial, "Sent"));
            statusStrip1.Items.Add(bindableToolStripLabel);

            splitContainer1.Panel1MinSize = 150;
            splitContainer1.Panel2MinSize = 50;

            Serial.ReceivedDelegate = OnSerialDataArrived;

            PropertyChangedNotificationInterceptor.UIContext = System.Threading.SynchronizationContext.Current;
        }

        private int BaudrateFromUI()
        {
            string textBaudrate;

            /* Is this the last element?*/
            if (BaudrateCb.SelectedIndex == BaudrateCb.Items.Count)
            {
                /* If so, the baudrate is gave by user */
                textBaudrate = customBrTb.Text;
            } else
            {
                textBaudrate = BaudrateCb.SelectedText;
            }

            if (int.TryParse(textBaudrate, out int baudrate) == false)
            {
                /* Fallback baudrate */
                baudrate = 600;
            }

            return baudrate;
        }

        private int DatabitsFromUI()
        {
            if (int.TryParse(DatabitCb.SelectedText, out int databits) == false)
            {
                /* Fallback Databits */
                databits = 8;
            }

            return databits;
        }

        private Parity ParityFromUI()
        {
            if(parityDictionary.TryGetValue(ParityCb.SelectedText, out Parity parity) == false)
            {
                /* Fallback parity */
                parity = Parity.None;
            }
            return parity;
        }

        private Handshake HandshakeFromUI()
        {
            if (handshakeDictionary.TryGetValue(ParityCb.SelectedText, out Handshake handshake) == false)
            {
                /* Fallback Handshake */
                handshake = Handshake.None;
            }
            return handshake;
        }

        private StopBits StopbitsFromUI()
        {
            if (stopbitsDictionary.TryGetValue(StopbitCb.SelectedText, out StopBits stopBits) == false)
            {
                /* Fallback Stopbits */
                stopBits = StopBits.One;
            }
            return stopBits;
        }

        private void HandleConnection()
        {
            /* Initialize port options */
            Serial.BaudRate = BaudrateFromUI();
            Serial.DataBits = DatabitsFromUI();
            Serial.Parity = ParityFromUI();
            Serial.StopBits = StopbitsFromUI();
            Serial.Handshake = HandshakeFromUI();
            Serial.ReadTimeout = 50;
            Serial.PortName = comPortCb.SelectedItem.ToString();
            try
            {
                Serial.Open();
                if (Serial.IsOpen == true)
                {
                    miscData.ErrorString = "Connected";
                }
            }
            catch (Exception)
            {

            }

            connectBtn.Text = "Disconnect";
            comPortCb.Enabled = false;
        }

        private void HandleDisconnection()
        {
            Serial.Close();
            miscData.ErrorString = "";
            connectBtn.Text = "Connect";
            comPortCb.Enabled = true;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                HandleDisconnection();
            }
            else
            {
                HandleConnection();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Serial.IsOpen)
                {
                    Serial.Close();
                }
            }
            catch (IOException)
            {

            }
        }

        private void OnSerialDataArrived(TerminalSerialDataEventArgs args)
        {
            try
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    receivedTb.Text += Encoding.ASCII.GetString(args.DataRead, 0, args.BytesRead);
                }));
            }
            catch (Exception)
            {

            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            receivedTb.Clear();
        }

        private void ComPortCb_DropDown(object sender, EventArgs e)
        {
            comPortCb.Items.Clear();
            comPortCb.Items.AddRange(Serial.GetPortNames());
            if (comPortCb.Items.Count > 0)
            {
                comPortCb.SelectedIndex = 0;
                connectBtn.Enabled = true;
            }
        }
    }
}
