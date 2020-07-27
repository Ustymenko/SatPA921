using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25072020
{
    public partial class Form1 : Form
    {
        string buf = string.Empty;
        int startIndex = 0;
        public Form1()
        {
            InitializeComponent();
            pictureBox2.AllowDrop = true;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (buf.Length > 0)
            {
                textBox1.Select(startIndex, buf.Length);
                textBox1.DoDragDrop(buf, DragDropEffects.Copy);
                textBox1.SelectionLength=0;
            }
            buf = "";

        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                buf = textBox1.SelectedText;
                startIndex = textBox1.SelectionStart;
            }
        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string txt = e.Data.GetData(DataFormats.StringFormat).ToString();
            listBox1.Items.Add(txt);
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] pathFiles =(string[]) e.Data.GetData(DataFormats.FileDrop);
            listBox2.Items.Clear();
            listBox2.Items.AddRange(pathFiles);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Copy);
        }
        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                       e.Effect = DragDropEffects.Copy;
            else
                       e.Effect = DragDropEffects.None;
        }
        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox2.Image= (Image)e.Data.GetData(DataFormats.Bitmap);
        }
    }
}
