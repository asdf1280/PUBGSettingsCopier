using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PUBGSettingsCopier {
    public partial class Form1 : Form {
        public Form1() {
            Properties.Settings.Default.Reload();
            Properties.Settings.Default.Save();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            label6.Text = "";
            panel1.BackColor = Color.FromArgb(219, 219, 219);
            if (Properties.Settings.Default.isLuopis) {
                Button b = new Button();
                b.Size = new Size(ClientSize.Width - 20, 30);
                b.Location = new Point(10, ClientSize.Height - b.Height - 10);
                b.Visible = true;
                b.FlatStyle = FlatStyle.Flat;
                b.BackColor = Color.Orange;
                b.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                b.Name = "LuopisButton";
                b.Text = "배그 꿀팁&&정보&&유출 - 유튜브 루오피스 바로가기";
                b.Click += new EventHandler(delegate (object sender2, EventArgs e2) {
                    Process.Start("https://www.youtube.com/luopis");
                });
                toolTip1.SetToolTip(b, "본 프로그램은 \"유튜브 루오피스\"와 함께합니다.");
                b.Visible = true;
                Console.WriteLine(b.Size + " " + b.Location);
                Controls.Add(b);
            }

            backColors.Add(button1, button1.BackColor);
            backColors.Add(button2, button2.BackColor);
            backColors.Add(button3, button3.BackColor);
        }

        private const string dtxt1 = "정상 작동!";
        private const string dtxt2 = "배그 설정파일이 없어서 내보내기 불가";
        private const string dtxt3 = "저장된 설정파일이 없어서 가져오기 불가";
        private const string dtxt4 = "배그도 안 해봤고 저장도 안 해보셨네요.";
        Dictionary<Button, Color> backColors = new Dictionary<Button, Color>();
        private void Timer1_Tick(object sender, EventArgs e) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + @"\TslGame\Saved\Config\WindowsNoEditor\GameUserSettings.ini";
            bool fe = File.Exists("GameSettings.ini");
            if (File.Exists(path) && fe) {
                button2.Enabled = true;
                button2.BackColor = backColors[button2];
                button1.Enabled = true;
                button1.BackColor = backColors[button1];
                label4.Text = dtxt1;
            } else if (fe) {
                button1.Enabled = false;
                button1.BackColor = ControlPaint.Dark(backColors[button1]);
                button2.Enabled = true;
                button2.BackColor = backColors[button2];
                label4.Text = dtxt2;
            } else if (File.Exists(path)) {
                button2.Enabled = false;
                button2.BackColor = ControlPaint.Dark(backColors[button2]);
                button1.Enabled = true;
                button1.BackColor = backColors[button1];
                label4.Text = dtxt3;
            } else {
                button1.Enabled = false;
                button1.BackColor = ControlPaint.Dark(backColors[button1]);
                button2.Enabled = false;
                button2.BackColor = ControlPaint.Dark(backColors[button2]);
                label4.Text = dtxt4;
            }

            button3.Enabled = fe;
            if (fe) {
                button3.BackColor = backColors[button3];
            } else {
                button3.BackColor = ControlPaint.Dark(backColors[button3]);
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + @"\TslGame\Saved\Config\WindowsNoEditor\GameUserSettings.ini";
            try {
                File.Copy(path, "GameSettings.ini", true);
                label6.Text = "성공적으로 내보냈습니다!";
                HandleMessage();
            } catch (Exception ex) {
                MessageBox.Show("파일 내보내기 중 오류가 발생하였습니다.\r\n오류 정보: " + ex.GetType().Name + " - " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + @"\TslGame\Saved\Config\WindowsNoEditor\GameUserSettings.ini";
            try {
                File.Copy("GameSettings.ini", path, true);
                label6.Text = "성공적으로 가져왔습니다!";
                HandleMessage();
            } catch (Exception ex) {
                MessageBox.Show("파일 가져오기 중 오류가 발생하였습니다.\r\n오류 정보: " + ex.GetType().Name + " - " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            try {
                File.Delete("GameSettings.ini");
                label6.Text = "성공적으로 삭제했습니다!";
                HandleMessage();
            } catch (Exception ex) {
                MessageBox.Show("파일 삭제 중 오류가 발생하였습니다.\r\n오류 정보: " + ex.GetType().Name + " - " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        long end = 0;
        private void HandleMessage() {
            if (end == 0) {
                end = Environment.TickCount + 1500;
                Thread trd = new Thread(new ThreadStart(delegate () {
                    //TODO
                    while (end > Environment.TickCount) ;
                    end = 0;
                    Invoke(new Action(delegate () {
                        label6.Text = "";
                    }));
                }));
                trd.IsBackground = true;
                trd.Start();
            } else {
                end = Environment.TickCount + 1500;
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            Form2 f2 = new Form2(Location);
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) {
            Random r = new Random();
            Func<int> fc = new Func<int>(delegate () {
                return (int)(r.NextDouble() * 256);
            });
            panel1.BackColor = Color.FromArgb(fc(), fc(), fc());
        }
    }
}
