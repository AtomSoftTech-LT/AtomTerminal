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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]
    public partial class main : Form
    {
        private bool isMaximized = false;
        private bool isSerialOpen = false;
        
        string LogFileLocation = "";

        

        public main()
        {
            InitializeComponent();

        }

        public delegate void AddDataDelegate(string MyString);
        private AddDataDelegate MyDelegate;

        /*
         *The below is for ALLOWING RESIZE
         * I found it online, forgot where tbh
         * Allows custom border with resize 
         */
 
        public const int WMNCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        
        
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
            string[] ports;

            //Get port names and place in array
            ports = SerialPort.GetPortNames();

            //Clear the combo box that list the ports
            CmbPorts.Items.Clear();

            //Sort the array
            Array.Sort<string>(ports);

            //Add the port names to the combo box
            for (int i = 0; i < ports.Length; i++)
            {
                CmbPorts.Items.Add(ports[i]);
            }

            //Add a new item called refresh, used to refresh the list.
            CmbPorts.Items.Add("Refresh...");

            //select the first item in the combo box list
            CmbPorts.Text = CmbPorts.Items[0].ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //used to jump thread, for adding data received from serial port
            this.MyDelegate = new AddDataDelegate(AddDataMethod);

            //BG COLOR is 29,29,31 aka 1D1D1F
            LblTitle.Text = "AtomTerminal - No Connection";

            //Hide the main screen
            this.Visible = false;

            //load splash screen
            Form MySplash = new splash();
            
            //show My splash screen
            MySplash.Show();

            //Show it for 3 seconds or less
            Thread.Sleep(1500); //1.5 seconds (1 second, 500 miliseconds)

            //Close the splash screen
            MySplash.Close();

            //make our main app form visible
            this.Visible = true;

            //Call getPorts to load our com ports.
            GetPorts();

            //do a initial resize to load locations of controls
            GroupResize();
        }

        public void AddDataMethod(string MyString)
        {
            //Boolean variables to determine what kind of logging is to be done.
            bool LogBin = false;
            bool LogTxt = false;

            //Check if Log is selected 
            if (ChkEnLog.Checked == true)
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
                TxtTerm.Text += MyString;

                //Log as text file
                if (LogTxt == true)
                {
                    //Open file and append the string
                    using (StreamWriter sw = File.AppendText(LogFileLocation))
                    {
                        sw.WriteLine(MyString);
                    }
                }
                if (LogBin == true) //Logging as text file
                {
                    //open log file and append our new hex + [ascii]
                    using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                    {
                        byte[] MyByteData = Encoding.ASCII.GetBytes(MyString);
                        writer.Write(MyByteData);
                    }
                }
                return;
            }

            if (radHex.Checked == true)     //Display as hex
            {
                //Convert the string into a byte array
                byte[] ba = Encoding.Default.GetBytes(MyString);

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
                TxtTerm.Text += hexString;

                
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
                        byte[] MyByteData = Encoding.ASCII.GetBytes(hexString);
                        writer.Write(MyByteData);
                    }
                }
                return;
            }

            if (radHexAscii.Checked == true)    //Display Hex and Ascii ex: received number 0 aka: 0x30 [0]
            {
                //turn string of incoming data into bytes
                byte[] ba = Encoding.Default.GetBytes(MyString);
                
                //variable for new hex [ascii] string
                string hexString2 = "";

                //get the length of bytes to work with
                int arlen = ba.Length;

                //temp string used for converting each byte to a string
                string tmpSTR;

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
                TxtTerm.Text += hexString2;

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
                        byte[] MyByteData = Encoding.ASCII.GetBytes(hexString2);
                        writer.Write(MyByteData);
                    }
                }
                return;
            }
        }

        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //get the amount of bytes in buffer
            int MySize = MySerialPort.BytesToRead;

            //make a new buffer to hold MySize amount of bytes
            byte[] MyBuffer = new byte[MySize];

            //Read MySize of bytes from serial port to our buffer
            MySerialPort.Read(MyBuffer, 0, MySize);

            //temp string for sending our data around. 
            // might leave byte array
            string tempSTR = "";

            //loop bytes and create a string from them
            for (int x = 0; x < MySize; x++)
            {
                tempSTR += Convert.ToChar(MyBuffer[x]);
            }

            //send the bytes to our Delegate which will process it and display it on the other thread.
            TxtTerm.Invoke(this.MyDelegate, new Object[] { tempSTR });
        }

        void GroupResize()
        {
            //This is for the control box. The Minimize, Maximize/Restore and Close buttons
            MyCTRLBOX.Left = this.Width - MyCTRLBOX.Width - 3;

            //This controls where our actual terminal text box will be
            TxtTerm.Width = this.Width - 10;
            TxtTerm.Height = this.Height - 230;

            //this controls the group box which holds the connections stuff
            GrpConn.Top = TxtTerm.Bottom + 4;
            GrpConn.Width = this.Width - 10;

            //this specifies where the transmit group box will appear
            GrpTR.Top = GrpConn.Bottom + 4;
            GrpTR.Width = this.Width - 10;

            //this controls the Receive group box
            GrpRCV.Top = GrpTR.Bottom + 4;
            GrpRCV.Width = this.Width - 10;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //call our resize funtion
            GroupResize();
        }

        private void CmbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //determine which index was selected
            int MyIndex = CmbPorts.SelectedIndex;

            //get the text of the selected item
            string MyText = CmbPorts.Items[MyIndex].ToString();

            //if the text is "Refresh..." then issue a refresh of the ports
            if (MyText == "Refresh...")
                GetPorts();
        }

        private void CmbFlow_MouseMove(object sender, EventArgs e)
        {
            string newText = "Serial Configuration - Flow Control";

            if (GrpConn.Text != newText)
                GrpConn.Text = newText;
        }

        private void GrpConn_MouseHover(object sender, EventArgs e)
        {
            string newText = "Serial Configuration";

            if (GrpConn.Text != newText)
            {
                GrpConn.Text = newText;
                LblTitle.Focus();
            }
        }

        private void CmbPorts_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Comm. Port";

            if (GrpConn.Text != newText)
                GrpConn.Text = newText;
        }

        private void CmbBaud_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Baud Rate";

            if (GrpConn.Text != newText)
                GrpConn.Text = newText;
        }

        private void CmbBits_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Bits";

            if (GrpConn.Text != newText)
                GrpConn.Text = newText;
        }

        private void CmbParity_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Parity";

            if (GrpConn.Text != newText)
                GrpConn.Text = newText;
        }

        private void CmbStop_MouseMove(object sender, MouseEventArgs e)
        {
            string newText = "Serial Configuration - Stop Bits";

            if (GrpConn.Text != newText)
                GrpConn.Text = newText;
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

        private void MyCTRLBOX_MouseMove(object sender, MouseEventArgs e)
        {
            // TxtTerm.Text = "X: " + e.X.ToString() + "\n\r Y: " + e.Y.ToString();

            //Load our current mouse location into some variables
            int MyX = e.X;
            int MyY = e.Y;

            if ((MyY >= CONTROL_TOP) & (MyY <= CONTROL_BOTTOM))
            {
                //preload our control box image in case 
                var newCtrl = Properties.Resources.ControlBox;

                if ((MyX >= MIN_L) & (MyX <= MIN_R))
                {
                    //Load new MIN BUTTON
                    newCtrl = Properties.Resources.c_min;

                }

                if ((MyX >= MAX_L) & (MyX <= MAX_R))
                {
                    //Load new MAX BUTTON
                    newCtrl = Properties.Resources.c_max;
                }

                if ((MyX >= CLOSE_L) & (MyX <= CLOSE_R))
                {
                    //Load new Close BUTTON
                    newCtrl = Properties.Resources.c_close;
                }

                //Set our new image to picturebox 
                MyCTRLBOX.Image = newCtrl;
            }
        }

        private void MyCTRLBOX_MouseDown(object sender, MouseEventArgs e)
        {
            int MyX = e.X;
            int MyY = e.Y;

            if ((MyY >= CONTROL_TOP) & (MyY <= CONTROL_BOTTOM))
            {
                //preload our control box image in case 
                var newCtrl = Properties.Resources.ControlBox;

                if ((MyX >= MIN_L) & (MyX <= MIN_R))
                {
                    //Load new MIN BUTTON
                    newCtrl = Properties.Resources.h_min;

                }

                if ((MyX >= MAX_L) & (MyX <= MAX_R))
                {
                    //Load new MAX BUTTON
                    newCtrl = Properties.Resources.h_max;
                }

                if ((CLOSE_L >= 80) & (MyX <= CLOSE_R))
                {
                    //Load new Close BUTTON
                    newCtrl = Properties.Resources.h_close;
                }

                //Set our new image to picturebox 
                MyCTRLBOX.Image = newCtrl;
            }
        }

        private void MyCTRLBOX_MouseClick(object sender, MouseEventArgs e)
        {
            int MyX = e.X;
            int MyY = e.Y;

            if ((MyY >= CONTROL_TOP) & (MyY <= CONTROL_BOTTOM))
            {
                //preload our control box image in case 
                var OrigCtrl = Properties.Resources.ControlBox;

                if ((MyX >= MIN_L) & (MyX <= MIN_R))
                {
                    // Minimize our form
                    this.WindowState = FormWindowState.Minimized;
                }

                if ((MyX >= MAX_L) & (MyX <= MAX_R))
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

                if ((MyX >= CLOSE_L) & (MyX <= CLOSE_R))
                {
                    //Close was pressed... ask user if they want to leave. If so then leave
                    if (MessageBox.Show("Are you sure?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Dispose();
                        this.Close();
                    }
                }

                //Set our original image to picturebox 
                MyCTRLBOX.Image = OrigCtrl;
            }
        }

        
        private void LblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                int MyHRESULT = SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
                if (MyHRESULT > 0)
                {
                    string MyInfo = "HRESULT Error: " + Convert.ToString(MyHRESULT);
                    MessageBox.Show(MyInfo, "Tell AtomSoftTech");
                }
            }
        }


        private void MyCTRLBOX_MouseLeave(object sender, EventArgs e)
        {
            MyCTRLBOX.Image = Properties.Resources.ControlBox;
        }

        private void LblTitle_DoubleClick(object sender, EventArgs e)
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

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (isSerialOpen == false)
            {
                try
                {
                    MySerialPort.PortName = CmbPorts.Text;
                    MySerialPort.BaudRate = Convert.ToInt32(CmbBaud.Text);
                    MySerialPort.DataBits = Convert.ToInt32(CmbBits.Text);

                    switch (CmbStop.Text)
                    {
                        case "0":
                            MySerialPort.StopBits = StopBits.None;
                            break;
                        case "1":
                            MySerialPort.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            MySerialPort.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            MySerialPort.StopBits = StopBits.Two;
                            break;
                        default:
                            MySerialPort.StopBits = StopBits.One;
                            break;
                    }

                    switch (CmbParity.Text)
                    {
                        case "None":
                            MySerialPort.Parity = Parity.None;
                            break;
                        case "Odd":
                            MySerialPort.Parity = Parity.Odd;
                            break;
                        case "Even":
                            MySerialPort.Parity = Parity.Even;
                            break;
                        case "Mark":
                            MySerialPort.Parity = Parity.Mark;
                            break;
                        case "Space":
                            MySerialPort.Parity = Parity.Space;
                            break;
                        default:
                            MySerialPort.Parity = Parity.None;
                            break;
                    }

                    switch (CmbFlow.Text)
                    {
                        case "None":
                            MySerialPort.Handshake = Handshake.None;
                            break;
                        case "RTS / CTS":
                            MySerialPort.Handshake = Handshake.RequestToSend;
                            MySerialPort.RtsEnable = true;
                            break;
                        case "DTR / DSR":
                            MySerialPort.Handshake = Handshake.None;
                            MySerialPort.DtrEnable = true;
                            break;
                        default:
                            MySerialPort.Handshake = Handshake.None;
                            break;

                    }

                    MySerialPort.Open();
                    BtnOpen.Text = "Close";
                    isSerialOpen = true;
                    LblTitle.Text = "AtomTerminal -> PORT: " + MySerialPort.PortName + " - " + CmbBaud.Text + " - " + CmbParity.Text + " - " + CmbStop.Text;
                }
                catch (UnauthorizedAccessException ex)
                {
                    LblTitle.Text = "AtomTerminal - No Connection";
                    BtnOpen.Text = "Connect";
                    isSerialOpen = false;
                    MessageBox.Show("Com port is in Open elsewhere.", "Oops!");
                    Debug.WriteLine("COM PORT CONNECT ERROR: .\n\r" + ex.ToString());
                }
            }
            else
            {
                MySerialPort.Close();
                LblTitle.Text = "AtomTerminal - No Connection";
                BtnOpen.Text = "Connect";
                isSerialOpen = false;
            }
        }
        private static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            int MyNewLen = bArray.Length + 1;
            int MyNewIndex = MyNewLen - 1;

            byte[] newArray = new byte[MyNewLen];
            bArray.CopyTo(newArray, 0);
            newArray[MyNewIndex] = newByte;
            return newArray;
        }
        private void TxtTerm_TextChanged(object sender, EventArgs e)
        {
            TxtTerm.SelectionStart = TxtTerm.Text.Length;
            TxtTerm.ScrollToCaret();
        }

        //Created a super simple structure here to help with returning data
        struct Hexstr2bytes
        {
            public byte[] hexArray;
            public bool passed;
        }

        Hexstr2bytes HexString2ByteArray(string MyInputHexStr)
        {
            Hexstr2bytes MyReturn = new Hexstr2bytes
            {
                passed = false
            };

            //Split the string by spaces
            string[] hexValuesSplit = MyInputHexStr.Split(' ');

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
                    UInt32 result = Convert.ToUInt32(tempHex, 16);
                }
                catch(FormatException fe)
                {
                    MessageBox.Show(tempHex + " is not a valid entry.", "Failed: Bad Hex");
                    Debug.WriteLine("Error: " + fe.ToString());
                    return MyReturn;
                }


                //convert that new short string to byte and place in the array 
                hexArray[hexCount] = Convert.ToByte(tempHex);

                //incrememnt count
                hexCount++;
            }

            // return our new array of bytes
            MyReturn.passed = true;
            MyReturn.hexArray = hexArray;
            return MyReturn;
        }

        private void BtnSend_Click(object sender, EventArgs e)
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

            if (ChkHex.Checked == false)
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

            if (ChkNL.Checked == true)
            {
                //if newline (NL) checkbox is checked then add to end
                Data2Bytes = AddByteToArray(Data2Bytes, NL);
            }

            if (ChkCR.Checked == true)
            {
                //if Carriage Return (CR) checkbox is checked then add to end
                Data2Bytes = AddByteToArray(Data2Bytes, CR);
            }

            //Send the array out through port
            MySerialPort.Write(Data2Bytes, 0, Data2Bytes.Length);

            //if echo is on then print to our screen also
            if (ChkEcho.Checked == true)
            {
                string MyEcho = "\n\rAtomEcho: " + txtSend.Text;
                TxtTerm.Text += MyEcho;

                if (ChkEchoLog.Checked == true)
                {
                    if (radLogTxt.Checked == true)
                    {
                        using (StreamWriter sw = File.AppendText(LogFileLocation))
                        {
                            sw.WriteLine(MyEcho);
                        }
                    }
                    if (radLogBin.Checked == true)
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                        {
                            byte[] MyByteData = Encoding.ASCII.GetBytes(MyEcho);
                            writer.Write(MyByteData);
                        }
                    }
                }

            }
        }

        private void ChkEnLog_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEnLog.Checked == true)
            {
                string MyFilter;

                if (radLogBin.Checked == true)
                    MyFilter = "Binary|*.bin";
                else
                    MyFilter = "Text File|*.txt";

                SaveFileDialog MyLogFile = new SaveFileDialog
                {
                    Filter = MyFilter,
                    Title = "Choose file to save Log"
                };
                MyLogFile.ShowDialog();

                if (MyLogFile.FileName.Length < 1)
                {
                    ChkEnLog.Checked = false;
                    LogFileLocation = "";
                    LblLogFile.Text = "Log File: NA";
                    MyLogFile.Dispose();
                    return;
                }
                LogFileLocation = MyLogFile.FileName;

                MyLogFile.Dispose();

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
                            byte[] MyPad= new byte[2];
                            MyPad[0] = 0xFF;
                            MyPad[1] = 0xFF;

                            writer.Write(MyPad);
                            writer.Write("AtomTerminal Log: " + DateTime.Now.ToString() + "\n\r");
                            writer.Write(MyPad);
                        }
                    }
                }
                LblLogFile.Text = "Log File: " + LogFileLocation;
            }
            else
            {
                ChkEnLog.Checked = false;
                LogFileLocation = "";
                LblLogFile.Text = "Log File: NA";
            }
        }

        private void ChkEchoLog_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEchoLog.Checked == false)
                return;

            if (ChkEcho.Checked == false)
            {

                if (MessageBox.Show("Enaable Echo to Screen?", "Set Echo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ChkEcho.Checked = true;
                }

            }
        }

        private void MyCTRLBOX_Click(object sender, EventArgs e)
        {

        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            string MyTextFile = "";
            byte[] MyBinaryFile;

            //if serial isnt connected then leave
            if (isSerialOpen == false)
            {
                MessageBox.Show("Um.. Not Connected", "Oops...", MessageBoxButtons.OK);
                return;
            }

            //Send a text file
            if (radOpenTxt.Checked == true)
            {
                OpenFileDialog ofdText = new OpenFileDialog
                {
                    Filter = "Text File|*.txt",
                    Title = "Open Text File"
                };
                ofdText.ShowDialog();

                String MyTextFilename = ofdText.FileName;

                if (MyTextFilename.Length < 1)
                {
                    ofdText.Dispose();
                    return;
                }

                ofdText.Dispose();

                MyTextFile = System.IO.File.ReadAllText(MyTextFilename);
                MySerialPort.Write(MyTextFile);
            }

            //Send a binary file
            if (radOpenBin.Checked == true)
            {
                OpenFileDialog ofdText = new OpenFileDialog
                {
                    Filter = "All Files|*.*",
                    Title = "Open Binary File"
                };
                ofdText.ShowDialog();

                String MyBinaryFilename = ofdText.FileName;

                if (MyBinaryFilename.Length < 1)
                {
                    ofdText.Dispose();
                    return;
                }

                ofdText.Dispose();
                MyBinaryFile = File.ReadAllBytes(MyBinaryFilename);
                MySerialPort.Write(MyBinaryFile, 0, MyBinaryFile.Length);
                MyTextFile = Encoding.ASCII.GetString(MyBinaryFile);
                
            }

            //if echo is on then print to our screen also
            if (ChkEcho.Checked == true)
            {
                string MyEcho = "\n\rAtomEcho: " + MyTextFile;
                TxtTerm.Text += MyEcho;

                if (ChkEchoLog.Checked == true)
                {
                    if (radLogTxt.Checked == true)
                    {
                        using (StreamWriter sw = File.AppendText(LogFileLocation))
                        {
                            sw.WriteLine(MyEcho);
                        }
                    }
                    if (radLogBin.Checked == true)
                    {
                        using (BinaryWriter writer = new BinaryWriter(File.Open(LogFileLocation, FileMode.Create)))
                        {
                            byte[] MyByteData = Encoding.ASCII.GetBytes(MyEcho);
                            writer.Write(MyByteData);
                        }
                    }
                }

            }

        }

        
        private void Button1_Click(object sender, EventArgs e)
        {
            if (TxtTerm.Text.Length > 0)
            {
                if(MessageBox.Show("Are you sure?","Clear Terminal",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    TxtTerm.Text = "";
                }      
            }
        }

        private void BtnSM_Click(object sender, EventArgs e)
        {
            float newSize = TxtTerm.Font.Size;

            if (newSize > 3)
                newSize--;

            TxtTerm.Font = new Font(TxtTerm.Font.Name, newSize,
                TxtTerm.Font.Style, TxtTerm.Font.Unit);
        }

        private void BtnLG_Click(object sender, EventArgs e)
        {
            float newSize = TxtTerm.Font.Size;

            if (newSize < 22)
                newSize++;

            TxtTerm.Font = new Font(TxtTerm.Font.Name, newSize,
                TxtTerm.Font.Style, TxtTerm.Font.Unit);
        }

        private void BtnBGColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color MyChosenColor = colorDialog1.Color;
                TxtTerm.BackColor = MyChosenColor;
            }
        }

        private void BtnFGColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color MyChosenColor = colorDialog1.Color;
                TxtTerm.ForeColor = MyChosenColor;
            }
        }

        
        private void BtnBold_Click(object sender, EventArgs e)
        {
            bool isBold = TxtTerm.Font.Bold;

            if (isBold)
            {  
                TxtTerm.Font = new Font(TxtTerm.Font.Name, TxtTerm.Font.Size, FontStyle.Regular, TxtTerm.Font.Unit);
            }
            else
            {
                TxtTerm.Font = new Font(TxtTerm.Font.Name, TxtTerm.Font.Size, FontStyle.Bold, TxtTerm.Font.Unit);
            }
        }
    }
}


