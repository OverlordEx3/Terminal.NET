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
            {"", StopBits.None }
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


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindableToolStripLabel bindableToolStripLabel;
            this.Serial = new Serial();

            this.comPortCb.Items.AddRange(SerialPort.GetPortNames());
            if (this.comPortCb.Items.Count > 0)
            {
                this.comPortCb.SelectedIndex = 0;
                this.connectBtn.Enabled = true;
            }

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

            receivedQtyLb.DataBindings.Add("Text", Serial, "Received");

            Serial.ReceivedDelegate = OnSerialDataArrived;

            PropertyChangedNotificationInterceptor.UIContext = System.Threading.SynchronizationContext.Current;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.reScanBtn.Enabled = false;
            this.connectBtn.Enabled = false;
            this.comPortCb.Enabled = false;

            this.comPortCb.Items.Clear();
            this.comPortCb.Items.AddRange(SerialPort.GetPortNames());
            if (this.comPortCb.Items.Count > 0)
            {
                this.comPortCb.SelectedIndex = 0;
                this.connectBtn.Enabled = true;
            }

            this.reScanBtn.Enabled = true;
            this.comPortCb.Enabled = true;
        }

        private void handleConnection()
        {
            int baudrate = 600;
            int databits = 8;
            Parity parity = Parity.None;
            Handshake handshake = Handshake.None;
            StopBits stopBits = StopBits.None;

            foreach (RadioButton rb in this.baudrateGb.Controls)
            {
                if (rb.Checked == true)
                {
                    if (rb.Name == "customRb")
                    {
                        baudrate = int.Parse(this.customBrTb.Text);
                        break;
                    }
                    baudrate = int.Parse(rb.Text);
                    break;
                }
            }

            foreach (RadioButton rb in this.databitsCb.Controls)
            {
                if (rb.Checked == true)
                {
                    databits = int.Parse(rb.Text);
                    break;
                }
            }

            foreach (RadioButton rb in this.parityGb.Controls)
            {
                if (rb.Checked == true)
                {
                    parity = parityDictionary[rb.Text];
                    break;
                }
            }


            foreach (RadioButton rb in this.stopBitsCb.Controls)
            {
                if (rb.Checked == true)
                {
                    stopBits = stopbitsDictionary[rb.Text];
                    break;
                }
            }

            foreach (RadioButton rb in this.handShakeGb.Controls)
            {
                if (rb.Checked == true)
                {
                    handshake = handshakeDictionary[rb.Text];
                    break;
                }
            }

            /* Initialize port options */
            Serial.BaudRate = baudrate;
            Serial.DataBits = databits;
            Serial.Parity = parity;
            Serial.StopBits = stopBits;
            Serial.Handshake = handshake;
            Serial.ReadTimeout = 50;
            Serial.PortName = comPortCb.SelectedItem.ToString();

            // FIXME check for errors
            try
            {
                Serial.Open();
                if (Serial.IsOpen == true)
                {
                    miscData.ErrorString = "Connected";
                }
            }
            catch (Exception ex)
            {

            }

            connectBtn.Text = "Disconnect";
            reScanBtn.Enabled = false;
            comPortCb.Enabled = false;
        }

        private void handleDisconnection()
        {
            Serial.Close();
            miscData.ErrorString = "";
            connectBtn.Text = "Connect";
            reScanBtn.Enabled = true;
            comPortCb.Enabled = true;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (Serial.IsOpen)
            {
                handleDisconnection();
            }
            else
            {
                handleConnection();
            }
        }

        private void baudrate_CheckedChanged(object sender, EventArgs e)
        {
            int baudrate = 0;
            RadioButton rb = (RadioButton)sender;

            if (rb.Name == "customRb")
            {
                baudrate = int.Parse(this.customBrTb.Text);
            }
            else
            {
                baudrate = int.Parse(rb.Text);
            }

            if (Serial.BaudRate == baudrate)
            {
                return;
            }

            Serial.BaudRate = baudrate;
        }

        private void parity_CheckedChanged(object sender, EventArgs e)
        {
            Parity parity = Parity.None;

            RadioButton rb = (RadioButton)sender;

            parity = parityDictionary[rb.Text];

            if (Serial.Parity == parity)
            {
                return;
            }

            Serial.Parity = parity;
        }

        private void databit_CheckedChanged(object sender, EventArgs e)
        {
            int databit = 0;
            RadioButton rb = (RadioButton)sender;

            databit = int.Parse(rb.Text);

            if (Serial.DataBits == databit)
            {
                return;
            }

            Serial.DataBits = databit;
        }

        private void stopbit_CheckedChanged(object sender, EventArgs e)
        {
            StopBits stopBits = StopBits.None;

            RadioButton rb = (RadioButton)sender;

            stopBits = stopbitsDictionary[rb.Text];

            if (Serial.StopBits == stopBits)
            {
                return;
            }

            Serial.StopBits = stopBits;
        }

        private void handshake_CheckedChanged(object sender, EventArgs e)
        {
            Handshake handshake = Handshake.None;

            RadioButton rb = (RadioButton)sender;

            handshake = handshakeDictionary[rb.Text];

            if (Serial.Handshake == handshake)
            {
                return;
            }

            Serial.Handshake = handshake;
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
            catch (IOException ex)
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Serial.IsOpen == false)
            {
                return;
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
            catch (Exception ex)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            receivedTb.Clear();
        }
    }
}
