using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        Timer timerRun;
        public Form1()
        {
            InitializeComponent();
            timerRun = new Timer();
            timerRun.Interval = 100;
            // timerRun.Enabled = true;
            timerRun.Tick += TimerRun_Tick;
            // listBox2.Items.AddRange(students.ToArray());
            listBox2.DataSource = students;
            listBox2.DisplayMember = "PIB";

        }

        private void TimerRun_Tick(object sender, EventArgs e)
        {
            button1.Location = new Point(button1.Location.X + 1, button1.Location.Y);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    button1.Location=new Point(button1.Location.X+1, button1.Location.Y);
            //    System.Threading.Thread.Sleep(500);
            //}
            if (button1.Text == "Start")
            {
                timer1.Start();
                button1.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                button1.Text = "Start";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Location = new Point(button1.Location.X + 5, button1.Location.Y);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.ToLongDateString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label1.Text = monthCalendar1.SelectionRange.Start.ToLongDateString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendar1.SetDate(DateTime.Now);

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedItem != null)
            //    MessageBox.Show(comboBox1.SelectedItem.ToString());
            //else
            //    MessageBox.Show("Not selected item");
            if (comboBox1.SelectedIndex != -1)
                MessageBox.Show(comboBox1.Items[comboBox1.SelectedIndex].ToString());
            else
                MessageBox.Show("Not selected item");
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add(5555);
            comboBox1.Items.Insert(2, "Таня");
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            //if (comboBox1.Items.Count>0)
            //    comboBox1.Items.RemoveAt(0);
            //if (comboBox1.Items.Count > 0)
            //    comboBox1.Items.Remove(5555);              
            if (comboBox1.Items.Count > 0)
                comboBox1.Items.Remove(comboBox1.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (comboBox1.Items.Contains("Таня"))
            //    MessageBox.Show("Item in combobox");
            //else
            //    MessageBox.Show("Not item"); 

            int pos = comboBox1.Items.IndexOf("Таня");
            if (pos >= 0)
                MessageBox.Show("Item in combobox = " + pos);
            else
                MessageBox.Show("Not item");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //string text = "";
                //foreach (var item in listBox1.SelectedItems)
                //{
                //    text += item + "\n";
                //}
                //MessageBox.Show(text);
                //  MessageBox.Show(String.Join("\n", listBox1.SelectedItems.OfType<String>()));


                string text = "";
                foreach (var item in listBox1.SelectedIndices)
                {
                    text += item + "\n";
                }
                MessageBox.Show(text);


            }
            else
                MessageBox.Show("Not selected item");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                //var ind=listBox1.SelectedIndices.OfType<int>().ToArray();
                //for (int i = ind.Length - 1; i >= 0; i--)
                //{
                //    listBox1.Items.RemoveAt(ind[i]);
                //}
                //var listDel = listBox1.SelectedItems.OfType<object>().ToList();
                //foreach (var item in listDel)
                //{
                //    listBox1.Items.Remove(item);
                //}
                listBox1.SelectedItems
                    .OfType<object>()
                    .ToList().ForEach(listBox1.Items.Remove);



                // listBox1.SelectedItems.Remove(listBox1.SelectedItem);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                PIB = "Ворон Велерій",
                BDay = new DateTime(1999, 10, 25),
                avg = 4.99
            };
            listBox1.Items.Add(student);
        }
        List<Student> students = new List<Student>() {
        new Student {
                PIB = "Ворон Велерій",
                BDay = new DateTime(1999,10,25),
                avg= 4.99
            },
            new Student {
                PIB = "Горобець Велерій",
                BDay = new DateTime(2013,10,25),
                avg= 4.99
            },
            new Student {
                PIB = "Олівець Велерій",
                BDay = new DateTime(2015,10,25),
                avg= 4.99
            },
            new Student {
                PIB = "Петух Велерій",
                BDay = new DateTime(2000,10,25),
                avg= 4.99
            }
        };
        private void button7_Click(object sender, EventArgs e)
        {

            listBox2.DataSource = null;
            Student student = new Student
            {
                PIB = "Талах Максим",
                BDay = new DateTime(1999, 10, 25),
                avg = 4.99
            };
            students.Add(student);
            // listBox2.Items.Add(student);
            listBox2.DataSource = students;
            listBox2.DisplayMember = "PIB";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                students.RemoveAt(listBox2.SelectedIndex);
                listBox2.DataSource = null;
                listBox2.DataSource = students;
                listBox2.DisplayMember = "PIB";
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //checkedListBox1.SetItemChecked(1, true);
            //checkedListBox1.SetItemCheckState(2, CheckState.Checked);
            //checkedListBox1.SetItemCheckState(3, CheckState.Indeterminate);
            //
            //checkedListBox1.CheckedItems
            foreach (var item in checkedListBox1.CheckedItems)
            {
                listBox1.Items.Add(item);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemChecked(i))
                    checkedListBox1.SetItemChecked(i, false);
                else
                    checkedListBox1.SetItemChecked(i, true);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button11.ImageIndex++;
        }

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            button11.ImageIndex = 2;
        }

        private void button11_MouseLeave(object sender, EventArgs e)
        {
            button11.ImageIndex = 0;
        }
    }

}
