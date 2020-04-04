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
            this.TxtTerm = new System.Windows.Forms.RichTextBox();
            this.GrpConn = new System.Windows.Forms.GroupBox();
            this.ChkEchoLog = new System.Windows.Forms.CheckBox();
            this.radLogTxt = new System.Windows.Forms.RadioButton();
            this.radLogBin = new System.Windows.Forms.RadioButton();
            this.ChkEnLog = new System.Windows.Forms.CheckBox();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.CmbFlow = new System.Windows.Forms.ComboBox();
            this.CmbStop = new System.Windows.Forms.ComboBox();
            this.CmbBits = new System.Windows.Forms.ComboBox();
            this.CmbParity = new System.Windows.Forms.ComboBox();
            this.CmbPorts = new System.Windows.Forms.ComboBox();
            this.CmbBaud = new System.Windows.Forms.ComboBox();
            this.LblLogFile = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.MyCTRLBOX = new System.Windows.Forms.PictureBox();
            this.MySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.GrpTR = new System.Windows.Forms.GroupBox();
            this.radOpenBin = new System.Windows.Forms.RadioButton();
            this.radOpenTxt = new System.Windows.Forms.RadioButton();
            this.LblSentFile = new System.Windows.Forms.Label();
            this.BtnSendFile = new System.Windows.Forms.Button();
            this.ChkEcho = new System.Windows.Forms.CheckBox();
            this.ChkHex = new System.Windows.Forms.CheckBox();
            this.ChkCR = new System.Windows.Forms.CheckBox();
            this.ChkNL = new System.Windows.Forms.CheckBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.GrpRCV = new System.Windows.Forms.GroupBox();
            this.BtnBold = new System.Windows.Forms.Button();
            this.BtnFGColor = new System.Windows.Forms.Button();
            this.BtnBGColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLG = new System.Windows.Forms.Button();
            this.BtnSM = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.radHexAscii = new System.Windows.Forms.RadioButton();
            this.radHex = new System.Windows.Forms.RadioButton();
            this.radASCII = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnSaveAST = new System.Windows.Forms.Button();
            this.btnOpenAST = new System.Windows.Forms.Button();
            this.GrpConn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyCTRLBOX)).BeginInit();
            this.GrpTR.SuspendLayout();
            this.GrpRCV.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtTerm
            // 
            this.TxtTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTerm.BackColor = System.Drawing.Color.SlateGray;
            this.TxtTerm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTerm.DetectUrls = false;
            this.TxtTerm.Font = new System.Drawing.Font("Courier New", 12F);
            this.TxtTerm.ForeColor = System.Drawing.SystemColors.Menu;
            this.TxtTerm.Location = new System.Drawing.Point(5, 29);
            this.TxtTerm.Name = "TxtTerm";
            this.TxtTerm.Size = new System.Drawing.Size(988, 354);
            this.TxtTerm.TabIndex = 0;
            this.TxtTerm.Text = "";
            this.TxtTerm.TextChanged += new System.EventHandler(this.TxtTerm_TextChanged);
            // 
            // GrpConn
            // 
            this.GrpConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpConn.Controls.Add(this.ChkEchoLog);
            this.GrpConn.Controls.Add(this.radLogTxt);
            this.GrpConn.Controls.Add(this.radLogBin);
            this.GrpConn.Controls.Add(this.ChkEnLog);
            this.GrpConn.Controls.Add(this.BtnOpen);
            this.GrpConn.Controls.Add(this.CmbFlow);
            this.GrpConn.Controls.Add(this.CmbStop);
            this.GrpConn.Controls.Add(this.CmbBits);
            this.GrpConn.Controls.Add(this.CmbParity);
            this.GrpConn.Controls.Add(this.CmbPorts);
            this.GrpConn.Controls.Add(this.CmbBaud);
            this.GrpConn.Controls.Add(this.LblLogFile);
            this.GrpConn.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpConn.ForeColor = System.Drawing.Color.LightGray;
            this.GrpConn.Location = new System.Drawing.Point(5, 389);
            this.GrpConn.Name = "GrpConn";
            this.GrpConn.Size = new System.Drawing.Size(985, 56);
            this.GrpConn.TabIndex = 1;
            this.GrpConn.TabStop = false;
            this.GrpConn.Text = "Serial Configuration";
            this.GrpConn.MouseHover += new System.EventHandler(this.GrpConn_MouseHover);
            // 
            // ChkEchoLog
            // 
            this.ChkEchoLog.AutoSize = true;
            this.ChkEchoLog.Location = new System.Drawing.Point(568, 33);
            this.ChkEchoLog.Name = "ChkEchoLog";
            this.ChkEchoLog.Size = new System.Drawing.Size(99, 20);
            this.ChkEchoLog.TabIndex = 18;
            this.ChkEchoLog.Text = "Log Echos";
            this.ChkEchoLog.UseVisualStyleBackColor = true;
            this.ChkEchoLog.CheckedChanged += new System.EventHandler(this.ChkEchoLog_CheckedChanged);
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
            // ChkEnLog
            // 
            this.ChkEnLog.AutoSize = true;
            this.ChkEnLog.BackColor = System.Drawing.Color.Transparent;
            this.ChkEnLog.Location = new System.Drawing.Point(568, 13);
            this.ChkEnLog.Name = "ChkEnLog";
            this.ChkEnLog.Size = new System.Drawing.Size(139, 20);
            this.ChkEnLog.TabIndex = 15;
            this.ChkEnLog.Text = "Enable Logging";
            this.ChkEnLog.UseVisualStyleBackColor = false;
            this.ChkEnLog.CheckedChanged += new System.EventHandler(this.ChkEnLog_CheckedChanged);
            this.ChkEnLog.Click += new System.EventHandler(this.ChkEnLog_Click);
            // 
            // BtnOpen
            // 
            this.BtnOpen.BackColor = System.Drawing.Color.Transparent;
            this.BtnOpen.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpen.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnOpen.Location = new System.Drawing.Point(439, 22);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(85, 24);
            this.BtnOpen.TabIndex = 6;
            this.BtnOpen.Text = "Connect";
            this.BtnOpen.UseVisualStyleBackColor = false;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // CmbFlow
            // 
            this.CmbFlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbFlow.FormattingEnabled = true;
            this.CmbFlow.Items.AddRange(new object[] {
            "None",
            "RTS/CTS",
            "DTR/DSR"});
            this.CmbFlow.Location = new System.Drawing.Point(341, 22);
            this.CmbFlow.Name = "CmbFlow";
            this.CmbFlow.Size = new System.Drawing.Size(82, 24);
            this.CmbFlow.TabIndex = 5;
            this.CmbFlow.Text = "None";
            this.CmbFlow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CmbFlow_MouseMove);
            // 
            // CmbStop
            // 
            this.CmbStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbStop.FormattingEnabled = true;
            this.CmbStop.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.CmbStop.Location = new System.Drawing.Point(293, 22);
            this.CmbStop.Name = "CmbStop";
            this.CmbStop.Size = new System.Drawing.Size(42, 24);
            this.CmbStop.TabIndex = 4;
            this.CmbStop.Text = "1";
            this.CmbStop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CmbStop_MouseMove);
            // 
            // CmbBits
            // 
            this.CmbBits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbBits.FormattingEnabled = true;
            this.CmbBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.CmbBits.Location = new System.Drawing.Point(175, 22);
            this.CmbBits.Name = "CmbBits";
            this.CmbBits.Size = new System.Drawing.Size(42, 24);
            this.CmbBits.TabIndex = 3;
            this.CmbBits.Text = "8";
            this.CmbBits.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CmbBits_MouseMove);
            // 
            // CmbParity
            // 
            this.CmbParity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbParity.FormattingEnabled = true;
            this.CmbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.CmbParity.Location = new System.Drawing.Point(223, 22);
            this.CmbParity.Name = "CmbParity";
            this.CmbParity.Size = new System.Drawing.Size(64, 24);
            this.CmbParity.TabIndex = 2;
            this.CmbParity.Text = "None";
            this.CmbParity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CmbParity_MouseMove);
            // 
            // CmbPorts
            // 
            this.CmbPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbPorts.FormattingEnabled = true;
            this.CmbPorts.Location = new System.Drawing.Point(7, 22);
            this.CmbPorts.Name = "CmbPorts";
            this.CmbPorts.Size = new System.Drawing.Size(78, 24);
            this.CmbPorts.TabIndex = 1;
            this.CmbPorts.SelectedIndexChanged += new System.EventHandler(this.CmbPorts_SelectedIndexChanged);
            this.CmbPorts.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CmbPorts_MouseMove);
            // 
            // CmbBaud
            // 
            this.CmbBaud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbBaud.FormattingEnabled = true;
            this.CmbBaud.Items.AddRange(new object[] {
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
            this.CmbBaud.Location = new System.Drawing.Point(91, 22);
            this.CmbBaud.Name = "CmbBaud";
            this.CmbBaud.Size = new System.Drawing.Size(78, 24);
            this.CmbBaud.TabIndex = 0;
            this.CmbBaud.Text = "9600";
            this.CmbBaud.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CmbBaud_MouseMove);
            // 
            // LblLogFile
            // 
            this.LblLogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblLogFile.AutoSize = true;
            this.LblLogFile.BackColor = System.Drawing.Color.Transparent;
            this.LblLogFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblLogFile.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblLogFile.Location = new System.Drawing.Point(712, 33);
            this.LblLogFile.Name = "LblLogFile";
            this.LblLogFile.Size = new System.Drawing.Size(104, 16);
            this.LblLogFile.TabIndex = 14;
            this.LblLogFile.Text = "Log File: NA";
            this.LblLogFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitle
            // 
            this.LblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblTitle.Location = new System.Drawing.Point(9, 2);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(984, 24);
            this.LblTitle.TabIndex = 3;
            this.LblTitle.Text = "AtomTerminal - No Connection";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTitle.DoubleClick += new System.EventHandler(this.LblTitle_DoubleClick);
            this.LblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblTitle_MouseDown);
            // 
            // MyCTRLBOX
            // 
            this.MyCTRLBOX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MyCTRLBOX.Image = ((System.Drawing.Image)(resources.GetObject("MyCTRLBOX.Image")));
            this.MyCTRLBOX.Location = new System.Drawing.Point(873, 4);
            this.MyCTRLBOX.Name = "MyCTRLBOX";
            this.MyCTRLBOX.Size = new System.Drawing.Size(99, 24);
            this.MyCTRLBOX.TabIndex = 2;
            this.MyCTRLBOX.TabStop = false;
            this.MyCTRLBOX.Click += new System.EventHandler(this.MyCTRLBOX_Click);
            this.MyCTRLBOX.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MyCTRLBOX_MouseClick);
            this.MyCTRLBOX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MyCTRLBOX_MouseDown);
            this.MyCTRLBOX.MouseLeave += new System.EventHandler(this.MyCTRLBOX_MouseLeave);
            this.MyCTRLBOX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyCTRLBOX_MouseMove);
            // 
            // MySerialPort
            // 
            this.MySerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MySerialPort_DataReceived);
            // 
            // GrpTR
            // 
            this.GrpTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpTR.Controls.Add(this.radOpenBin);
            this.GrpTR.Controls.Add(this.radOpenTxt);
            this.GrpTR.Controls.Add(this.LblSentFile);
            this.GrpTR.Controls.Add(this.BtnSendFile);
            this.GrpTR.Controls.Add(this.ChkEcho);
            this.GrpTR.Controls.Add(this.ChkHex);
            this.GrpTR.Controls.Add(this.ChkCR);
            this.GrpTR.Controls.Add(this.ChkNL);
            this.GrpTR.Controls.Add(this.BtnSend);
            this.GrpTR.Controls.Add(this.txtSend);
            this.GrpTR.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.GrpTR.ForeColor = System.Drawing.Color.LightGray;
            this.GrpTR.Location = new System.Drawing.Point(6, 453);
            this.GrpTR.Name = "GrpTR";
            this.GrpTR.Size = new System.Drawing.Size(985, 60);
            this.GrpTR.TabIndex = 4;
            this.GrpTR.TabStop = false;
            this.GrpTR.Text = "Transmit";
            // 
            // radOpenBin
            // 
            this.radOpenBin.AutoSize = true;
            this.radOpenBin.BackColor = System.Drawing.Color.Transparent;
            this.radOpenBin.Location = new System.Drawing.Point(836, 18);
            this.radOpenBin.Name = "radOpenBin";
            this.radOpenBin.Size = new System.Drawing.Size(114, 20);
            this.radOpenBin.TabIndex = 19;
            this.radOpenBin.Text = "Open Binary";
            this.radOpenBin.UseVisualStyleBackColor = false;
            // 
            // radOpenTxt
            // 
            this.radOpenTxt.AutoSize = true;
            this.radOpenTxt.BackColor = System.Drawing.Color.Transparent;
            this.radOpenTxt.Checked = true;
            this.radOpenTxt.Location = new System.Drawing.Point(736, 18);
            this.radOpenTxt.Name = "radOpenTxt";
            this.radOpenTxt.Size = new System.Drawing.Size(98, 20);
            this.radOpenTxt.TabIndex = 18;
            this.radOpenTxt.TabStop = true;
            this.radOpenTxt.Text = "Open Text";
            this.radOpenTxt.UseVisualStyleBackColor = false;
            // 
            // LblSentFile
            // 
            this.LblSentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSentFile.AutoSize = true;
            this.LblSentFile.BackColor = System.Drawing.Color.Transparent;
            this.LblSentFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblSentFile.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSentFile.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LblSentFile.Location = new System.Drawing.Point(733, 40);
            this.LblSentFile.Name = "LblSentFile";
            this.LblSentFile.Size = new System.Drawing.Size(112, 16);
            this.LblSentFile.TabIndex = 13;
            this.LblSentFile.Text = "Last File: NA";
            this.LblSentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnSendFile
            // 
            this.BtnSendFile.BackColor = System.Drawing.Color.Transparent;
            this.BtnSendFile.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnSendFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnSendFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSendFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSendFile.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSendFile.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSendFile.Location = new System.Drawing.Point(625, 22);
            this.BtnSendFile.Name = "BtnSendFile";
            this.BtnSendFile.Size = new System.Drawing.Size(100, 23);
            this.BtnSendFile.TabIndex = 12;
            this.BtnSendFile.Text = "Open/Send";
            this.BtnSendFile.UseVisualStyleBackColor = false;
            this.BtnSendFile.Click += new System.EventHandler(this.BtnSendFile_Click);
            // 
            // ChkEcho
            // 
            this.ChkEcho.AutoSize = true;
            this.ChkEcho.BackColor = System.Drawing.Color.Transparent;
            this.ChkEcho.Location = new System.Drawing.Point(549, 25);
            this.ChkEcho.Name = "ChkEcho";
            this.ChkEcho.Size = new System.Drawing.Size(59, 20);
            this.ChkEcho.TabIndex = 11;
            this.ChkEcho.Text = "Echo";
            this.ChkEcho.UseVisualStyleBackColor = false;
            // 
            // ChkHex
            // 
            this.ChkHex.AutoSize = true;
            this.ChkHex.BackColor = System.Drawing.Color.Transparent;
            this.ChkHex.Location = new System.Drawing.Point(492, 25);
            this.ChkHex.Name = "ChkHex";
            this.ChkHex.Size = new System.Drawing.Size(51, 20);
            this.ChkHex.TabIndex = 10;
            this.ChkHex.Text = "Hex";
            this.ChkHex.UseVisualStyleBackColor = false;
            // 
            // ChkCR
            // 
            this.ChkCR.AutoSize = true;
            this.ChkCR.BackColor = System.Drawing.Color.Transparent;
            this.ChkCR.Location = new System.Drawing.Point(443, 25);
            this.ChkCR.Name = "ChkCR";
            this.ChkCR.Size = new System.Drawing.Size(43, 20);
            this.ChkCR.TabIndex = 9;
            this.ChkCR.Text = "\\r";
            this.ChkCR.UseVisualStyleBackColor = false;
            // 
            // ChkNL
            // 
            this.ChkNL.AutoSize = true;
            this.ChkNL.BackColor = System.Drawing.Color.Transparent;
            this.ChkNL.Location = new System.Drawing.Point(394, 25);
            this.ChkNL.Name = "ChkNL";
            this.ChkNL.Size = new System.Drawing.Size(43, 20);
            this.ChkNL.TabIndex = 8;
            this.ChkNL.Text = "\\n";
            this.ChkNL.UseVisualStyleBackColor = false;
            // 
            // BtnSend
            // 
            this.BtnSend.BackColor = System.Drawing.Color.Transparent;
            this.BtnSend.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSend.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSend.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSend.Location = new System.Drawing.Point(292, 23);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(85, 23);
            this.BtnSend.TabIndex = 7;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = false;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(7, 23);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(279, 23);
            this.txtSend.TabIndex = 0;
            // 
            // GrpRCV
            // 
            this.GrpRCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpRCV.Controls.Add(this.btnOpenAST);
            this.GrpRCV.Controls.Add(this.btnSaveAST);
            this.GrpRCV.Controls.Add(this.BtnBold);
            this.GrpRCV.Controls.Add(this.BtnFGColor);
            this.GrpRCV.Controls.Add(this.BtnBGColor);
            this.GrpRCV.Controls.Add(this.label1);
            this.GrpRCV.Controls.Add(this.BtnLG);
            this.GrpRCV.Controls.Add(this.BtnSM);
            this.GrpRCV.Controls.Add(this.Button1);
            this.GrpRCV.Controls.Add(this.radHexAscii);
            this.GrpRCV.Controls.Add(this.radHex);
            this.GrpRCV.Controls.Add(this.radASCII);
            this.GrpRCV.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.GrpRCV.ForeColor = System.Drawing.Color.LightGray;
            this.GrpRCV.Location = new System.Drawing.Point(6, 523);
            this.GrpRCV.Name = "GrpRCV";
            this.GrpRCV.Size = new System.Drawing.Size(984, 70);
            this.GrpRCV.TabIndex = 13;
            this.GrpRCV.TabStop = false;
            this.GrpRCV.Text = "View";
            // 
            // BtnBold
            // 
            this.BtnBold.BackColor = System.Drawing.Color.Transparent;
            this.BtnBold.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnBold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnBold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBold.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBold.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnBold.Location = new System.Drawing.Point(674, 38);
            this.BtnBold.Name = "BtnBold";
            this.BtnBold.Size = new System.Drawing.Size(60, 23);
            this.BtnBold.TabIndex = 17;
            this.BtnBold.Text = "BOLD";
            this.BtnBold.UseVisualStyleBackColor = false;
            this.BtnBold.Click += new System.EventHandler(this.BtnBold_Click);
            // 
            // BtnFGColor
            // 
            this.BtnFGColor.BackColor = System.Drawing.Color.Transparent;
            this.BtnFGColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnFGColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnFGColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnFGColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFGColor.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFGColor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnFGColor.Location = new System.Drawing.Point(551, 38);
            this.BtnFGColor.Name = "BtnFGColor";
            this.BtnFGColor.Size = new System.Drawing.Size(117, 23);
            this.BtnFGColor.TabIndex = 16;
            this.BtnFGColor.Text = "FG Color";
            this.BtnFGColor.UseVisualStyleBackColor = false;
            this.BtnFGColor.Click += new System.EventHandler(this.BtnFGColor_Click);
            // 
            // BtnBGColor
            // 
            this.BtnBGColor.BackColor = System.Drawing.Color.Transparent;
            this.BtnBGColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnBGColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnBGColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnBGColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBGColor.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBGColor.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnBGColor.Location = new System.Drawing.Point(428, 38);
            this.BtnBGColor.Name = "BtnBGColor";
            this.BtnBGColor.Size = new System.Drawing.Size(117, 23);
            this.BtnBGColor.TabIndex = 15;
            this.BtnBGColor.Text = "BG Color";
            this.BtnBGColor.UseVisualStyleBackColor = false;
            this.BtnBGColor.Click += new System.EventHandler(this.BtnBGColor_Click);
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
            this.label1.Location = new System.Drawing.Point(342, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Text Size";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnLG
            // 
            this.BtnLG.BackColor = System.Drawing.Color.Transparent;
            this.BtnLG.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnLG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnLG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnLG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLG.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLG.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnLG.Location = new System.Drawing.Point(384, 38);
            this.BtnLG.Name = "BtnLG";
            this.BtnLG.Size = new System.Drawing.Size(30, 23);
            this.BtnLG.TabIndex = 10;
            this.BtnLG.Text = "+";
            this.BtnLG.UseVisualStyleBackColor = false;
            this.BtnLG.Click += new System.EventHandler(this.BtnLG_Click);
            // 
            // BtnSM
            // 
            this.BtnSM.BackColor = System.Drawing.Color.Transparent;
            this.BtnSM.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnSM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.BtnSM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BtnSM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSM.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSM.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSM.Location = new System.Drawing.Point(347, 38);
            this.BtnSM.Name = "BtnSM";
            this.BtnSM.Size = new System.Drawing.Size(30, 23);
            this.BtnSM.TabIndex = 9;
            this.BtnSM.Text = "-";
            this.BtnSM.UseVisualStyleBackColor = false;
            this.BtnSM.Click += new System.EventHandler(this.BtnSM_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.Transparent;
            this.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Button1.Location = new System.Drawing.Point(210, 22);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(117, 39);
            this.Button1.TabIndex = 8;
            this.Button1.Text = "Clear Term";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
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
            // btnSaveAST
            // 
            this.btnSaveAST.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveAST.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSaveAST.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSaveAST.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveAST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAST.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAST.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAST.Location = new System.Drawing.Point(755, 14);
            this.btnSaveAST.Name = "btnSaveAST";
            this.btnSaveAST.Size = new System.Drawing.Size(90, 47);
            this.btnSaveAST.TabIndex = 18;
            this.btnSaveAST.Text = "Save AST";
            this.btnSaveAST.UseVisualStyleBackColor = false;
            this.btnSaveAST.Click += new System.EventHandler(this.btnSaveAST_Click);
            // 
            // btnOpenAST
            // 
            this.btnOpenAST.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenAST.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnOpenAST.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnOpenAST.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpenAST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenAST.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenAST.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnOpenAST.Location = new System.Drawing.Point(851, 14);
            this.btnOpenAST.Name = "btnOpenAST";
            this.btnOpenAST.Size = new System.Drawing.Size(90, 47);
            this.btnOpenAST.TabIndex = 19;
            this.btnOpenAST.Text = "Open AST";
            this.btnOpenAST.UseVisualStyleBackColor = false;
            this.btnOpenAST.Click += new System.EventHandler(this.btnOpenAST_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(997, 600);
            this.Controls.Add(this.GrpConn);
            this.Controls.Add(this.GrpRCV);
            this.Controls.Add(this.GrpTR);
            this.Controls.Add(this.MyCTRLBOX);
            this.Controls.Add(this.TxtTerm);
            this.Controls.Add(this.LblTitle);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AtomTerminal";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.GrpConn.ResumeLayout(false);
            this.GrpConn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyCTRLBOX)).EndInit();
            this.GrpTR.ResumeLayout(false);
            this.GrpTR.PerformLayout();
            this.GrpRCV.ResumeLayout(false);
            this.GrpRCV.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpConn;
        private System.Windows.Forms.ComboBox CmbBaud;
        private System.Windows.Forms.ComboBox CmbPorts;
        private System.Windows.Forms.ComboBox CmbBits;
        private System.Windows.Forms.ComboBox CmbParity;
        private System.Windows.Forms.ComboBox CmbStop;
        private System.Windows.Forms.PictureBox MyCTRLBOX;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.ComboBox CmbFlow;
        private System.Windows.Forms.Button BtnOpen;
        private System.IO.Ports.SerialPort MySerialPort;
        private System.Windows.Forms.GroupBox GrpTR;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.CheckBox ChkCR;
        private System.Windows.Forms.CheckBox ChkNL;
        private System.Windows.Forms.CheckBox ChkHex;
        private System.Windows.Forms.CheckBox ChkEcho;
        private System.Windows.Forms.GroupBox GrpRCV;
        private System.Windows.Forms.RadioButton radHexAscii;
        private System.Windows.Forms.RadioButton radHex;
        private System.Windows.Forms.RadioButton radASCII;
        private System.Windows.Forms.Label LblSentFile;
        private System.Windows.Forms.Button BtnSendFile;
        private System.Windows.Forms.RadioButton radLogTxt;
        private System.Windows.Forms.RadioButton radLogBin;
        private System.Windows.Forms.CheckBox ChkEnLog;
        private System.Windows.Forms.Label LblLogFile;
        private System.Windows.Forms.CheckBox ChkEchoLog;
        private System.Windows.Forms.RadioButton radOpenBin;
        private System.Windows.Forms.RadioButton radOpenTxt;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLG;
        private System.Windows.Forms.Button BtnSM;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button BtnBGColor;
        private System.Windows.Forms.Button BtnFGColor;
        private System.Windows.Forms.Button BtnBold;
        protected System.Windows.Forms.RichTextBox TxtTerm;
        private System.Windows.Forms.Button btnOpenAST;
        private System.Windows.Forms.Button btnSaveAST;
    }
}

