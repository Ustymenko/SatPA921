using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeAndList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // treeView1.Nodes.Add("РПЗ456");

            TreeNode root = new TreeNode("РПЗ456", 4, 6);
            root.Nodes.Add(new TreeNode("Цукерман", 0, 0));
            root.Nodes.Add(new TreeNode("Остапенко", 0, 0));
            treeView1.Nodes.Add(root);

            TreeNode rootCopy = (TreeNode)root.Clone();
            //treeView1.Nodes.Add(rootCopy);

            //treeView1.Nodes[1].Nodes.Add(rootCopy);

            // treeView1.Nodes.Insert(0,rootCopy);

            //TreeNode gr811 = treeView1.Nodes[1];
            //TreeNode pib = gr811.Nodes[1];
            //pib.Nodes.Add(rootCopy);

            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                selectNode.Nodes.Add(rootCopy);
                selectNode.Expand();
                treeView1.Focus();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                treeView1.Nodes.Remove(selectNode);
                //treeView1.Nodes.RemoveAt(1);
                treeView1.Focus();
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string textFind = "Петренко";
            var list = treeView1.Nodes.Find(textFind, true);
            if (list.Length > 0)
            {
                foreach (var item in list)
                    Text += item.Text + "  ";

            }
            else
                Text = "not fouded";
        }
        private void TreeFindRecursive(TreeNodeCollection list, string textFind)
        {
            //var elements = list
            //   .OfType<TreeNode>()
            //   .Where(n => n.Text == textFind)
            //   .Select(node=>node.Text)
            //   .ToArray();
            //listBox1.Items.AddRange(elements);
            //foreach (TreeNode item in list)
            //    TreeFindRecursive(item.Nodes, textFind);        

            foreach (TreeNode item in list)
            {
                if (item.Text == textFind)
                    listBox1.Items.Add(item.Text);
                TreeFindRecursive(item.Nodes, textFind);
            }
        }

        private void buttonFindMY_Click(object sender, EventArgs e)
        {
            string textFind = "Петренко";
            listBox1.Items.Clear();
            TreeFindRecursive(treeView1.Nodes, textFind);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listView1.Items.Add("Романов", 6);
            var gr0 = listView1.Groups[0];

            ListViewItem item = new ListViewItem(
                new string[] { "Романов", "66", "Львів" }
                , 6, gr0);
            listView1.Items.Add(item);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            //  listView1.Items.Remove(listView1.SelectedItems[0]);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text = "Wert";
                listView1.SelectedItems[0].SubItems[1].Text = "28";
                listView1.SelectedItems[0].SubItems[2].Text = "Рим";
            }
        }
    }
}
