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
using BDArm.InerfaceContent;

namespace BDArm
{
    public partial class MainForm : Form
    {
        public enum GridType
        {
            Maker,
            Promo
        };
        GridType gridType;

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

            GridUpdate();
            /*string mainStr = "select * from maker";
            GridUpdate(0,mainStr);
            mainStr = "select id,login,isadmin from users";
            GridUpdate(1,mainStr);
            mainStr = "select id,code from promo";
            GridUpdate(2, mainStr)*/
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
        public void GridUpdate()
        {           
            var sqlCommand = new NpgsqlCommand { };

            using (NpgsqlConnection conn = new NpgsqlConnection(ConnString))
            {
                DataSet dataSet;
                NpgsqlDataAdapter dataAdapter;
                string command = "select * from maker";
                try
                {
                    dataSet = new DataSet();
                    dataAdapter = new NpgsqlDataAdapter();
                    dataAdapter.SelectCommand = new NpgsqlCommand(command, conn);
                    dataAdapter.Fill(dataSet);                  
                    MainGridView.DataSource = dataSet.Tables[0];
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
            //DBCommand - в какой таблице что удалить
            if (gridType == GridType.Maker)
            {
                DBCommand = @"delete from maker where name = @currentName";
                Del(DBCommand);
                ShowMaker();
            }
            else if (gridType == GridType.Promo)
            {
                grid = UserGridView;
                DBCommand = @"delete from promo where code = @currentName";
                Del(DBCommand);
                ShowPCode();
            }
        }
        
        //Метод удаления
        public void Del(string DBCommand)
        {
            if (UserGridView.SelectedRows.Count != 0)
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
                    //MessageBox.Show(UserGridView.SelectedCells[1].ToString());
                    sqlCommand.Parameters.AddWithValue("@currentName", UserGridView.SelectedCells[1].Value);
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        //Добавить
        private void AddButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(MainTabControl.SelectedIndex.ToString());
            if(MainTabControl.SelectedIndex==1)
            {
                if (gridType==GridType.Maker)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.InsMaker, "");
                    addForm.ShowDialog();
                    ShowMaker();
                }
                else if (gridType == GridType.Promo)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.InsPromo, "");
                    addForm.ShowDialog();
                    ShowPCode();
                }
            }
        }

        public string str;
        //Загрузка производителей по кнопке
        private void ViewMakerButton_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Производители";
            ShowMaker();
        }

        //Метод загрузки производителей 
        public void ShowMaker()
        {
            gridType = GridType.Maker;
            Context context = new Context(new ShowMaker());
            context.VisionLogic(UserGridView);
        }

        //Метод загрузки промокодов
        public void ShowPCode()
        {
            gridType = GridType.Promo;
            Context context = new Context(new ShowPCode());
            context.VisionLogic(UserGridView);
        }

        //Загрузка промокодов по кнопке
        private void PCodeButton_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Промокоды";
            ShowPCode();
        }

        //Изменить
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 1)
            {
                if (gridType == GridType.Maker)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.UpdMaker, UserGridView.SelectedCells[1].Value.ToString());
                    addForm.ShowDialog();
                    ShowMaker();
                }
                else if (gridType == GridType.Promo)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.UpdPromo, UserGridView.SelectedCells[1].Value.ToString());
                    addForm.ShowDialog();
                    ShowPCode();
                }
            }
        }
    }
}