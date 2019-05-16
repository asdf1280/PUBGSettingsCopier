using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PUBGSettingsCopier {
    public partial class Form2 : Form {
        public Form2(Point loc) {
            InitializeComponent();
            Location = loc;
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://www.youtube.com/luopis");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            MessageBox.Show("이메일: bycommandntwk@gmail.com\nGitHub: dhkim0800\n제 프로그램을 이용해주신 여러분들에게 진심으로 감사의 말씀을 드립니다.", "APPLE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Form2_Load(object sender, EventArgs e) {
            label1.Text += " " + Properties.Settings.Default.Version;
        }
    }
}
