namespace UI.Winforms.Forms
{
    partial class MainTerminal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.baudrateGb = new System.Windows.Forms.GroupBox();
            this.BaudrateCb = new System.Windows.Forms.ComboBox();
            this.parityGb = new System.Windows.Forms.GroupBox();
            this.ParityCb = new System.Windows.Forms.ComboBox();
            this.handShakeGb = new System.Windows.Forms.GroupBox();
            this.HandshakeCb = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.customBrTb = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RcvHexRb = new System.Windows.Forms.RadioButton();
            this.RcvAsciiRb = new System.Windows.Forms.RadioButton();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.receivedTb = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button31 = new System.Windows.Forms.Button();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.stopBitsCb = new System.Windows.Forms.GroupBox();
            this.StopbitCb = new System.Windows.Forms.ComboBox();
            this.databitsCb = new System.Windows.Forms.GroupBox();
            this.DatabitCb = new System.Windows.Forms.ComboBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.comPortCb = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sendBtn = new System.Windows.Forms.Button();
            this.rawDataTb = new System.Windows.Forms.TextBox();
            this.baudrateGb.SuspendLayout();
            this.parityGb.SuspendLayout();
            this.handShakeGb.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.stopBitsCb.SuspendLayout();
            this.databitsCb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baudrateGb
            // 
            this.baudrateGb.Controls.Add(this.BaudrateCb);
            this.baudrateGb.Location = new System.Drawing.Point(98, 2);
            this.baudrateGb.Name = "baudrateGb";
            this.baudrateGb.Size = new System.Drawing.Size(85, 70);
            this.baudrateGb.TabIndex = 6;
            this.baudrateGb.TabStop = false;
            this.baudrateGb.Text = "Baudrate";
            // 
            // BaudrateCb
            // 
            this.BaudrateCb.FormattingEnabled = true;
            this.BaudrateCb.Location = new System.Drawing.Point(5, 19);
            this.BaudrateCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BaudrateCb.Name = "BaudrateCb";
            this.BaudrateCb.Size = new System.Drawing.Size(74, 21);
            this.BaudrateCb.TabIndex = 0;
            this.BaudrateCb.SelectionChangeCommitted += new System.EventHandler(this.BaudrateCb_SelectionChangeCommitted);
            // 
            // parityGb
            // 
            this.parityGb.Controls.Add(this.ParityCb);
            this.parityGb.Location = new System.Drawing.Point(255, 2);
            this.parityGb.Name = "parityGb";
            this.parityGb.Size = new System.Drawing.Size(80, 70);
            this.parityGb.TabIndex = 8;
            this.parityGb.TabStop = false;
            this.parityGb.Text = "Parity";
            // 
            // ParityCb
            // 
            this.ParityCb.FormattingEnabled = true;
            this.ParityCb.Location = new System.Drawing.Point(5, 19);
            this.ParityCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ParityCb.Name = "ParityCb";
            this.ParityCb.Size = new System.Drawing.Size(71, 21);
            this.ParityCb.TabIndex = 20;
            // 
            // handShakeGb
            // 
            this.handShakeGb.Controls.Add(this.HandshakeCb);
            this.handShakeGb.Location = new System.Drawing.Point(410, 2);
            this.handShakeGb.Name = "handShakeGb";
            this.handShakeGb.Size = new System.Drawing.Size(101, 70);
            this.handShakeGb.TabIndex = 9;
            this.handShakeGb.TabStop = false;
            this.handShakeGb.Text = "Handshake";
            // 
            // HandshakeCb
            // 
            this.HandshakeCb.FormattingEnabled = true;
            this.HandshakeCb.Items.AddRange(new object[] {
            "None",
            "RTS/CTS",
            "XON/XOFF",
            "RTS/CTS+XON/XOFF",
            "RTS on TX"});
            this.HandshakeCb.Location = new System.Drawing.Point(5, 19);
            this.HandshakeCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HandshakeCb.Name = "HandshakeCb";
            this.HandshakeCb.Size = new System.Drawing.Size(91, 21);
            this.HandshakeCb.TabIndex = 21;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.checkBox9);
            this.groupBox6.Controls.Add(this.checkBox5);
            this.groupBox6.Controls.Add(this.checkBox4);
            this.groupBox6.Controls.Add(this.checkBox8);
            this.groupBox6.Controls.Add(this.checkBox3);
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Controls.Add(this.checkBox7);
            this.groupBox6.Controls.Add(this.checkBox6);
            this.groupBox6.Location = new System.Drawing.Point(514, 2);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(284, 70);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Settings";
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(245, 34);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(37, 17);
            this.checkBox9.TabIndex = 9;
            this.checkBox9.Text = "RI";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(121, 35);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(76, 17);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "Stream log";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(121, 18);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(65, 17);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "CR = LF";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(245, 17);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(41, 17);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.Text = "CD";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(10, 35);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(49, 17);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Time";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 18);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(111, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Auto Dis/Connect";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(197, 34);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(49, 17);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "DSR";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(197, 19);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(47, 17);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.Text = "CTS";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // customBrTb
            // 
            this.customBrTb.Location = new System.Drawing.Point(104, 44);
            this.customBrTb.Name = "customBrTb";
            this.customBrTb.Size = new System.Drawing.Size(74, 20);
            this.customBrTb.TabIndex = 4;
            this.customBrTb.Text = "600";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RcvHexRb);
            this.groupBox7.Controls.Add(this.RcvAsciiRb);
            this.groupBox7.Controls.Add(this.button6);
            this.groupBox7.Location = new System.Drawing.Point(3, 75);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(115, 59);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Receive";
            // 
            // RcvHexRb
            // 
            this.RcvHexRb.AutoSize = true;
            this.RcvHexRb.Location = new System.Drawing.Point(8, 15);
            this.RcvHexRb.Margin = new System.Windows.Forms.Padding(0);
            this.RcvHexRb.Name = "RcvHexRb";
            this.RcvHexRb.Size = new System.Drawing.Size(44, 17);
            this.RcvHexRb.TabIndex = 1;
            this.RcvHexRb.Text = "Hex";
            this.RcvHexRb.UseVisualStyleBackColor = true;
            // 
            // RcvAsciiRb
            // 
            this.RcvAsciiRb.AutoSize = true;
            this.RcvAsciiRb.Checked = true;
            this.RcvAsciiRb.Location = new System.Drawing.Point(57, 15);
            this.RcvAsciiRb.Margin = new System.Windows.Forms.Padding(0);
            this.RcvAsciiRb.Name = "RcvAsciiRb";
            this.RcvAsciiRb.Size = new System.Drawing.Size(52, 17);
            this.RcvAsciiRb.TabIndex = 2;
            this.RcvAsciiRb.TabStop = true;
            this.RcvAsciiRb.Text = "ASCII";
            this.RcvAsciiRb.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(23, 39);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 20);
            this.button6.TabIndex = 0;
            this.button6.Text = "CLEAR";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(83, 14);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 20);
            this.button9.TabIndex = 6;
            this.button9.Text = "Req./Resp.";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(5, 14);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(72, 20);
            this.button8.TabIndex = 5;
            this.button8.Text = "START Log";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // receivedTb
            // 
            this.receivedTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.receivedTb.Location = new System.Drawing.Point(0, 0);
            this.receivedTb.Margin = new System.Windows.Forms.Padding(0);
            this.receivedTb.Multiline = true;
            this.receivedTb.Name = "receivedTb";
            this.receivedTb.ReadOnly = true;
            this.receivedTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.receivedTb.Size = new System.Drawing.Size(797, 465);
            this.receivedTb.TabIndex = 12;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.checkBox10);
            this.groupBox8.Controls.Add(this.button10);
            this.groupBox8.Location = new System.Drawing.Point(118, 75);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(100, 59);
            this.groupBox8.TabIndex = 13;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Transmit";
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(6, 16);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(92, 17);
            this.checkBox10.TabIndex = 4;
            this.checkBox10.Text = "CR = CR + LF";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(16, 39);
            this.button10.Margin = new System.Windows.Forms.Padding(0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 20);
            this.button10.TabIndex = 1;
            this.button10.Text = "CLEAR";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(179, 14);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(48, 17);
            this.checkBox12.TabIndex = 6;
            this.checkBox12.Text = "RTS";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(178, 37);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(49, 17);
            this.checkBox11.TabIndex = 5;
            this.checkBox11.Text = "DTR";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(5, 37);
            this.button11.Margin = new System.Windows.Forms.Padding(0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(72, 20);
            this.button11.TabIndex = 3;
            this.button11.Text = "Send file";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox9.Controls.Add(this.button19);
            this.groupBox9.Controls.Add(this.button20);
            this.groupBox9.Controls.Add(this.button17);
            this.groupBox9.Controls.Add(this.button18);
            this.groupBox9.Controls.Add(this.button15);
            this.groupBox9.Controls.Add(this.button16);
            this.groupBox9.Controls.Add(this.button14);
            this.groupBox9.Controls.Add(this.button13);
            this.groupBox9.Controls.Add(this.button12);
            this.groupBox9.Location = new System.Drawing.Point(218, 75);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(344, 59);
            this.groupBox9.TabIndex = 14;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Macros";
            // 
            // button19
            // 
            this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button19.Location = new System.Drawing.Point(277, 37);
            this.button19.Margin = new System.Windows.Forms.Padding(0);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(65, 20);
            this.button19.TabIndex = 10;
            this.button19.Text = "M2";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button20.Location = new System.Drawing.Point(277, 18);
            this.button20.Margin = new System.Windows.Forms.Padding(0);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(65, 20);
            this.button20.TabIndex = 9;
            this.button20.Text = "M1";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button17.Location = new System.Drawing.Point(212, 37);
            this.button17.Margin = new System.Windows.Forms.Padding(0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(65, 20);
            this.button17.TabIndex = 8;
            this.button17.Text = "M2";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button18.Location = new System.Drawing.Point(212, 18);
            this.button18.Margin = new System.Windows.Forms.Padding(0);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(65, 20);
            this.button18.TabIndex = 7;
            this.button18.Text = "M1";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button15.Location = new System.Drawing.Point(147, 37);
            this.button15.Margin = new System.Windows.Forms.Padding(0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(65, 20);
            this.button15.TabIndex = 6;
            this.button15.Text = "M2";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button16.Location = new System.Drawing.Point(147, 18);
            this.button16.Margin = new System.Windows.Forms.Padding(0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(65, 20);
            this.button16.TabIndex = 5;
            this.button16.Text = "M1";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button14.Location = new System.Drawing.Point(82, 37);
            this.button14.Margin = new System.Windows.Forms.Padding(0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(65, 20);
            this.button14.TabIndex = 4;
            this.button14.Text = "M2";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button13.Location = new System.Drawing.Point(82, 18);
            this.button13.Margin = new System.Windows.Forms.Padding(0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(65, 20);
            this.button13.TabIndex = 3;
            this.button13.Text = "M1";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button12.Location = new System.Drawing.Point(4, 18);
            this.button12.Margin = new System.Windows.Forms.Padding(0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(77, 20);
            this.button12.TabIndex = 2;
            this.button12.Text = "Set macros";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(801, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.button31);
            this.groupBox10.Controls.Add(this.checkBox13);
            this.groupBox10.Controls.Add(this.textBox4);
            this.groupBox10.Location = new System.Drawing.Point(4, 722);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox10.Size = new System.Drawing.Size(793, 39);
            this.groupBox10.TabIndex = 17;
            this.groupBox10.TabStop = false;
            // 
            // button31
            // 
            this.button31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button31.Location = new System.Drawing.Point(710, 9);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(75, 20);
            this.button31.TabIndex = 2;
            this.button31.Text = "-> Send";
            this.button31.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox13.AutoSize = true;
            this.checkBox13.Location = new System.Drawing.Point(638, 12);
            this.checkBox13.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(67, 17);
            this.checkBox13.TabIndex = 1;
            this.checkBox13.Text = "+ CR/LF";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(0, 12);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(642, 20);
            this.textBox4.TabIndex = 0;
            // 
            // stopBitsCb
            // 
            this.stopBitsCb.Controls.Add(this.StopbitCb);
            this.stopBitsCb.Location = new System.Drawing.Point(341, 2);
            this.stopBitsCb.Name = "stopBitsCb";
            this.stopBitsCb.Size = new System.Drawing.Size(62, 70);
            this.stopBitsCb.TabIndex = 18;
            this.stopBitsCb.TabStop = false;
            this.stopBitsCb.Text = "Stop bits";
            // 
            // StopbitCb
            // 
            this.StopbitCb.FormattingEnabled = true;
            this.StopbitCb.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.StopbitCb.Location = new System.Drawing.Point(6, 19);
            this.StopbitCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StopbitCb.Name = "StopbitCb";
            this.StopbitCb.Size = new System.Drawing.Size(50, 21);
            this.StopbitCb.TabIndex = 20;
            // 
            // databitsCb
            // 
            this.databitsCb.Controls.Add(this.DatabitCb);
            this.databitsCb.Location = new System.Drawing.Point(188, 2);
            this.databitsCb.Name = "databitsCb";
            this.databitsCb.Size = new System.Drawing.Size(61, 70);
            this.databitsCb.TabIndex = 7;
            this.databitsCb.TabStop = false;
            this.databitsCb.Text = "Databits";
            // 
            // DatabitCb
            // 
            this.DatabitCb.FormattingEnabled = true;
            this.DatabitCb.Location = new System.Drawing.Point(4, 19);
            this.DatabitCb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DatabitCb.Name = "DatabitCb";
            this.DatabitCb.Size = new System.Drawing.Size(50, 21);
            this.DatabitCb.TabIndex = 19;
            // 
            // connectBtn
            // 
            this.connectBtn.Enabled = false;
            this.connectBtn.Location = new System.Drawing.Point(6, 41);
            this.connectBtn.Margin = new System.Windows.Forms.Padding(0);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 20);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // comPortCb
            // 
            this.comPortCb.FormattingEnabled = true;
            this.comPortCb.Location = new System.Drawing.Point(6, 19);
            this.comPortCb.Name = "comPortCb";
            this.comPortCb.Size = new System.Drawing.Size(73, 21);
            this.comPortCb.TabIndex = 6;
            this.comPortCb.DropDown += new System.EventHandler(this.ComPortCb_DropDown);
            this.comPortCb.SelectionChangeCommitted += new System.EventHandler(this.ComPortCb_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comPortCb);
            this.groupBox1.Controls.Add(this.connectBtn);
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(86, 70);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Com Ports";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.checkBox11);
            this.groupBox2.Controls.Add(this.checkBox12);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Location = new System.Drawing.Point(561, 75);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(233, 59);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Misc.";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(86, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Enable Echo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 135);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.receivedTb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sendBtn);
            this.splitContainer1.Panel2.Controls.Add(this.rawDataTb);
            this.splitContainer1.Size = new System.Drawing.Size(797, 556);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.TabIndex = 20;
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBtn.Location = new System.Drawing.Point(737, 3);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(58, 80);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "Send";
            this.sendBtn.UseVisualStyleBackColor = true;
            // 
            // rawDataTb
            // 
            this.rawDataTb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rawDataTb.Location = new System.Drawing.Point(0, 3);
            this.rawDataTb.Multiline = true;
            this.rawDataTb.Name = "rawDataTb";
            this.rawDataTb.Size = new System.Drawing.Size(736, 79);
            this.rawDataTb.TabIndex = 0;
            // 
            // MainTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 716);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.customBrTb);
            this.Controls.Add(this.stopBitsCb);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.handShakeGb);
            this.Controls.Add(this.parityGb);
            this.Controls.Add(this.databitsCb);
            this.Controls.Add(this.baudrateGb);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainTerminal";
            this.Text = "spo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.baudrateGb.ResumeLayout(false);
            this.parityGb.ResumeLayout(false);
            this.handShakeGb.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.stopBitsCb.ResumeLayout(false);
            this.databitsCb.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox baudrateGb;
        private System.Windows.Forms.GroupBox parityGb;
        private System.Windows.Forms.GroupBox handShakeGb;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TextBox customBrTb;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RadioButton RcvHexRb;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RadioButton RcvAsciiRb;
        private System.Windows.Forms.TextBox receivedTb;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox stopBitsCb;
        private System.Windows.Forms.ComboBox BaudrateCb;
        private System.Windows.Forms.ComboBox ParityCb;
        private System.Windows.Forms.ComboBox HandshakeCb;
        private System.Windows.Forms.ComboBox StopbitCb;
        private System.Windows.Forms.GroupBox databitsCb;
        private System.Windows.Forms.ComboBox DatabitCb;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.ComboBox comPortCb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox rawDataTb;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

