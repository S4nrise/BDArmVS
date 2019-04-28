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
using BDArm.Properties;
using Npgsql;

namespace BDArm
{
    public partial class MainForm : Form
    {
        //Настройка подключкения через settings файл
        public static string ConnString = new NpgsqlConnectionStringBuilder()
        {
            Port = Settings.Default.port,
            Host = Settings.Default.host,
            Username = Settings.Default.user,
            Password = Settings.Default.password,
            Database = Settings.Default.database,
        }.ConnectionString;

        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(816, 258);
        }

        //Login
        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var authorizationForm = new AuthorizationForm();

            //Проверка на админа
            if (authorizationForm.ShowDialog() == DialogResult.OK)
            {
                if (authorizationForm.isAdmin == 1)
                {
                    LoginPreset();
                }
                else
                {
                    Visible = false;
                    var userForm = new UserForm(authorizationForm.userName, this);
                    userForm.ShowDialog();
                }
            }
        }

        //Log out
        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogoutPreset();
        }

        //Пресет для логина админа
        private void LoginPreset()
        {
            TempLabel.Visible = false;
            this.Size = new Size(816, 618);
            ChekStatusLabel.Text = "Статус: Подключено";
            MainTabControl.Visible = true;
            ChangeButton.Visible = true;
            AddButton.Visible = true;
            DelButton.Visible = true;

            string mainStr = "select * from maker";
            GridUpdate(0,mainStr);
            mainStr = "select id,login,isadmin from users";
            GridUpdate(1,mainStr);
            mainStr = "select id,code from promo";
            GridUpdate(2, mainStr);
        }

        //Пресет для выхода из основной формы
        private void LogoutPreset()
        {
            this.Size = new Size(816, 258);
            TempLabel.Visible = true;
            ChekStatusLabel.Text = "Статус: Нет подключения";
            MainTabControl.Visible = false;
            ChangeButton.Visible = false;
            AddButton.Visible = false;
            DelButton.Visible = false;
        }

        //Обновление для grid
        public void GridUpdate(int GridMode,string command)
        {
            var grid = new DataGridView();
            //Какой grid обновить
            switch (GridMode)
            {
                case 0: grid = MainGridView;
                    break;
                case 1: grid = UserGridView;
                    break;
                case 2: grid = PromoGridView;
                    break;
            }
            var sqlCommand = new NpgsqlCommand { };

            using (NpgsqlConnection conn = new NpgsqlConnection(ConnString))
            {
                DataSet dataSet;
                NpgsqlDataAdapter dataAdapter;
                //string command = "select * from maker";
                try
                {
                    dataSet = new DataSet();
                    dataAdapter = new NpgsqlDataAdapter();
                    dataAdapter.SelectCommand = new NpgsqlCommand(command, conn);
                    dataAdapter.Fill(dataSet);                  
                    grid.DataSource = dataSet.Tables[0];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Удалить
        public string command = "",DBCommand= "";
        public int selector;
        private void DelButton_Click(object sender, EventArgs e)
        {
            var grid = new DataGridView();
            //command - Команда для GridUpdate какая таблица загрузится
            //selector - Какой грид обновить 
            //DBCommand - в какой таблице что удалить
            switch (MainTabControl.SelectedIndex)
            {
                case 0: grid = MainGridView;
                    DBCommand = @"delete from maker where name = @currentName";
                    command = "select * from maker";
                    selector = 0;
                    break;
                case 1: grid = UserGridView;
                    DBCommand = @"delete from users where login = @currentName";
                    command = "select id,login,isadmin from users";
                    selector = 1;
                    break;
            }
            if (grid.SelectedRows.Count != 0)
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnString))
                {
                    conn.Open();
                    var sqlCommand = new NpgsqlCommand { };
                    sqlCommand = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = DBCommand
                    };
                    MessageBox.Show(grid.SelectedCells[1].ToString());
                    sqlCommand.Parameters.AddWithValue("@currentName", grid.SelectedCells[1].Value);
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
                GridUpdate(selector,command);
            }
        }

        //Добавить
        private void AddButton_Click(object sender, EventArgs e)
        {
            var grid = new DataGridView();
            if (MainTabControl.SelectedIndex == 1)
            {
                return;
            }
            else
            { 
                switch (MainTabControl.SelectedIndex)
                {
                    case 0:
                        grid = MainGridView;
                        DBCommand = @"delete from maker where name = @currentName";
                        command = "select * from maker";
                        selector = 0;
                        break;
                    case 1:
                        grid = UserGridView;
                        DBCommand = @"delete from users where login = @currentName";
                        command = "select * from users";
                        selector = 1;
                        break;
                    case 2:
                        grid = UserGridView;
                        DBCommand = @"delete from promo where code = @currentName";
                        command = "select * from code";
                        selector = 2;
                        break;
                }
                var AddForm = new AddForm(MainTabControl.SelectedIndex);

                if (AddForm.ShowDialog() == DialogResult.OK)
                {
                    GridUpdate(selector, command);
                }
            }
        }

        public string str;
        //Изменить
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            var grid = new DataGridView();
            switch (MainTabControl.SelectedIndex)
            {
                case 0:
                    grid = MainGridView;
                    DBCommand = @"delete from maker where name = @currentName";
                    command = "select * from maker";
                    selector = 0;
                    break;
                case 1:
                    grid = UserGridView;
                    DBCommand = @"delete from users where login = @currentName";
                    command = "select * from users";
                    selector = 1;
                    break;
                case 2:
                    grid = UserGridView;
                    DBCommand = @"delete from promo where code = @currentName";
                    command = "select * from code";
                    selector = 2;
                    break;
            }
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnString))
            {
                conn.Open();
                var sqlCommand = new NpgsqlCommand { };
                sqlCommand = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = DBCommand
                };
                MessageBox.Show(MainGridView.SelectedCells[1].ToString());
                sqlCommand.Parameters.AddWithValue("@currentName", MainGridView.SelectedCells[1].Value);
                str = (string)sqlCommand.ExecuteScalar();
                sqlCommand.Dispose();
                conn.Close();
            }

            var editForm = new AddEditFrom(MainTabControl.SelectedIndex,str);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                GridUpdate(selector,command);
            }
        }
    }
}