namespace AtomTerminal
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.txtTerm = new System.Windows.Forms.RichTextBox();
            this.grpConn = new System.Windows.Forms.GroupBox();
            this.chkEchoLog = new System.Windows.Forms.CheckBox();
            this.radLogTxt = new System.Windows.Forms.RadioButton();
            this.radLogBin = new System.Windows.Forms.RadioButton();
            this.chkEnLog = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.cmbFlow = new System.Windows.Forms.ComboBox();
            this.cmbStop = new System.Windows.Forms.ComboBox();
            this.cmbBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.lblLogFile = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.myCTRLBOX = new System.Windows.Forms.PictureBox();
            this.mySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.grpTR = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lblSentFile = new System.Windows.Forms.Label();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.chkEcho = new System.Windows.Forms.CheckBox();
            this.chkHex = new System.Windows.Forms.CheckBox();
            this.chkCR = new System.Windows.Forms.CheckBox();
            this.chkNL = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.grpRCV = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLG = new System.Windows.Forms.Button();
            this.btnSM = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.radHexAscii = new System.Windows.Forms.RadioButton();
            this.radHex = new System.Windows.Forms.RadioButton();
            this.radASCII = new System.Windows.Forms.RadioButton();
            this.grpConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myCTRLBOX)).BeginInit();
            this.grpTR.SuspendLayout();
            this.grpRCV.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTerm
            // 
            this.txtTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTerm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTerm.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerm.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtTerm.Location = new System.Drawing.Point(5, 29);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(955, 354);
            this.txtTerm.TabIndex = 0;
            this.txtTerm.Text = "";
            this.txtTerm.TextChanged += new System.EventHandler(this.txtTerm_TextChanged);
            // 
            // grpConn
            // 
            this.grpConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConn.Controls.Add(this.chkEchoLog);
            this.grpConn.Controls.Add(this.radLogTxt);
            this.grpConn.Controls.Add(this.radLogBin);
            this.grpConn.Controls.Add(this.chkEnLog);
            this.grpConn.Controls.Add(this.btnOpen);
            this.grpConn.Controls.Add(this.cmbFlow);
            this.grpConn.Controls.Add(this.cmbStop);
            this.grpConn.Controls.Add(this.cmbBits);
            this.grpConn.Controls.Add(this.cmbParity);
            this.grpConn.Controls.Add(this.cmbPorts);
            this.grpConn.Controls.Add(this.cmbBaud);
            this.grpConn.Controls.Add(this.lblLogFile);
            this.grpConn.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConn.ForeColor = System.Drawing.Color.LightGray;
            this.grpConn.Location = new System.Drawing.Point(5, 389);
            this.grpConn.Name = "grpConn";
            this.grpConn.Size = new System.Drawing.Size(952, 56);
            this.grpConn.TabIndex = 1;
            this.grpConn.TabStop = false;
            this.grpConn.Text = "Serial Configuration";
            this.grpConn.MouseHover += new System.EventHandler(this.grpConn_MouseHover);
            // 
            // chkEchoLog
            // 
            this.chkEchoLog.AutoSize = true;
            this.chkEchoLog.Location = new System.Drawing.Point(568, 33);
            this.chkEchoLog.Name = "chkEchoLog";
            this.chkEchoLog.Size = new System.Drawing.Size(99, 20);
            this.chkEchoLog.TabIndex = 18;
            this.chkEchoLog.Text = "Log Echos";
            this.chkEchoLog.UseVisualStyleBackColor = true;
            this.chkEchoLog.CheckedChanged += new System.EventHandler(this.chkEchoLog_CheckedChanged);
            // 
            // radLogTxt
            // 
            this.radLogTxt.AutoSize = true;
            this.radLogTxt.BackColor = System.Drawing.Color.Transparent;
            this.radLogTxt.Checked = true;
            this.radLogTxt.Location = new System.Drawing.Point(822, 13);
            this.radLogTxt.Name = "radLogTxt";
            this.radLogTxt.Size = new System.Drawing.Size(90, 20);
            this.radLogTxt.TabIndex = 17;
            this.radLogTxt.TabStop = true;
            this.radLogTxt.Text = "Log Text";
            this.radLogTxt.UseVisualStyleBackColor = false;
            // 
            // radLogBin
            // 
            this.radLogBin.AutoSize = true;
            this.radLogBin.BackColor = System.Drawing.Color.Transparent;
            this.radLogBin.Location = new System.Drawing.Point(713, 13);
            this.radLogBin.Name = "radLogBin";
            this.radLogBin.Size = new System.Drawing.Size(106, 20);
            this.radLogBin.TabIndex = 16;
            this.radLogBin.Text = "Log Binary";
            this.radLogBin.UseVisualStyleBackColor = false;
            // 
            // chkEnLog
            // 
            this.chkEnLog.AutoSize = true;
            this.chkEnLog.BackColor = System.Drawing.Color.Transparent;
            this.chkEnLog.Location = new System.Drawing.Point(568, 13);
            this.chkEnLog.Name = "chkEnLog";
            this.chkEnLog.Size = new System.Drawing.Size(139, 20);
            this.chkEnLog.TabIndex = 15;
            this.chkEnLog.Text = "Enable Logging";
            this.chkEnLog.UseVisualStyleBackColor = false;
            this.chkEnLog.CheckedChanged += new System.EventHandler(this.chkEnLog_CheckedChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpen.Location = new System.Drawing.Point(439, 22);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(85, 24);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Connect";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cmbFlow
            // 
            this.cmbFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFlow.FormattingEnabled = true;
            this.cmbFlow.Items.AddRange(new object[] {
            "None",
            "RTS/CTS",
            "DTR/DSR"});
            this.cmbFlow.Location = new System.Drawing.Point(341, 22);
            this.cmbFlow.Name = "cmbFlow";
            this.cmbFlow.Size = new System.Drawing.Size(82, 24);
            this.cmbFlow.TabIndex = 5;
            this.cmbFlow.Text = "None";
            this.cmbFlow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbFlow_MouseMove);
            // 
            // cmbStop
            // 
            this.cmbStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStop.FormattingEnabled = true;
            this.cmbStop.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cmbStop.Location = new System.Drawing.Point(293, 22);
            this.cmbStop.Name = "cmbStop";
            this.cmbStop.Size = new System.Drawing.Size(42, 24);
            this.cmbStop.TabIndex = 4;
            this.cmbStop.Text = "1";
            this.cmbStop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbStop_MouseMove);
            // 
            // cmbBits
            // 
            this.cmbBits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBits.FormattingEnabled = true;
            this.cmbBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cmbBits.Location = new System.Drawing.Point(175, 22);
            this.cmbBits.Name = "cmbBits";
            this.cmbBits.Size = new System.Drawing.Size(42, 24);
            this.cmbBits.TabIndex = 3;
            this.cmbBits.Text = "8";
            this.cmbBits.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbBits_MouseMove);
            // 
            // cmbParity
            // 
            this.cmbParity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cmbParity.Location = new System.Drawing.Point(223, 22);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(64, 24);
            this.cmbParity.TabIndex = 2;
            this.cmbParity.Text = "None";
            this.cmbParity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbParity_MouseMove);
            // 
            // cmbPorts
            // 
            this.cmbPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(7, 22);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(78, 24);
            this.cmbPorts.TabIndex = 1;
            this.cmbPorts.SelectedIndexChanged += new System.EventHandler(this.cmbPorts_SelectedIndexChanged);
            this.cmbPorts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbPorts_MouseMove);
            // 
            // cmbBaud
            // 
            this.cmbBaud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cmbBaud.Location = new System.Drawing.Point(91, 22);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(78, 24);
            this.cmbBaud.TabIndex = 0;
            this.cmbBaud.Text = "9600";
            this.cmbBaud.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cmbBaud_MouseMove);
            // 
            // lblLogFile
            // 
            this.lblLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogFile.AutoSize = true;
            this.lblLogFile.BackColor = System.Drawing.Color.Transparent;
            this.lblLogFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblLogFile.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblLogFile.Location = new System.Drawing.Point(712, 33);
            this.lblLogFile.Name = "lblLogFile";
            this.lblLogFile.Size = new System.Drawing.Size(104, 16);
            this.lblLogFile.TabIndex = 14;
            this.lblLogFile.Text = "Log File: NA";
            this.lblLogFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTitle.Location = new System.Drawing.Point(9, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(951, 24);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "AtomTerminal - No Connection";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // myCTRLBOX
            // 
            this.myCTRLBOX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.myCTRLBOX.Image = ((System.Drawing.Image)(resources.GetObject("myCTRLBOX.Image")));
            this.myCTRLBOX.Location = new System.Drawing.Point(857, 4);
            this.myCTRLBOX.Name = "myCTRLBOX";
            this.myCTRLBOX.Size = new System.Drawing.Size(99, 24);
            this.myCTRLBOX.TabIndex = 2;
            this.myCTRLBOX.TabStop = false;
            this.myCTRLBOX.Click += new System.EventHandler(this.myCTRLBOX_Click);
            this.myCTRLBOX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myCTRLBOX_MouseClick);
            this.myCTRLBOX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myCTRLBOX_MouseDown);
            this.myCTRLBOX.MouseLeave += new System.EventHandler(this.myCTRLBOX_MouseLeave);
            this.myCTRLBOX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myCTRLBOX_MouseMove);
            // 
            // mySerialPort
            // 
            this.mySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.mySerialPort_DataReceived);
            // 
            // grpTR
            // 
            this.grpTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTR.Controls.Add(this.radioButton1);
            this.grpTR.Controls.Add(this.radioButton2);
            this.grpTR.Controls.Add(this.lblSentFile);
            this.grpTR.Controls.Add(this.btnSendFile);
            this.grpTR.Controls.Add(this.chkEcho);
            this.grpTR.Controls.Add(this.chkHex);
            this.grpTR.Controls.Add(this.chkCR);
            this.grpTR.Controls.Add(this.chkNL);
            this.grpTR.Controls.Add(this.btnSend);
            this.grpTR.Controls.Add(this.txtSend);
            this.grpTR.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.grpTR.ForeColor = System.Drawing.Color.LightGray;
            this.grpTR.Location = new System.Drawing.Point(6, 453);
            this.grpTR.Name = "grpTR";
            this.grpTR.Size = new System.Drawing.Size(952, 60);
            this.grpTR.TabIndex = 4;
            this.grpTR.TabStop = false;
            this.grpTR.Text = "Transmit";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Location = new System.Drawing.Point(836, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(114, 20);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.Text = "Open Binary";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(736, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(98, 20);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Open Text";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // lblSentFile
            // 
            this.lblSentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSentFile.AutoSize = true;
            this.lblSentFile.BackColor = System.Drawing.Color.Transparent;
            this.lblSentFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSentFile.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSentFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblSentFile.Location = new System.Drawing.Point(733, 40);
            this.lblSentFile.Name = "lblSentFile";
            this.lblSentFile.Size = new System.Drawing.Size(112, 16);
            this.lblSentFile.TabIndex = 13;
            this.lblSentFile.Text = "Last File: NA";
            this.lblSentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.Transparent;
            this.btnSendFile.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSendFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSendFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFile.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendFile.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSendFile.Location = new System.Drawing.Point(625, 22);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(100, 23);
            this.btnSendFile.TabIndex = 12;
            this.btnSendFile.Text = "Open/Send";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // chkEcho
            // 
            this.chkEcho.AutoSize = true;
            this.chkEcho.BackColor = System.Drawing.Color.Transparent;
            this.chkEcho.Location = new System.Drawing.Point(549, 25);
            this.chkEcho.Name = "chkEcho";
            this.chkEcho.Size = new System.Drawing.Size(59, 20);
            this.chkEcho.TabIndex = 11;
            this.chkEcho.Text = "Echo";
            this.chkEcho.UseVisualStyleBackColor = false;
            // 
            // chkHex
            // 
            this.chkHex.AutoSize = true;
            this.chkHex.BackColor = System.Drawing.Color.Transparent;
            this.chkHex.Location = new System.Drawing.Point(492, 25);
            this.chkHex.Name = "chkHex";
            this.chkHex.Size = new System.Drawing.Size(51, 20);
            this.chkHex.TabIndex = 10;
            this.chkHex.Text = "Hex";
            this.chkHex.UseVisualStyleBackColor = false;
            // 
            // chkCR
            // 
            this.chkCR.AutoSize = true;
            this.chkCR.BackColor = System.Drawing.Color.Transparent;
            this.chkCR.Location = new System.Drawing.Point(443, 25);
            this.chkCR.Name = "chkCR";
            this.chkCR.Size = new System.Drawing.Size(43, 20);
            this.chkCR.TabIndex = 9;
            this.chkCR.Text = "\\r";
            this.chkCR.UseVisualStyleBackColor = false;
            // 
            // chkNL
            // 
            this.chkNL.AutoSize = true;
            this.chkNL.BackColor = System.Drawing.Color.Transparent;
            this.chkNL.Location = new System.Drawing.Point(394, 25);
            this.chkNL.Name = "chkNL";
            this.chkNL.Size = new System.Drawing.Size(43, 20);
            this.chkNL.TabIndex = 8;
            this.chkNL.Text = "\\n";
            this.chkNL.UseVisualStyleBackColor = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSend.Location = new System.Drawing.Point(292, 23);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(7, 23);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(279, 23);
            this.txtSend.TabIndex = 0;
            // 
            // grpRCV
            // 
            this.grpRCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRCV.Controls.Add(this.label1);
            this.grpRCV.Controls.Add(this.btnLG);
            this.grpRCV.Controls.Add(this.btnSM);
            this.grpRCV.Controls.Add(this.button1);
            this.grpRCV.Controls.Add(this.radHexAscii);
            this.grpRCV.Controls.Add(this.radHex);
            this.grpRCV.Controls.Add(this.radASCII);
            this.grpRCV.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.grpRCV.ForeColor = System.Drawing.Color.LightGray;
            this.grpRCV.Location = new System.Drawing.Point(6, 523);
            this.grpRCV.Name = "grpRCV";
            this.grpRCV.Size = new System.Drawing.Size(951, 70);
            this.grpRCV.TabIndex = 13;
            this.grpRCV.TabStop = false;
            this.grpRCV.Text = "View";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(219, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Text Size";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLG
            // 
            this.btnLG.BackColor = System.Drawing.Color.Transparent;
            this.btnLG.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnLG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLG.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLG.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLG.Location = new System.Drawing.Point(259, 38);
            this.btnLG.Name = "btnLG";
            this.btnLG.Size = new System.Drawing.Size(30, 23);
            this.btnLG.TabIndex = 10;
            this.btnLG.Text = "+";
            this.btnLG.UseVisualStyleBackColor = false;
            this.btnLG.Click += new System.EventHandler(this.btnLG_Click);
            // 
            // btnSM
            // 
            this.btnSM.BackColor = System.Drawing.Color.Transparent;
            this.btnSM.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSM.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSM.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSM.Location = new System.Drawing.Point(222, 38);
            this.btnSM.Name = "btnSM";
            this.btnSM.Size = new System.Drawing.Size(30, 23);
            this.btnSM.TabIndex = 9;
            this.btnSM.Text = "-";
            this.btnSM.UseVisualStyleBackColor = false;
            this.btnSM.Click += new System.EventHandler(this.btnSM_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(305, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear Term";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radHexAscii
            // 
            this.radHexAscii.AutoSize = true;
            this.radHexAscii.BackColor = System.Drawing.Color.Transparent;
            this.radHexAscii.Location = new System.Drawing.Point(90, 22);
            this.radHexAscii.Name = "radHexAscii";
            this.radHexAscii.Size = new System.Drawing.Size(114, 20);
            this.radHexAscii.TabIndex = 2;
            this.radHexAscii.Text = "Hex+[ASCII]";
            this.radHexAscii.UseVisualStyleBackColor = false;
            // 
            // radHex
            // 
            this.radHex.AutoSize = true;
            this.radHex.BackColor = System.Drawing.Color.Transparent;
            this.radHex.Location = new System.Drawing.Point(18, 44);
            this.radHex.Name = "radHex";
            this.radHex.Size = new System.Drawing.Size(50, 20);
            this.radHex.TabIndex = 1;
            this.radHex.Text = "Hex";
            this.radHex.UseVisualStyleBackColor = false;
            // 
            // radASCII
            // 
            this.radASCII.AutoSize = true;
            this.radASCII.BackColor = System.Drawing.Color.Transparent;
            this.radASCII.Checked = true;
            this.radASCII.Location = new System.Drawing.Point(18, 22);
            this.radASCII.Name = "radASCII";
            this.radASCII.Size = new System.Drawing.Size(66, 20);
            this.radASCII.TabIndex = 0;
            this.radASCII.TabStop = true;
            this.radASCII.Text = "Ascii";
            this.radASCII.UseVisualStyleBackColor = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(964, 600);
            this.Controls.Add(this.grpConn);
            this.Controls.Add(this.grpRCV);
            this.Controls.Add(this.grpTR);
            this.Controls.Add(this.myCTRLBOX);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtomTerminal";
            this.Load += new System.EventHandler(this.main_Load);
            this.Resize += new System.EventHandler(this.main_Resize);
            this.grpConn.ResumeLayout(false);
            this.grpConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myCTRLBOX)).EndInit();
            this.grpTR.ResumeLayout(false);
            this.grpTR.PerformLayout();
            this.grpRCV.ResumeLayout(false);
            this.grpRCV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtTerm;
        private System.Windows.Forms.GroupBox grpConn;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbPorts;
        private System.Windows.Forms.ComboBox cmbBits;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbStop;
        private System.Windows.Forms.PictureBox myCTRLBOX;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbFlow;
        private System.Windows.Forms.Button btnOpen;
        private System.IO.Ports.SerialPort mySerialPort;
        private System.Windows.Forms.GroupBox grpTR;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.CheckBox chkCR;
        private System.Windows.Forms.CheckBox chkNL;
        private System.Windows.Forms.CheckBox chkHex;
        private System.Windows.Forms.CheckBox chkEcho;
        private System.Windows.Forms.GroupBox grpRCV;
        private System.Windows.Forms.RadioButton radHexAscii;
        private System.Windows.Forms.RadioButton radHex;
        private System.Windows.Forms.RadioButton radASCII;
        private System.Windows.Forms.Label lblSentFile;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.RadioButton radLogTxt;
        private System.Windows.Forms.RadioButton radLogBin;
        private System.Windows.Forms.CheckBox chkEnLog;
        private System.Windows.Forms.Label lblLogFile;
        private System.Windows.Forms.CheckBox chkEchoLog;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLG;
        private System.Windows.Forms.Button btnSM;
    }
}

