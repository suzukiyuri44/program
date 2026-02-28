using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace From2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String labelcontent = label9.Text;
            String[] splitcontent = labelcontent.Split(',');
            if (splitcontent.Length > 0) textBox1.Text = splitcontent.Length > 0 ? splitcontent[0] : "";
            if (splitcontent.Length > 1) textBox2.Text = splitcontent.Length > 1 ? splitcontent[1] : "";
            if (splitcontent.Length > 2) textBox3.Text = splitcontent.Length > 2 ? splitcontent[2] : "";
            if (splitcontent.Length > 3) textBox4.Text = splitcontent.Length > 3 ? splitcontent[3] : "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String labelcontent = label9.Text;
            String[] splitcontent = labelcontent.Split(',');
            for (int i = 0; i < splitcontent.Length; i++)
            {
                splitcontent[i] = splitcontent[i].Trim();
            }
            if (splitcontent.Length > 0) textBox1.Text = splitcontent.Length > 0 ? splitcontent[0] : "";
            if (splitcontent.Length > 1) textBox2.Text = splitcontent.Length > 1 ? splitcontent[1] : "";
            if (splitcontent.Length > 2) textBox3.Text = splitcontent.Length > 2 ? splitcontent[2] : "";
            if (splitcontent.Length > 3) textBox4.Text = splitcontent.Length > 3 ? splitcontent[3] : "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String labelcontent = label9.Text;
            String[] splitcontent = labelcontent.Split(',');
            for (int i = 0; i < splitcontent.Length; i++)
            {
                splitcontent[i] = splitcontent[i].Replace(" ", "").Replace("　", "");
            }
            if (splitcontent.Length > 0) textBox1.Text = splitcontent.Length > 0 ? splitcontent[0] : "";
            if (splitcontent.Length > 1) textBox2.Text = splitcontent.Length > 1 ? splitcontent[1] : "";
            if (splitcontent.Length > 2) textBox3.Text = splitcontent.Length > 2 ? splitcontent[2] : "";
            if (splitcontent.Length > 3) textBox4.Text = splitcontent.Length > 3 ? splitcontent[3] : "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] textstorage = new string[]
           {
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text
           };
            string result = string.Join(",", textstorage);
            textBox5.Text = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int intValue = Convert.ToInt32(numericUpDown1.Value);
            richTextBox1.Clear();
            for (int i = 0; i <= intValue - 1; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    richTextBox1.AppendText(j.ToString() + " ");
                }
                richTextBox1.AppendText(Environment.NewLine);

            }
        }
    }
}
