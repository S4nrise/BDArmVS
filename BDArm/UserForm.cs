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
using Npgsql;

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

        private void ActivatePCodeButton_Click(object sender, EventArgs e)
        {
            var sqlCommand = new NpgsqlCommand();
            using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
            {

                //Проверка на уникльность наименования
                sqlCommand = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"select count(*) from promo where code = @currentName"
                };
                sqlCommand.Parameters.AddWithValue("@currentName", ActivatePCodeTextBox.Text);

                conn.Open();
                if ((long)sqlCommand.ExecuteScalar() == 0)
                {
                    MessageBox.Show("Такой промокод не зарегистрирован");
                }
                else
                {
                    //Меняем статус промокода 
                    sqlCommand = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = @"update promo set status = 1 where code = @currentName"
                    };
                    sqlCommand.Parameters.AddWithValue("@currentName", ActivatePCodeTextBox.Text);
                    //sqlCommand.Parameters.AddWithValue("@newName", strNew);
                    StatusPCodeLabel.Text = "Ваш промокод активирован";
                    StatusPCodeLabel.Visible = true;
                }
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
