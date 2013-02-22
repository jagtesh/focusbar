using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShellLib;

namespace FocusBarWin
{
    public partial class Form1 : ShellLib.ApplicationDesktopToolbar
    {
        uint timerStart;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the initial text values for all labels
            toolStripLabel2.Text = "00:00:00";
            timer1.Tag = false;
            timer1.Interval = 1000;
            timer1.Enabled = false;

            // Set width of task label to a little less than half the width of window
            int screenWidth = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            Size s = toolStripTextBox1.Size;
            s.Width = (int)(screenWidth / 2) - (72 / 2) + 14; // Half of screen width - Half of timer label width
            toolStripTextBox1.Size = s;

            Size s2 = this.Size;
            System.Console.WriteLine(s2);
            s2.Width = 25;
            this.Size = s2;

            this.Edge = AppBarEdges.Top;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Edge = AppBarEdges.Float;
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                timer1.Start();
                toolStripButton1.Text = "";
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
                toolStripButton1.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timerStart += 1;
            toolStripLabel2.Text = Util.formatTimeElapsed(this.timerStart);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            this.timerStart = 0;

            toolStripButton1.Text = "";
            toolStripLabel2.Text = "00:00:00";
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
