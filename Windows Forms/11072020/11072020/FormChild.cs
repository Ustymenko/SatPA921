using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11072020
{
    public partial class FormChild : Form
    {
        public string STR {
            get => textBox1.Text;
            set => textBox1.Text = value; 
        }
        public FormChild()
        {
            InitializeComponent();
        }
        public FormChild(string str):this()
        {
            textBox1.Text = str;
        }

        public DialogResult ShowDialog(string str) 
        {
            textBox1.Text = str;
            return ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FormMain form =(FormMain) this.Tag;
            form.Text = "123";
            this.DialogResult = DialogResult.Yes;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
