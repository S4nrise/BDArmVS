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
    public partial class AddForm : Form
    {
        public int mode;
        public AddForm(int mode)
        {
            InitializeComponent();
            this.mode = mode;
        }

        public string command = "", selector = "", DBCommand = "",AddDBCommand= "";
        public void Add()
        {
            var grid = new DataGridView();
            switch (mode)
            {
                case 0:
                    DBCommand = @"select count(*) from maker where name = @currentName";
                    AddDBCommand = @"insert into maker values ((select max(id)+1 from maker), @newName)";
                    command = "select * from maker";
                    break;
                case 1:
                    DBCommand = @"select count(*) from user where login = @currentName";
                    command = "select * from users";
                    AddDBCommand = @"insert into user values ((select max(id)+1 from user), @newName)";
                    break;
                case 2:
                    DBCommand = @"select count(*) from promo where code = @currentName";
                    command = "select * from promo";
                    AddDBCommand = @"insert into promo values ((select max(id)+1 from promo), @newName)";
                    break;
            }

            var sqlCommand = new NpgsqlCommand();
            using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
            {

                //Проверка на уникльность наименования
                sqlCommand = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = DBCommand
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
                        CommandText = AddDBCommand
                    };
                    sqlCommand.Parameters.AddWithValue("@newName", EditTextBox.Text);
                }
                try
                {
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.StackTrace);
                }
                conn.Close();
            }
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            Add();
            DialogResult = DialogResult.OK;
        }
    }
}
