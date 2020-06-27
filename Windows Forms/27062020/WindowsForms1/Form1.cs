using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Bt_Click(object sender, EventArgs e)
        {
            if (buttonNO.Enabled)
            {
                buttonNO.Enabled = false;
                this.Controls.OfType<Button>()
                    .Where(b => b.Name == "OnOff")
                    .FirstOrDefault().Text = "On";
            }
            else
            {
                buttonNO.Enabled = true;
                this.Controls.OfType<Button>()
                   .Where(b => b.Name == "OnOff")
                   .FirstOrDefault()
                   .Text = "Off";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button bt = new Button
            {
                Text = "off",
                Name = "OnOff",
                Location = new Point(180, 220),
                Size = new Size(100, 50),
                Font = new Font("Arial", 14)
            };
            bt.Click += Bt_Click;
            this.Controls.Add(bt);


            //    // MessageBox.Show("Привіт ІЄї");
            //    if (DialogResult.Yes == MessageBox.Show("Привіт ІЄї", "Шапка",
            //           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //           MessageBoxDefaultButton.Button2))
            //    {
            //        MessageBox.Show("Yes", "Шапка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //        MessageBox.Show("No", "Шапка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bt2", "Шапка", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "" + this.ClientSize.Width;

            buttonNO.Location = new Point(10, 20);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ukr.net");
            linkLabel1.LinkVisited = true;
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);

                textBoxRes.Text = (a + b).ToString();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void TextChangedInTB(object sender, EventArgs e)
        {
            textBoxRes.Text = "";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);

                textBoxRes.Text = (a - b).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void buttonResult(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);

                if (sender is Button bt)
                {
                    switch (bt.Text[0])
                    {
                        case '+': textBoxRes.Text = (a + b).ToString(); break;
                        case '-': textBoxRes.Text = (a - b).ToString(); break;
                        case '*': textBoxRes.Text = (a * b).ToString(); break;
                        case '/': textBoxRes.Text = (a / b).ToString(); break;
                        default:
                            textBoxRes.Text =""; break;
                    }                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_filter(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch!=8 &&ch!=',')
                e.Handled = true;
          
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
