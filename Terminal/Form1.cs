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
using System.Runtime.InteropServices;

namespace Terminal
{
    public partial class Form1 : Form
    {
        private Serial Serial;
        private UpdatableFields miscData = new UpdatableFields();
        private bool ShowAscii = true;
        private bool isEchoEnabled = false;
        private bool scrollToEnd = true;

        
        private readonly Dictionary<string, Parity> parityDictionary = new Dictionary<string, Parity>()
        {
            {"None", Parity.None },
            {"Odd", Parity.Odd},
            {"Even", Parity.Even },
            {"Mark", Parity.Mark },
            {"Space", Parity.Space },
        };

        private readonly Dictionary<string, StopBits> stopbitsDictionary = new Dictionary<string, StopBits>()
        {
            {"1", StopBits.One },
            {"1.5", StopBits.OnePointFive },
            {"2", StopBits.Two },
        };

        private readonly Dictionary<string, Handshake> handshakeDictionary = new Dictionary<string, Handshake>()
        {
            {"None", Handshake.None },
            {"RTS/CTS", Handshake.RequestToSend },
            {"XON/XOFF", Handshake.XOnXOff },
            {"RTS/CTS + XON/XOFF", Handshake.RequestToSendXOnXOff }
        };

        private readonly Dictionary<string, int> baudrateDictionary = new Dictionary<string, int>()
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

        private readonly Dictionary<string, int> dataBitsDictionary = new Dictionary<string, int>()
        {
            { "5", 5},
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindableToolStripLabel bindableToolStripLabel;
            Serial = new Serial();

            ComPortUpdateList();
            comPortCb.DisplayMember = "Key";
            comPortCb.ValueMember = "Value";
            if (comPortCb.Items.Count > 0)
            {
                comPortCb.SelectedIndex = 0;
                connectBtn.Enabled = true;
            }

            receivedTb.GotFocus += new EventHandler(OnGotFocus);

            BaudrateCb.DataSource = new BindingSource(baudrateDictionary, null);
            BaudrateCb.DisplayMember = "Key";
            BaudrateCb.ValueMember = "Value";
            DatabitCb.DataSource = new BindingSource(dataBitsDictionary, null);
            DatabitCb.DisplayMember = "Key";
            DatabitCb.ValueMember = "Value";
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
            int baudrate = (int)BaudrateCb.SelectedValue;

            if(baudrate == 0)
            {
                int.TryParse(customBrTb.Text, out baudrate);
            }
            return baudrate;
        }

        private int DatabitsFromUI()
        {
            return (int)DatabitCb.SelectedValue;
        }

        private Parity ParityFromUI()
        {
            return (Parity)ParityCb.SelectedValue;
        }

        private Handshake HandshakeFromUI()
        {
            return (Handshake)HandshakeCb.SelectedValue;
        }

        private StopBits StopbitsFromUI()
        {
            return (StopBits)StopbitCb.SelectedValue;
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
            Serial.PortName = (string)comPortCb.SelectedValue;
            try
            {
                Serial.Open();
                if (Serial.IsOpen == true)
                {
                    miscData.ErrorString = "Connected";
                    connectBtn.Text = "Disconnect";
                    comPortCb.Enabled = false;
                }
            } catch(IOException ioEx)
            {

            }
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
            string receivedString;
            try
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    if(RcvHexRb.Checked == true)
                    {
                        receivedString = BitConverter.ToString(args.DataRead, 0, args.BytesRead).Replace('-', ' ');
                    } else
                    {
                        receivedString = Encoding.ASCII.GetString(args.DataRead, 0, args.BytesRead);
                    }
                    receivedTb.AppendText(receivedString);
                    receivedTb.SelectionStart = receivedTb.Text.Length;
                    receivedTb.ScrollToCaret();
                }));
            }
            catch (Exception)
            {

            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            receivedTb.Clear();
            Serial.Received = 0;
        }

        private void ComPortCb_DropDown(object sender, EventArgs e)
        {
            ComPortUpdateList();
            if (comPortCb.Items.Count > 0)
            {
                comPortCb.SelectedIndex = 0;
                connectBtn.Enabled = true;
            }
        }

        private void ComPortUpdateList()
        {
            Dictionary<string, string> portNames = new Dictionary<string, string>();
            string[] ports = Serial.GetPortNames();

            foreach (string portname in ports)
            {
                portNames.Add(portname, portname);
            }

            /* Drop data source */
            comPortCb.DataSource = null;
            comPortCb.Items.Clear();
            comPortCb.DataSource = new BindingSource(portNames, null);
            comPortCb.DisplayMember = "Key";
            comPortCb.ValueMember = "Value";
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            Serial.Write(rawDataTb.Text);
        }

        private void receivedTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(isEchoEnabled == false)
            {
                e.Handled = true;
            }
            Serial.WriteByte((byte)e.KeyChar);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            rawDataTb.Text = "";
            Serial.Sent = 0;
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            HideCaret(receivedTb.Handle);
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(System.IntPtr hWnd);
    }
}
