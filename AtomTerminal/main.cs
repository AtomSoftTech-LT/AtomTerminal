using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace AtomTerminal
{
    public partial class main : Form
    {
        public bool isMaximized = false;
        public bool isSerialOpen = false;
        public List<int> rxBuff;
        string LogFileLocation = "";

        public string[] myComms;

        public main()
        {
            InitializeComponent();

        }

        public delegate void AddDataDelegate(string myString);
        public AddDataDelegate myDelegate;

        /*
         *The below is for ALLOWING RESIZE
         * I found it online, forgot where tbh
         * Allows custom border with resize 
         */
 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        
        
        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
                    {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                    {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                    {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                    {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }
        /*The ABOVE is for ALLOWING RESIZE */

        private void GetPorts()
        {

            //Variable Array to hold port names
            string[] ports = null;

            //Get port names and place in array
            ports = SerialPort.GetPortNames();

            //Clear the combo box that list the ports
            cmbPorts.Items.Clear();

            //Sort the array
            Array.Sort<string>(ports);

            //Add the port names to the combo box
            for (int i = 0; i < ports.Length; i++)
            {
                cmbPorts.Items.Add(ports[i]);
            }

            //Add a new item called refresh, used to refresh the list.
            cmbPorts.Items.Add("Refresh...");

            //select the first item in the combo box list
            cmbPorts.Text = cmbPorts.Items[0].ToString();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //used to jump thread, for adding data received from serial port
            this.myDelegate = new AddDataDelegate(AddDataMethod);

            //BG COLOR is 29,29,31 aka 1D1D1F
            lblTitle.Text = "AtomTerminal - No Connection";

            //Hide the main screen
            this.Visible = false;

            //load splash screen
            Form mySplash = new splash();
            
            //show my splash screen
            mySplash.Show();

            //Show it for 3 seconds or less
            Thread.Sleep(1500); //1.5 seconds (1 second, 500 miliseconds)

            //Close the splash screen
            mySplash.Close();

            //make our main app form visible
            this.Visible = true;

            //Call getPorts to load our com ports.
            GetPorts();

            //do a initial resize to load locations of controls
            GroupResize();
        }

        public void AddDataMethod(string myString)
        {
            //Boolean variables to determine what kind of logging is to be done.
            bool LogBin = false;
            bool LogTxt = false;

            //Check if Log is selected 
            if (chkEnLog.Checked == true)
            {
                //determine what king of logging is to be done
                if (radLogBin.Checked == true)  
                    LogBin = true;  //Binary Logging
                else
                    LogTxt = true;  //Text Logging

            }

            //how to display data to user.

            if (radASCII.Checked == true)   //Display as ASCII
            {
                //Simple text is easy. Just add it to the textbox
                txtTerm.Text += myString;

                //Log as text file
                if (LogTxt == true)
                {
                    //Open file and append the string
                    using (StreamWriter sw = File.AppendText(LogFileLocation))
                    {
                        sw.WriteLine(myString);
                    }
                }
                if (LogBin == true) //Logging as text file
                {
                    //open log file and append our new hex + [ascii]
                    using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                    {
                        byte[] myByteData = Encoding.ASCII.GetBytes(myString);
                        writer.Write(myByteData);
                    }
                }
                return;
            }

            if (radHex.Checked == true)     //Display as hex
            {
                //Convert the string into a byte array
                byte[] ba = Encoding.Default.GetBytes(myString);

                //Convert the byte array to a string with hex values instead of chars
                var hexString = BitConverter.ToString(ba);

                //Add a Dash (-) to the front of the string as the above uses them to seperate hex values but
                //does not place one in front. Used to allow addition of 0x later on. Also add 2 spaces to the end 
                //the spaces are used to align the data in the text box
                hexString = "-" + hexString + "  ";

                //Replace the - (dashes) with "  0x" instead so... -49-0A will become "  0x49  0x0A"
                hexString = hexString.Replace("-", "  0x");

                //trim the start of any spaces for alignment. (Front not end)
                hexString = hexString.TrimStart();

                //Append our new string to the text box
                txtTerm.Text += hexString;

                
                if (LogTxt == true)     //We are logging as a text file
                {
                    //open text file and append to end
                    using (StreamWriter sw = File.AppendText(LogFileLocation))
                    {
                        sw.WriteLine(hexString);
                    }
                }
                if (LogBin == true) //Logging as text file
                {
                    //open log file and append our new hex + [ascii]
                    using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                    {
                        byte[] myByteData = Encoding.ASCII.GetBytes(hexString);
                        writer.Write(myByteData);
                    }
                }
                return;
            }

            if (radHexAscii.Checked == true)    //Display Hex and Ascii ex: received number 0 aka: 0x30 [0]
            {
                //turn string of incoming data into bytes
                byte[] ba = Encoding.Default.GetBytes(myString);
                
                //variable for new hex [ascii] string
                string hexString2 = "";

                //get the length of bytes to work with
                int arlen = ba.Length;

                //temp string used for converting each byte to a string
                string tmpSTR = "";

                //loop the byte count
                for (int x = 0; x < arlen; x++)
                {
                    //if the character isnt a viewable one 
                    //  show a dot ex: 0x0A [.]
                    //else
                    //  show the hex [ascii] ex: 0x31 [1]

                    if ((ba[x] < 0x20) || (ba[x] > 0x7E))  
                    {
                        tmpSTR = "0x" + BitConverter.ToString(ba, x, 1) + "[.]  ";
                    }
                    else
                    {
                        tmpSTR = "0x" + BitConverter.ToString(ba, x, 1) + "[" + Convert.ToChar(ba[x]) + "]  ";
                    }

                    //add the new temp string to our final string
                    hexString2 += tmpSTR;

                }

                //add the new complete hexstring2 to our text box
                txtTerm.Text += hexString2;

                if (LogTxt == true) //Logging as text file
                {
                    //open log file and append our new hex + [ascii]
                    using (StreamWriter sw = File.AppendText(LogFileLocation))
                    {
                        sw.WriteLine(hexString2);
                    }
                }
                if (LogBin == true) //Logging as text file
                {
                    //open log file and append our new hex + [ascii]
                    using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                    {
                        byte[] myByteData = Encoding.ASCII.GetBytes(hexString2);
                        writer.Write(myByteData);
                    }
                }
                return;
            }
        }

        private void mySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //get the amount of bytes in buffer
            int mySize = mySerialPort.BytesToRead;

            //make a new buffer to hold mySize amount of bytes
            byte[] myBuffer = new byte[mySize];

            //Read mySize of bytes from serial port to our buffer
            mySerialPort.Read(myBuffer, 0, mySize);

            //temp string for sending our data around. 
            // might leave byte array
            string tempSTR = "";

            //loop bytes and create a string from them
            for (int x = 0; x < mySize; x++)
            {
                tempSTR += Convert.ToChar(myBuffer[x]);
            }

            //send the bytes to our Delegate which will process it and display it on the other thread.
            txtTerm.Invoke(this.myDelegate, new Object[] { tempSTR });
        }

        void GroupResize()
        {
            //This is for the control box. The Minimize, Maximize/Restore and Close buttons
            myCTRLBOX.Left = this.Width - myCTRLBOX.Width - 3;

            //This controls where our actual terminal text box will be
            txtTerm.Width = this.Width - 10;
            txtTerm.Height = this.Height - 230;

            //this controls the group box which holds the connections stuff
            grpConn.Top = txtTerm.Bottom + 4;
            grpConn.Width = this.Width - 10;

            //this specifies where the transmit group box will appear
            grpTR.Top = grpConn.Bottom + 4;
            grpTR.Width = this.Width - 10;

            //this controls the Receive group box
            grpRCV.Top = grpTR.Bottom + 4;
            grpRCV.Width = this.Width - 10;
        }

        private void main_Resize(object sender, EventArgs e)
        {
            //call our resize funtion
            GroupResize();
        }

        private void cmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //determine which index was selected
            int myIndex = cmbPorts.SelectedIndex;

            //get the text of the selected item
            string myText = cmbPorts.Items[myIndex].ToString();

            //if the text is "Refresh..." then issue a refresh of the ports
            if (myText == "Refresh...")
                GetPorts();
        }

        private void cmbFlow_MouseMove(object sender, EventArgs e)
        {
            string newText = "Serial Configuration - Flow Control";

            if (grpConn.Text != newText)
                grpConn.Text = newText;
        }

        private void grpConn_MouseHover(object sender, EventArgs e)
        {
            string newText = "Serial Configuration";

            if (grpConn.Text != newText)
            {
                grpConn.Text = newText;
                lblTitle.Focus();
            }
        }

        private void cmbPorts_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Comm. Port";

            if (grpConn.Text != newText)
                grpConn.Text = newText;
        }

        private void cmbBaud_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Baud Rate";

            if (grpConn.Text != newText)
                grpConn.Text = newText;
        }

        private void cmbBits_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Bits";

            if (grpConn.Text != newText)
                grpConn.Text = newText;
        }

        private void cmbParity_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Parity";

            if (grpConn.Text != newText)
                grpConn.Text = newText;
        }

        private void cmbStop_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Stop Bits";

            if (grpConn.Text != newText)
                grpConn.Text = newText;
        }

        //Below values are defined for control box button coordinates
        const int MIN_L = 40;
        const int MIN_R = 60;
        const int MAX_L = 60;
        const int MAX_R = 80;
        const int CLOSE_L = 80;
        const int CLOSE_R = 100;
        const int CONTROL_TOP = 1;
        const int CONTROL_BOTTOM = 18;

        private void myCTRLBOX_MouseMove(object sender, MouseEventArgs e)
        {
            // txtTerm.Text = "X: " + e.X.ToString() + "\n\r Y: " + e.Y.ToString();

            //Load our current mouse location into some variables
            int myX = e.X;
            int myY = e.Y;

            if ((myY >= CONTROL_TOP) & (myY <= CONTROL_BOTTOM))
            {
                //preload our control box image in case 
                var newCtrl = Properties.Resources.ControlBox;

                if ((myX >= MIN_L) & (myX <= MIN_R))
                {
                    //Load new MIN BUTTON
                    newCtrl = Properties.Resources.c_min;

                }

                if ((myX >= MAX_L) & (myX <= MAX_R))
                {
                    //Load new MAX BUTTON
                    newCtrl = Properties.Resources.c_max;
                }

                if ((myX >= CLOSE_L) & (myX <= CLOSE_R))
                {
                    //Load new Close BUTTON
                    newCtrl = Properties.Resources.c_close;
                }

                //Set our new image to picturebox 
                myCTRLBOX.Image = newCtrl;
            }
        }

        private void myCTRLBOX_MouseDown(object sender, MouseEventArgs e)
        {
            int myX = e.X;
            int myY = e.Y;

            if ((myY >= CONTROL_TOP) & (myY <= CONTROL_BOTTOM))
            {
                //preload our control box image in case 
                var newCtrl = Properties.Resources.ControlBox;

                if ((myX >= MIN_L) & (myX <= MIN_R))
                {
                    //Load new MIN BUTTON
                    newCtrl = Properties.Resources.h_min;

                }

                if ((myX >= MAX_L) & (myX <= MAX_R))
                {
                    //Load new MAX BUTTON
                    newCtrl = Properties.Resources.h_max;
                }

                if ((CLOSE_L >= 80) & (myX <= CLOSE_R))
                {
                    //Load new Close BUTTON
                    newCtrl = Properties.Resources.h_close;
                }

                //Set our new image to picturebox 
                myCTRLBOX.Image = newCtrl;
            }
        }

        private void myCTRLBOX_MouseClick(object sender, MouseEventArgs e)
        {
            int myX = e.X;
            int myY = e.Y;

            if ((myY >= CONTROL_TOP) & (myY <= CONTROL_BOTTOM))
            {
                //preload our control box image in case 
                var OrigCtrl = Properties.Resources.ControlBox;

                if ((myX >= MIN_L) & (myX <= MIN_R))
                {
                    // Minimize our form
                    this.WindowState = FormWindowState.Minimized;
                }

                if ((myX >= MAX_L) & (myX <= MAX_R))
                {
                    //Are we already maximized? If so not then MAXIMIZE it and set our boolean for future usage
                    if (isMaximized == false)   
                    {
                        isMaximized = true;
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        //We are already maximized so restore the window to normal and set our boolean for future usage
                        isMaximized = false;
                        this.WindowState = FormWindowState.Normal;
                    }
                }

                if ((myX >= CLOSE_L) & (myX <= CLOSE_R))
                {
                    //Close was pressed... ask user if they want to leave. If so then leave
                    if (MessageBox.Show("Are you sure?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        this.Close();
                }

                //Set our original image to picturebox 
                myCTRLBOX.Image = OrigCtrl;
            }
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void myCTRLBOX_MouseLeave(object sender, EventArgs e)
        {
            myCTRLBOX.Image = Properties.Resources.ControlBox;
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            //IDK WHY THIS DOESNT WORK
            if (isMaximized == false)
            {
                isMaximized = true;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                isMaximized = false;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (isSerialOpen == false)
            {
                try
                {
                    mySerialPort.PortName = cmbPorts.Text;
                    mySerialPort.BaudRate = Convert.ToInt32(cmbBaud.Text);
                    mySerialPort.DataBits = Convert.ToInt32(cmbBits.Text);

                    switch (cmbStop.Text)
                    {
                        case "0":
                            mySerialPort.StopBits = StopBits.None;
                            break;
                        case "1":
                            mySerialPort.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            mySerialPort.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            mySerialPort.StopBits = StopBits.Two;
                            break;
                        default:
                            mySerialPort.StopBits = StopBits.One;
                            break;
                    }

                    switch (cmbParity.Text)
                    {
                        case "None":
                            mySerialPort.Parity = Parity.None;
                            break;
                        case "Odd":
                            mySerialPort.Parity = Parity.Odd;
                            break;
                        case "Even":
                            mySerialPort.Parity = Parity.Even;
                            break;
                        case "Mark":
                            mySerialPort.Parity = Parity.Mark;
                            break;
                        case "Space":
                            mySerialPort.Parity = Parity.Space;
                            break;
                        default:
                            mySerialPort.Parity = Parity.None;
                            break;
                    }

                    switch (cmbFlow.Text)
                    {
                        case "None":
                            mySerialPort.Handshake = Handshake.None;
                            break;
                        case "RTS / CTS":
                            mySerialPort.Handshake = Handshake.RequestToSend;
                            mySerialPort.RtsEnable = true;
                            break;
                        case "DTR / DSR":
                            mySerialPort.Handshake = Handshake.None;
                            mySerialPort.DtrEnable = true;
                            break;
                        default:
                            mySerialPort.Handshake = Handshake.None;
                            break;

                    }

                    mySerialPort.Open();
                    btnOpen.Text = "Close";
                    isSerialOpen = true;
                    lblTitle.Text = "AtomTerminal -> PORT: " + mySerialPort.PortName + " - " + cmbBaud.Text + " - " + cmbParity.Text + " - " + cmbStop.Text;
                }
                catch (UnauthorizedAccessException ex)
                {
                    lblTitle.Text = "AtomTerminal - No Connection";
                    btnOpen.Text = "Connect";
                    isSerialOpen = false;
                    MessageBox.Show("Com port is in Open elsewhere.", "Oops!");
                    Debug.WriteLine("COM PORT CONNECT ERROR: .\n\r" + ex.ToString());
                }
            }
            else
            {
                mySerialPort.Close();
                lblTitle.Text = "AtomTerminal - No Connection";
                btnOpen.Text = "Connect";
                isSerialOpen = false;
            }
        }
        public byte[] addByteToArray(byte[] bArray, byte newByte)
        {
            int myNewLen = bArray.Length + 1;
            int myNewIndex = myNewLen - 1;

            byte[] newArray = new byte[myNewLen];
            bArray.CopyTo(newArray, 0);
            newArray[myNewIndex] = newByte;
            return newArray;
        }
        private void txtTerm_TextChanged(object sender, EventArgs e)
        {
            txtTerm.SelectionStart = txtTerm.Text.Length;
            txtTerm.ScrollToCaret();
        }

        //Created a super simple structure here to help with returning data
        struct Hexstr2bytes
        {
            public byte[] hexArray;
            public bool passed;
        }

        Hexstr2bytes HexString2ByteArray(string myInputHexStr)
        {
            Hexstr2bytes myReturn = new Hexstr2bytes();

            myReturn.passed = false;

            //Split the string by spaces
            string[] hexValuesSplit = myInputHexStr.Split(' ');

            //create a new array to hold the byte data. same length as the split from above
            byte[] hexArray = new byte[hexValuesSplit.Length];

            //counter
            int hexCount = 0;

            foreach (string hex in hexValuesSplit)
            {
                //Get current strings length
                int tempLen = hex.Length;

                //temp new string
                string tempHex = hex;

                //Users usually enter something like: 0x30, h30, x30, 30
                //all we care and need are the 2 digits at end. this will get the last 2
                if (tempLen > 2)
                    tempHex = tempHex.Substring((tempLen - 2), 2);

                //little test to ensure the tempHex is valid number and not weird stuff
                try
                {
                    int result = int.Parse(tempHex);
                }
                catch
                {
                    MessageBox.Show(tempHex + " is not a valid entry.", "Failed: Bad Hex");
                    return myReturn;
                }


                //convert that new short string to byte and place in the array 
                hexArray[hexCount] = Convert.ToByte(tempHex);

                //incrememnt count
                hexCount++;
            }

            // return our new array of bytes
            myReturn.passed = true;
            myReturn.hexArray = hexArray;
            return myReturn;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //if serial isnt connected then leave
            if (isSerialOpen == false)
            {
                MessageBox.Show("Um.. Not Connected", "Oops...", MessageBoxButtons.OK);
                return;
            }

            // get our data from user text box
            string Data2Send = txtSend.Text;

            byte[] Data2Bytes;

            if (chkHex.Checked == false)
            {
                //if this is simply text convert to bytes easy way
                Data2Bytes = Encoding.ASCII.GetBytes(Data2Send);
            }
            else
            {
                //TRYING to send HEX bytes... trim the front and end for garbage spaces
                Data2Send = Data2Send.TrimStart();
                Data2Send = Data2Send.TrimEnd();

                //CONVERT the string array to a byte array
                Hexstr2bytes hs2b = HexString2ByteArray(Data2Send);

                //if conversion failed return without sending data 
                //so any unwanted operations will not happen from missing or skipping data
                if (hs2b.passed == false)
                    return;

                //bring in our new array
                Data2Bytes = hs2b.hexArray;
            }

            //Just some variables for NewLine and Carriage Return
            byte NL = 0x0A;
            byte CR = 0x0D;

            if (chkNL.Checked == true)
            {
                //if newline (NL) checkbox is checked then add to end
                Data2Bytes = addByteToArray(Data2Bytes, NL);
            }

            if (chkCR.Checked == true)
            {
                //if Carriage Return (CR) checkbox is checked then add to end
                Data2Bytes = addByteToArray(Data2Bytes, CR);
            }

            //Send the array out through port
            mySerialPort.Write(Data2Bytes, 0, Data2Bytes.Length);

            //if echo is on then print to our screen also
            if (chkEcho.Checked == true)
            {
                string myEcho = "\n\rAtomEcho: " + txtSend.Text;
                txtTerm.Text += myEcho;

                if (chkEchoLog.Checked == true)
                {
                    if (radLogTxt.Checked == true)
                    {
                        using (StreamWriter sw = File.AppendText(LogFileLocation))
                        {
                            sw.WriteLine(myEcho);
                        }
                    }
                    if (radLogBin.Checked == true)
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                        {
                            byte[] myByteData = Encoding.ASCII.GetBytes(myEcho);
                            writer.Write(myByteData);
                        }
                    }
                }

            }
        }

        private void chkEnLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnLog.Checked == true)
            {
                string myFilter = "";

                if (radLogBin.Checked == true)
                    myFilter = "Binary|*.bin";
                else
                    myFilter = "Text File|*.txt";

                SaveFileDialog myLogFile = new SaveFileDialog();
                myLogFile.Filter = myFilter;
                myLogFile.Title = "Choose file to save Log";
                myLogFile.ShowDialog();

                if (myLogFile.FileName.Length < 1)
                {
                    chkEnLog.Checked = false;
                    LogFileLocation = "";
                    lblLogFile.Text = "Log File: NA";
                    return;
                }
                LogFileLocation = myLogFile.FileName;

                if (radLogTxt.Checked == true)
                {
                    if (!File.Exists(LogFileLocation))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(LogFileLocation))
                        {
                            sw.WriteLine("AtomTerminal Log: " + DateTime.Now.ToString() + "\n\r");
                        }
                    }
                }

                if (radLogBin.Checked == true)
                {
                    if (!File.Exists(LogFileLocation))
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                        {
                            byte[] myPad= new byte[2];
                            myPad[0] = 0xFF;
                            myPad[1] = 0xFF;

                            writer.Write(myPad);
                            writer.Write("AtomTerminal Log: " + DateTime.Now.ToString() + "\n\r");
                            writer.Write(myPad);
                        }
                    }
                }
                lblLogFile.Text = "Log File: " + LogFileLocation;
            }
            else
            {
                chkEnLog.Checked = false;
                LogFileLocation = "";
                lblLogFile.Text = "Log File: NA";
            }
        }

        private void chkEchoLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEchoLog.Checked == false)
                return;

            if (chkEcho.Checked == false)
            {

                if (MessageBox.Show("Enaable Echo to Screen?", "Set Echo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    chkEcho.Checked = true;
                }

            }
        }

        private void myCTRLBOX_Click(object sender, EventArgs e)
        {

        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            string myTextFile = "";
            byte[] myBinaryFile;

            //if serial isnt connected then leave
            if (isSerialOpen == false)
            {
                MessageBox.Show("Um.. Not Connected", "Oops...", MessageBoxButtons.OK);
                return;
            }

            //Send a text file
            if (radOpenTxt.Checked == true)
            {
                OpenFileDialog ofdText = new OpenFileDialog();
                ofdText.Filter = "Text File|*.txt";
                ofdText.Title = "Open Text File";
                ofdText.ShowDialog();

                String myTextFilename = ofdText.FileName;

                if (myTextFilename.Length < 1)
                    return;

                myTextFile = System.IO.File.ReadAllText(myTextFilename);
                mySerialPort.Write(myTextFile);
            }

            //Send a binary file
            if (radOpenBin.Checked == true)
            {
                OpenFileDialog ofdText = new OpenFileDialog();
                ofdText.Filter = "All Files|*.*";
                ofdText.Title = "Open Binary File";
                ofdText.ShowDialog();

                String myBinaryFilename = ofdText.FileName;

                if (myBinaryFilename.Length < 1)
                    return;

                myBinaryFile = File.ReadAllBytes(myBinaryFilename);
                mySerialPort.Write(myBinaryFile, 0, myBinaryFile.Length);
                myTextFile = Encoding.ASCII.GetString(myBinaryFile);
                
            }

            //if echo is on then print to our screen also
            if (chkEcho.Checked == true)
            {
                string myEcho = "\n\rAtomEcho: " + myTextFile;
                txtTerm.Text += myEcho;

                if (chkEchoLog.Checked == true)
                {
                    if (radLogTxt.Checked == true)
                    {
                        using (StreamWriter sw = File.AppendText(LogFileLocation))
                        {
                            sw.WriteLine(myEcho);
                        }
                    }
                    if (radLogBin.Checked == true)
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                        {
                            byte[] myByteData = Encoding.ASCII.GetBytes(myEcho);
                            writer.Write(myByteData);
                        }
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTerm.Text.Length > 0)
            {
                if(MessageBox.Show("Are you sure?","Clear Terminal",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtTerm.Text = "";
                }      
            }
        }

        private void btnSM_Click(object sender, EventArgs e)
        {
            float newSize = txtTerm.Font.Size;

            if (newSize > 3)
                newSize--;

            txtTerm.Font = new Font(txtTerm.Font.Name, newSize,
                txtTerm.Font.Style, txtTerm.Font.Unit);
        }

        private void btnLG_Click(object sender, EventArgs e)
        {
            float newSize = txtTerm.Font.Size;

            if (newSize < 22)
                newSize++;

            txtTerm.Font = new Font(txtTerm.Font.Name, newSize,
                txtTerm.Font.Style, txtTerm.Font.Unit);
        }

        private void btnBGColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color myChosenColor = colorDialog1.Color;
                txtTerm.BackColor = myChosenColor;
            }
        }

        private void btnFGColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color myChosenColor = colorDialog1.Color;
                txtTerm.ForeColor = myChosenColor;
            }
        }

        
        private void btnBold_Click(object sender, EventArgs e)
        {
            bool isBold = txtTerm.Font.Bold;

            if (isBold)
            {  
                txtTerm.Font = new Font(txtTerm.Font.Name, txtTerm.Font.Size, FontStyle.Regular, txtTerm.Font.Unit);
            }
            else
            {
                txtTerm.Font = new Font(txtTerm.Font.Name, txtTerm.Font.Size, FontStyle.Bold, txtTerm.Font.Unit);
            }
        }
    }
}


