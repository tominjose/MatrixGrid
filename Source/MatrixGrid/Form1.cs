using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MatrixGrid
{
    public partial class Form1 : Form
    {

        //Add the member variables
        public int m_width; //Width of the grid cell

        public int m_Height; // The height of the Cell

        public int m_Rows; // The Number Of Rows

        public int m_Cols; // The Number Of Columns

        public int m_XOffset; //Offset from which drawing start
        public int m_YOffset;
        public int rc = 9, counter = 2;
        public const int DEFAULT_X_OFFSET = 74;
        public const int DEFAULT_Y_OFFSET = 98;
        public const int DEFAULT_NO_ROWS = 2;
        public const int DEFAULT_NO_COLS = 2;
        public const int DEFAULT_WIDTH = 40;
        public const int DEFAULT_HEIGHT = 40;
        public Form1()
        {
            InitializeComponent();
            bThreadStatus = false;
            Initialize();
        }

        public void Initialize()
        {
            //Put all the default values
            m_Rows = DEFAULT_NO_ROWS;
            m_Cols = DEFAULT_NO_COLS;
            m_width = DEFAULT_WIDTH;
            m_Height = DEFAULT_HEIGHT;
            m_XOffset = DEFAULT_X_OFFSET;
            m_YOffset = DEFAULT_Y_OFFSET;

        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();
            bThreadStatus = true;
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread.Suspend();
        }

        private void ResumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CounterThread.Resume();
        }

        private void ButtonStop(object sender, EventArgs e)
        {
            CounterThread.Suspend();
        }

        private void ButtonStart(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();
            bThreadStatus = true;
        }

        private void Toolstripbutton1(object sender, EventArgs e)
        {
            CounterThread = new Thread(new ThreadStart(ThreadCounter));
            CounterThread.Start();
            bThreadStatus = true;
        }

        private void Toolstripbutton3(object sender, EventArgs e)
        {
            CounterThread.Suspend();
        }

        private void toolStripMenuItem2a_Click(object sender, EventArgs e)
        {
            rc = 4;
           
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            rc = 5;
           
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            rc = 6;
          
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            rc = 7;
           
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            rc = 8;
            
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            rc = 9;
        }


        public void ThreadCounter()
        {

            Graphics Layout = this.CreateGraphics();
            Pen layoutPen = new Pen(Color.Red);
            layoutPen.Width =5;
            
            while (counter <= rc)
            {
                Thread.Sleep(1000);

                if (counter != rc)
                {
                    m_Rows = counter;
                    m_Cols = counter;
                    int X = DEFAULT_X_OFFSET;
                    int Y = DEFAULT_Y_OFFSET;
                    //Draw rows
                    for (int i = 0; i <= m_Rows; i++)
                    {
                        Layout.DrawLine(layoutPen, X, Y, X + this.m_width * this.m_Cols, Y);
                        Y += m_Height;
                    }

                    //Draw Cols
                    X = DEFAULT_X_OFFSET;
                    Y = DEFAULT_Y_OFFSET;
                    for (int j = 0; j <= m_Cols; j++)
                    {
                        Layout.DrawLine(layoutPen, X, Y, X, Y + this.m_Height * this.m_Rows);
                        X += this.m_width;
                    }

                    counter++;
                }
                else
                {
                    counter = 2;
                    Invalidate();
                }

            }

        }

    }
}
