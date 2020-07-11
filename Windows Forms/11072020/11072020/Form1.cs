using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11072020
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            // FormChild child = new FormChild();
            //// child.Show();
            // child.ShowDialog();

            // Main to Child
            //1
            //FormChild child = new FormChild(textBox1.Text);
            //child.ShowDialog();

            //2
            //FormChild child = new FormChild();
            //child.textBox1.Text = textBox1.Text;
            //child.ShowDialog();

            //3
            //FormChild child = new FormChild();
            //child.ShowDialog(textBox1.Text);

            //4
            //FormChild child = new FormChild();
            //child.STR = textBox1.Text;
            //child.ShowDialog();

            //Child to Main
            FormChild child = new FormChild();
            child.Tag = this;
            child.STR = textBox1.Text;
            if (DialogResult.Yes == child.ShowDialog())
            {
                //1
                //textBox1.Text = child.textBox1.Text;
                //2
                textBox1.Text = child.STR;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                BackColor = colorDialog1.Color;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                Text = folderBrowserDialog1.SelectedPath;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                fontDialog1_Apply(sender, e);
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            textBox2.Font = fontDialog1.Font;
            textBox2.ForeColor = fontDialog1.Color;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //  Text = openFileDialog1.FileName;

                textBox2.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);
            }
        }

        private string TextToPrint = "";
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            gr.MeasureString(TextToPrint, textBox2.Font,
                e.MarginBounds.Size,
                StringFormat.GenericTypographic, out int CharInPage, out int LineInPage);
           
            gr.DrawString(TextToPrint, textBox2.Font,
                new SolidBrush(textBox2.ForeColor), e.MarginBounds, StringFormat.GenericTypographic);
           
            TextToPrint = TextToPrint.Substring(CharInPage);

            e.HasMorePages = TextToPrint.Length > 0;

            if (!e.HasMorePages)
                TextToPrint = textBox2.Text;

        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;


            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                TextToPrint = textBox2.Text;
                printDocument1.Print();
            }
        }

        private void buttonprintPreview_Click(object sender, EventArgs e)
        {
            TextToPrint = textBox2.Text;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
