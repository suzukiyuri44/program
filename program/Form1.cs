using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace program
{

    public partial class Form1 : Form
    {
        public string DataReceived { get; set; } = "";
        public Form1()
        {
            InitializeComponent();
            Bitmap bgc = new Bitmap(label5.Width, label5.Height);
            Graphics g = Graphics.FromImage(bgc);
            LinearGradientBrush gradBrush = new LinearGradientBrush(
            // ビットマップの領域サイズ
            g.VisibleClipBounds,
            //開始色
            Color.LightCyan,
            //終了色
            Color.Blue,
            //縦方向にグラデーション
            LinearGradientMode.Vertical);
            // ビットマップをグラデーション・ブラシで塗る
            g.FillRectangle(gradBrush, g.VisibleClipBounds);
            gradBrush.Dispose();
            g.Dispose();
            // ビットマップをボタンの背景にセット
            label5.Image = bgc;

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            timer1.Start();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            label4.BackColor = System.Drawing.Color.Yellow;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.BackColor = System.Drawing.Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.BackColor = System.Drawing.Color.Blue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "すべてのファイル (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Title = Message_manage.Title1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    textBox1.Text = filePath;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string filePath1 = textBox1.Text;

            try
            {
                if (File.Exists(filePath1))
                {
                    label3.Text = File.ReadAllText(filePath1);
                }
                else
                {
                    MessageBox.Show(
                     $"{Message_manage.Msg2}",
                     $"{Message_manage.Title4}",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error
                     );
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                     $"{Message_manage.Msg2}",
                     $"{Message_manage.Title4}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(label3.Text))
            {
                MessageBox.Show(
                $"{Message_manage.Msg2}",
                $"{Message_manage.Title4}",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
                return;
            }
            if (!string.IsNullOrEmpty(DataReceived))
            {
                label4.Text = DataReceived;
                return;
            }

            DialogResult result = MessageBox.Show(
                 $"{Message_manage.Msg1}",
                 $"{Message_manage.Title3}",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.OK)
            {
                Form2 form2 = new Form2();
                form2.Label3Text = label3.Text;
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    DataReceived = form2.TextBox5Value;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(label3.Text))
            {
                MessageBox.Show(
                $"{Message_manage.Msg2}",
                $"{Message_manage.Title4}",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
                return;
            }
            if (string.IsNullOrWhiteSpace(label4.Text))
            {
                MessageBox.Show(
                $"{Message_manage.Msg2}",
                $"{Message_manage.Title4}",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
                   );
                return;
            }
            try
            {
                string filePath = textBox1.Text;
                File.WriteAllText(filePath, label4.Text);
                DialogResult result = MessageBox.Show(
                    $"{Message_manage.Msg3}",
                    $"{Message_manage.Title2}",
                    MessageBoxButtons.OK
                    );
                if (result == DialogResult.OK)
                {
                    textBox1.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    DataReceived = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    $"{Message_manage.Msg4}",
                    $"{Message_manage.Title4}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               $"{Message_manage.Msg1}",
               $"{Message_manage.Title3}",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question
               );
            if (result == DialogResult.OK)
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
        }

    }
}
