using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace program
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10;
        }
        public string Label3Text
        {
            get { return label3.Text; }
            set { label3.Text = value; }
        }

        private void SetTextBoxes(Func<string, string> processor)
        {
            string labelcontent = Label3Text;
            string[] splitcontent = labelcontent.Split(',');

            for (int i = 0; i < splitcontent.Length; i++)
            {
                splitcontent[i] = processor(splitcontent[i]);
            }

            textBox1.Text = splitcontent.Length > 0 ? splitcontent[0] : "";
            textBox2.Text = splitcontent.Length > 1 ? splitcontent[1] : "";
            textBox3.Text = splitcontent.Length > 2 ? splitcontent[2] : "";
            textBox4.Text = splitcontent.Length > 3 ? splitcontent[3] : "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetTextBoxes(division => division);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetTextBoxes(division => division.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetTextBoxes(division => division.Replace(" ", "").Replace("　", ""));
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
            for (int i = 1; i <= intValue; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    richTextBox1.AppendText(j + " ");
                }
                richTextBox1.AppendText(Environment.NewLine);

            }
        }
        public string TextBox5Value
        {
            get { return textBox5.Text; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
