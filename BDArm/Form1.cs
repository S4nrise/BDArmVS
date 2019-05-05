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
            Model,
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
            AddButton.Text = "Обновить";
            AddButton.Visible = true;
            DelButton.Visible = true;
            AddProductButton.Visible = true;

            MainGridUpdate();
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
            AddProductButton.Visible = false;
        }

        //Обновление для grid
        public void MainGridUpdate()
        {           
            var sqlCommand = new NpgsqlCommand { };

            using (NpgsqlConnection conn = new NpgsqlConnection(ConnString))
            {
                DataSet dataSet;
                NpgsqlDataAdapter dataAdapter;
                string command = @"select product.id as ""ID"",maker.mname as ""Производитель"",model.name as ""Модель"",
                                    category.name as ""Категория"",product.sales as ""Колличество проданых едениц"",
                                    product.price as ""Цена (RUB)"",product.pcount as ""Всего едениц"" from product
                                    join maker on maker.id = product.makerID
                                    join model on model.id = product.modelID
                                    join category on category.id = product.category";
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
        private void DelButton_Click(object sender, EventArgs e)
        {
            string DBCommand = "";
            var grid = new DataGridView();
            //Удаление в главной вкладке
            if (MainTabControl.SelectedIndex == 0)
            {
                DBCommand = @"delete from product where id = @currentName";
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
                    sqlCommand.Parameters.AddWithValue("@currentName", MainGridView.SelectedCells[0].Value);
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }
                MainGridUpdate();
            }
            //Удаление во вкладке со справочниками
            else if (MainTabControl.SelectedIndex == 1)
            {
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
            if (MainTabControl.SelectedIndex == 0)
            {
                MainGridUpdate();
            }
            else if (MainTabControl.SelectedIndex == 1)
            {
                if (gridType==GridType.Maker)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.InsMaker, "", "");
                    addForm.ShowDialog();
                    ShowMaker();
                }
                else if (gridType == GridType.Promo)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.InsPromo, "", "");
                    addForm.ShowDialog();
                    ShowPCode();
                }
            }
        }

        //Загрузка производителей по кнопке
        private void ViewMakerButton_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Таблица: Производители";
            ShowMaker();
        }

        //Загрузка моделей по кнопке
        private void ModelButton_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Таблица: Модели";
            ShowModel();
        }

        //Загрузка промокодов по кнопке
        private void PCodeButton_Click(object sender, EventArgs e)
        {
            tabPage2.Text = "Таблица: Промокоды";
            ShowPCode();
        }

        //Метод загрузки производителей 
        public void ShowMaker()
        {
            gridType = GridType.Maker;
            Context context = new Context(new ShowMaker());
            context.VisionLogic(UserGridView);
        }

        //Метод загрузки промокодов
        public void ShowModel()
        {
            gridType = GridType.Model;
            Context context = new Context(new ShowModel());
            context.VisionLogic(UserGridView);
        }

        //Метод загрузки промокодов
        public void ShowPCode()
        {
            gridType = GridType.Promo;
            Context context = new Context(new ShowPCode());
            context.VisionLogic(UserGridView);
        }

        //Кнопка добавить новый товар
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                MainGridUpdate();
            }
        }

        //Изменить
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if(MainTabControl.SelectedIndex == 0)
            {
                MainGridUpdate();
            }
            else if (MainTabControl.SelectedIndex == 1)
            {
                //??Подуумать как заносить старую дату в календарь
                if (gridType == GridType.Maker)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.UpdMaker, UserGridView.SelectedCells[1].Value.ToString(),"");
                    addForm.ShowDialog();
                    ShowMaker();
                }
                else if (gridType == GridType.Promo)
                {
                    AddForm addForm = new AddForm(AddForm.InsOrUpd.UpdPromo, UserGridView.SelectedCells[1].Value.ToString(),"");
                    addForm.ShowDialog();
                    ShowPCode();
                }
            }
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 0)
            {
                AddButton.Text = "Обновить";
            }
            else
            {
                AddButton.Text = "Добавить";
            }
        }
    }
}