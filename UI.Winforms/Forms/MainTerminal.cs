using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using Logic.MVP.Views;

namespace UI.Winforms.Forms
{
    public partial class MainTerminal : Form, ISerialView
    {
        public event EventHandler<string> SendFile;
        public event EventHandler<string> SendString;
        public event EventHandler<char> SendKey;
        public event EventHandler<string> SendMacro;
        public event EventHandler<bool> ReceiveDataTypeChanged;
        public event EventHandler<bool> TransmitCRAsLFChanged;
        public event EventHandler<string> ParityChanged;
        public event EventHandler<string> PortNameChanged;
        public event EventHandler<string> BaudrateChanged;
        public event EventHandler<string> HandshakeChanged;
        public event EventHandler<string> StopbitsChanged;
        public event EventHandler<string> DataBitsChanged;
        public event EventHandler ConnectStatusChange;
        public event EventHandler ReceiveClean;
        public event EventHandler TransmitClean;
        public event EventHandler MacroSet;
        public event EventHandler LogStart;
        public event EventHandler SetRequestResponse;
        public event EventHandler<bool> LineStatusChanged;
        public event EventHandler<bool> AutoDisconnectChanged;
        public event EventHandler<bool> LogTimeChanged;
        public event EventHandler<bool> NewLineCharacterChanged;
        public event EventHandler<bool> LogStreamChanged;
        public event EventHandler<bool> EchoChanged;
        public event EventHandler PortNameUpdateRequest;
        public event EventHandler BaudrateUpdateRequest;
        public event EventHandler DataBitsUpdateRequest;
        public event EventHandler StopBitsUpdateRequest;
        public event EventHandler HandshakeUpdateRequest;
        public event EventHandler ParityUpdateRequest;
        public event EventHandler<string> CustomBaudrateChanged;

        public MainTerminal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            receivedTb.GotFocus += new EventHandler(OnGotFocus);
            splitContainer1.Panel1MinSize = 150;
            splitContainer1.Panel2MinSize = 50;

            comPortCb.DisplayMember = "Key";
            comPortCb.ValueMember = "Value";
            BaudrateCb.DisplayMember = "Key";
            BaudrateCb.ValueMember = "Value";
            DatabitCb.DisplayMember = "Key";
            DatabitCb.ValueMember = "Value";
            ParityCb.DisplayMember = "Key";
            ParityCb.ValueMember = "Value";
            StopbitCb.DisplayMember = "Key";
            StopbitCb.ValueMember = "Value";
            HandshakeCb.DisplayMember = "Key";
            HandshakeCb.ValueMember = "Value";

            RcvAsciiRb.Tag = true;
            RcvHexRb.Tag = false;

            /* Ask for parameters update */
            PortNameUpdateRequest?.Invoke(this, new EventArgs());
            BaudrateUpdateRequest?.Invoke(this, new EventArgs());
            DataBitsUpdateRequest?.Invoke(this, new EventArgs());
            StopBitsUpdateRequest?.Invoke(this, new EventArgs());
            HandshakeUpdateRequest?.Invoke(this, new EventArgs());
            ParityUpdateRequest?.Invoke(this, new EventArgs());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            HideCaret(receivedTb.Handle);
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(System.IntPtr hWnd);

        public void AppendReceivedData(string str)
        {
            throw new NotImplementedException();
        }

        public void AppendReceivedData(byte[] buf, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public void ComPortConnectedStatusUpdate(bool succeed, string error)
        {
            if(succeed == true)
            {
                connectBtn.Text = "Disconnect";
            } else
            {
                connectBtn.Text = "Connect";
            }            
        }

        public void ComPortErrorState(string error)
        {
            throw new NotImplementedException();
        }

        public void TransmitedUpdate(int transmited)
        {
            throw new NotImplementedException();
        }

        public void ReceivedUpdate(int received)
        {
            throw new NotImplementedException();
        }

        public void ComPortNamesUpdate(string[] portNames)
        { 
            /* Drop data source */
            comPortCb.DataSource = null;
            comPortCb.Items.Clear();
            comPortCb.DataSource = new BindingSource(portNames.ToDictionary((name) => name), null);
            comPortCb.DisplayMember = "Key";
            comPortCb.ValueMember = "Value";
        }

        private void ComPortCb_DropDown(object sender, EventArgs e)
        {
            /* Raise event */
            PortNameUpdateRequest?.Invoke(this, new EventArgs());
        }

        public void BaudrateUpdate(string[] baudrates)
        {
            BaudrateCb.DataSource = null;
            BaudrateCb.Items.Clear();
            BaudrateCb.DataSource = new BindingSource(baudrates.ToDictionary((br) => br), null);
            BaudrateCb.DisplayMember = "Key";
            BaudrateCb.ValueMember = "Value";
        }

        public void DataBitsUpdate(string[] databits)
        {
            DatabitCb.DataSource = null;
            DatabitCb.Items.Clear();
            DatabitCb.DataSource = new BindingSource(databits.ToDictionary((db) => db), null);
            DatabitCb.DisplayMember = "Key";
            DatabitCb.ValueMember = "Value";
        }

        public void StopBitsUpdate(string[] stopbits)
        {
            StopbitCb.DataSource = null;
            StopbitCb.Items.Clear();
            StopbitCb.DataSource = new BindingSource(stopbits.ToDictionary((sb) => sb), null);
            StopbitCb.DisplayMember = "Key";
            StopbitCb.ValueMember = "Value";
        }

        public void HandshakeUpdate(string[] handshake)
        {
            HandshakeCb.DataSource = null;
            HandshakeCb.Items.Clear();
            HandshakeCb.DataSource = new BindingSource(handshake.ToDictionary((hs) => hs), null);
            HandshakeCb.DisplayMember = "Key";
            HandshakeCb.ValueMember = "Value";
        }

        public void ParityUpdate(string[] parity)
        {
            ParityCb.DataSource = null;
            ParityCb.Items.Clear();
            ParityCb.DataSource = new BindingSource(parity.ToDictionary((pt) => pt), null);
            ParityCb.DisplayMember = "Key";
            ParityCb.ValueMember = "Value";
        }

        private void ComPortCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PortNameChanged?.Invoke(this, (string)comPortCb.SelectedValue);
        }

        public void SetCustomBaudrateOption(bool enable)
        {
            customBrTb.Enabled = enable;
        }

        private void BaudrateCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BaudrateChanged?.Invoke(this, (string)BaudrateCb.SelectedValue);
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            ConnectStatusChange?.Invoke(this, new EventArgs());
        }

        private void ReceivedTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            SendKey?.Invoke(this, e.KeyChar);
        }

        private void CustomBrTb_TextChanged(object sender, EventArgs e)
        {
            CustomBaudrateChanged?.Invoke(this, customBrTb.Text);
        }

        private void ClearRcvBtn_Click(object sender, EventArgs e)
        {
            ReceiveClean?.Invoke(this, new EventArgs());
        }

        private void ClearTransmitBtn_Click(object sender, EventArgs e)
        {
            TransmitClean?.Invoke(this, new EventArgs());
        }

        private void EchoChkb_CheckedChanged(object sender, EventArgs e)
        {
            EchoChanged?.Invoke(this, EchoChkb.Checked);
        }

        private void DatabitCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataBitsChanged?.Invoke(this, (string)DatabitCb.SelectedValue);
        }

        private void ParityCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ParityChanged?.Invoke(this, (string)ParityCb.SelectedValue);
        }

        private void StopbitCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopbitsChanged?.Invoke(this, (string)StopbitCb.SelectedValue);
        }

        private void HandshakeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandshakeChanged?.Invoke(this, (string)HandshakeCb.SelectedValue);
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            SendString?.Invoke(this, rawDataTb.Text);
        }

        private void NewLineFormatCkb_CheckedChanged(object sender, EventArgs e)
        {
            TransmitCRAsLFChanged?.Invoke(this, NewLineFormatCkb.Checked);
        }

        private void CrAsLFChb_CheckedChanged(object sender, EventArgs e)
        {
            NewLineCharacterChanged?.Invoke(this, CrAsLFChb.Checked);
        }

        private void LogStreamChb_CheckedChanged(object sender, EventArgs e)
        {
            LogStreamChanged?.Invoke(this, LogStreamChb.Checked);
        }

        private void AppendTimeChb_CheckedChanged(object sender, EventArgs e)
        {
            LogTimeChanged?.Invoke(this, AppendTimeChb.Checked);
        }

        private void AutoDisconnectChb_CheckedChanged(object sender, EventArgs e)
        {
            AutoDisconnectChanged?.Invoke(this, AutoDisconnectChb.Checked);
        }

        private void RcvAsciiRb_CheckedChanged(object sender, EventArgs e)
        {
            ReceiveDataTypeChanged?.Invoke(this, (bool)RcvAsciiRb.Tag);
        }

        private void RcvHexRb_CheckedChanged(object sender, EventArgs e)
        {
            ReceiveDataTypeChanged?.Invoke(this, (bool)RcvAsciiRb.Tag);
        }
    }
}
