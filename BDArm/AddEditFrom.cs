using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace BDArm
{
    public partial class AddEditFrom : Form
    {
        //string Name;
        string commandT = "", commandU = "";
        int mode;
        public AddEditFrom(int mode,string Name)
        {
            InitializeComponent();
            EditTextBox.Text = Name;
            this.Name = Name;
            this.mode = mode;
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            Switcher(mode);
            AddOrEddit();
            DialogResult = DialogResult.OK;
        }


        private void Switcher(int mode)
        {
            switch (mode)
            {
                case 0: commandT = @"select count(*) from maker where name = @currentName";
                    commandU = @"update maker set name = @newName where name = @currentName";
                    break;
                case 1:
                    commandT = @"select count(*) from user where login = @currentName";
                    commandU = @"update user set login = @newName where login = @currentName";
                    break;
                case 2:
                    commandT = @"select count(*) from promo where code = @currentName";
                    commandU = @"update promo set code = @newName where code = @currentName";
                    break;
            }
        }

        private void AddOrEddit()
        {
            var sqlCommand = new NpgsqlCommand();
            using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
            {

                //Проверка на уникльность наименования
                sqlCommand = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = commandT
                };
                sqlCommand.Parameters.AddWithValue("@currentName", EditTextBox.Text);

                conn.Open();
                if ((long)sqlCommand.ExecuteScalar() != 0)
                {
                    MessageBox.Show("Такой производитель уже есть.");
                }
                else
                {
                    //Меняем имя
                    sqlCommand = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = commandU
                    };
                    sqlCommand.Parameters.AddWithValue("@currentName", Name);
                    sqlCommand.Parameters.AddWithValue("@newName", EditTextBox.Text);
                }
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
