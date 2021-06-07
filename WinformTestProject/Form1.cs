using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinformTestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString("Hello World", Font, Brushes.Black, new PointF(10, 10));
            e.Graphics.DrawString(data1.ToString(), Font, Brushes.Black, new PointF(40, 40));
            e.Graphics.DrawString(data2, Font, Brushes.Black, new PointF(40, 60));
        }
        int data1 = 0;
        string data2 = "";
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2 diag = new Form2();
            //diag.ShowDialog();
            //diag.Dispose();
            Stream fs;
            
            openFileDialog1.Filter = "데이터(*.data)|*.data";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if( (fs = openFileDialog1.OpenFile()) != null )
                {
                    using(BinaryReader br = new BinaryReader(fs))
                    {
                        data1 = br.ReadInt32();
                        data2 = br.ReadString();
                        Invalidate();
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int data1 = 10;
            string data2 = "Hello World";
            Stream fs;
            saveFileDialog1.DefaultExt = "data";
            saveFileDialog1.Filter = "데이터(*.data)|*.data";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((fs = saveFileDialog1.OpenFile()) != null)
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(data1);
                        bw.Write(data2);
                    }
                }
            }
        }

        private void dBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 diag = new Form2();
            diag.ShowDialog();
            diag.Dispose();
        }
    }
}
