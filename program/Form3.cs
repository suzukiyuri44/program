using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace program
{
    public partial class Form3 : Form
    {
        string[] days = { "", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        public Form3()
        {
            InitializeComponent();
            //radioButton1～7の文字設定
            radioButton1.Text = days[1];
            radioButton2.Text = days[2];
            radioButton3.Text = days[3];
            radioButton4.Text = days[4];
            radioButton5.Text = days[5];
            radioButton6.Text = days[6];
            radioButton7.Text = days[7];

        }

        //ラジオボタンテキスト表示
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                label1.Text = rb.Text;
            }
        }

        //コンボボックスのデータセット切り替え
        private void RadioButton_CheckedChanged1(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                LoadComboBoxData1();
            }
            else if (radioButton9.Checked)
            {
                LoadComboBoxData2();
            }
        }

        //コンボボックスのデータセット
        private void LoadComboBoxData1()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" });
            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        // データセット2
        private void LoadComboBoxData2()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "", "Jan", "Feb", "May", "Jun", "Jul", "Set", "Oct", "Aug", "Nov", "Dec" });
            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        //コンボボックス選択したデータをテキスト表示

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = (string)comboBox1.SelectedItem;
            label2.Text = selectedItem;
        }



        //bottom1のマウス操作
        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Yellow;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Yellow;
            button1.ForeColor = Color.Black;
        }

        //背景画像のレイアウト変更

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            panel5.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            panel5.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            panel5.BackgroundImageLayout = ImageLayout.Center;
        }

        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            bool allChecked = checkBox1.Checked && checkBox2.Checked && checkBox3.Checked;
            if (allChecked)
            {
                button1.Cursor = Cursors.Hand;
            }
            else
            {
                button1.Cursor = Cursors.Default;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                DialogResult result = MessageBox.Show(
                 $"{Message_manage.Msg4}",
                 $"{Message_manage.Title3}",
                MessageBoxButtons.OK
                );

            }
        }
    }
}
