using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.IO;

namespace Dotyk
{
    public partial class Form1 : Form
    {
        int zamiana = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (zamiana==0)
                {
                notifyIcon1.Icon = new Icon("red.ico");
                zamiana = 1;
                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Verb = "runas",
                    LoadUserProfile = true,
                    FileName = "powershell.exe",
                    Arguments = "devcon disable '*ELAN9038&COL01'",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

                var p = System.Diagnostics.Process.Start(processInfo);
            }
            else
                {
                notifyIcon1.Icon = new Icon("green.ico");

                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Verb = "runas",
                    LoadUserProfile = true,
                    FileName = "powershell.exe",
                    Arguments = "devcon enable '*ELAN9038&COL01'",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

                var p = System.Diagnostics.Process.Start(processInfo);


                //string strCmdLine = @"/c pnputil /disable-device 'HID\HIDCLASS&Col04\1&2d595ca7&0&0003'";
                //System.Diagnostics.Process.Start("CMD.exe", strCmdLine);
                //System.Diagnostics.ProcessStartInfo myProcessInfo = new System.Diagnostics.ProcessStartInfo(); //Initializes a new ProcessStartInfo of name myProcessInfo
                //myProcessInfo.FileName = Environment.ExpandEnvironmentVariables("%SystemRoot%") + @"\System32\powershell.exe"; //Sets the FileName property of myProcessInfo to %SystemRoot%\System32\cmd.exe where %SystemRoot% is a system variable which is expanded using Environment.ExpandEnvironmentVariables
                //myProcessInfo.Arguments = @"/c pnputil /disable-device 'HID\HIDCLASS&Col04\1&2d595ca7&0&0003'"; //Sets the arguments to cd..
                //myProcessInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden; //Sets the WindowStyle of myProcessInfo which indicates the window state to use when the process is started to Hidden
                //myProcessInfo.Verb = "runas"; //The process should start with elevated permissions
                //System.Diagnostics.Process.Start(myProcessInfo);
                zamiana = 0;
                }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (zamiana == 0)
            {
                label2.ForeColor = System.Drawing.Color.Green;
                button1.Text = "Zablokuj";
                label2.Text = "Odblokowane";
            }
            else
            {
                label2.ForeColor = System.Drawing.Color.Red;
                button1.Text = "Odblokuj";
                label2.Text = "Zablokowane";
            }
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (zamiana == 0)
            {
                notifyIcon1.Icon = new Icon("red.ico");
                zamiana = 1;
                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Verb = "runas",
                    LoadUserProfile = true,
                    FileName = "powershell.exe",
                    Arguments = "devcon disable '*ELAN9038&COL01'",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

                var p = System.Diagnostics.Process.Start(processInfo);
            }
            else
            {
                notifyIcon1.Icon = new Icon("green.ico");

                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    Verb = "runas",
                    LoadUserProfile = true,
                    FileName = "powershell.exe",
                    Arguments = "devcon enable '*ELAN9038&COL01'",
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                };

                var p = System.Diagnostics.Process.Start(processInfo);
                zamiana = 0;
                
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            var processInfo = new System.Diagnostics.ProcessStartInfo
            {
                Verb = "runas",
                LoadUserProfile = true,
                FileName = "powershell.exe",
                Arguments = "devcon enable '*ELAN9038&COL01'",
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            var p = System.Diagnostics.Process.Start(processInfo);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}