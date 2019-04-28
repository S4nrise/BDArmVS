using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDArm.Classes;

namespace BDArm
{
    public partial class UserForm : Form
    {
        MainForm mainForm;
        public UserForm(string username,MainForm mainForm)
        {
            InitializeComponent();
            ChekStatusLabel.Text = "Статус: Подключено";
            HelloLabel.Text = "Привет, " + username;
            LogToolStripMenuItem.Enabled = false;
            this.mainForm = mainForm;
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm.Visible = true;
            Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Close();
        }
    }
}
