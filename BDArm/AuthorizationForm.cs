using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using BDArm.Classes;
using Npgsql;
using BDArm.Properties;

namespace BDArm
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            PassTextBox.PasswordChar = '*';
            RePassTextBox.PasswordChar = '*';
        }
        public int isAdmin;
        public string userName;

        private void LogButton_Click(object sender, EventArgs e)
        {
            ChekText Chek = new ChekText();
            //Проверка на пустые строки
            if (Chek.isStringEmpty(LogTextBox.Text) || Chek.isStringEmpty(PassTextBox.Text))
            {
                MessageBox.Show("Присутствуют пустые поля");
                return;
            }

            //Проверка на запрещенные символы
            if (Chek.isStringDeadly(LogTextBox.Text) || Chek.isStringDeadly(PassTextBox.Text))
            {
                MessageBox.Show("Присутствуют запрещенные символы");
                return;
            }

            // Подключаемся в postgres
            //string connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=1;Database=Arm;";
            /* connString = new NpgsqlConnectionStringBuilder()
            {
                Host = Settings.Default.host,
                Port = Settings.Default.port,
                Database=Settings.Default.database,
                Username=Settings.Default.user,
                Password=Settings.Default.password
            }.ConnectionString;*/

            var sqlCommand = new NpgsqlCommand { };

            //Логин
            if (LogButton.Text == "Login")
            {
                // Подключение к БД
                using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось осуществить вход в бд");
                        return;
                    }

                    // Проверяем, есть ли человек с таким логинов в базе
                    try
                    {
                        sqlCommand = new NpgsqlCommand
                        {
                            Connection = conn,
                            CommandText = @"select count(*) from users where login = @currentLogin"
                        };

                        sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);

                        // Если такого логина не нашли
                        if ((long)sqlCommand.ExecuteScalar() == 0)
                        {
                            MessageBox.Show("Пожалуйста, проверьте логин");
                            conn.Close();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось осуществить вход");
                        conn.Close();
                        return;
                    }

                    //Добавить пользователя в БД
                    using (var cryp = new SHA1CryptoServiceProvider())
                    {
                        //Хэширование пароля
                        string str = BitConverter.ToString(cryp.ComputeHash(Encoding.UTF8.GetBytes(PassTextBox.Text)));

                        //Хэширование с помощью доп строки
                        str = BitConverter.ToString(cryp.ComputeHash(Encoding.UTF8.GetBytes(str + "Roflan")));

                        // проверка пароля
                        try
                        {
                            sqlCommand = new NpgsqlCommand
                            {
                                Connection = conn,
                                CommandText = @"SELECT COUNT(*) FROM users WHERE login = @currentLogin AND pass = @currentPass"
                            };

                            sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@currentPass", str);

                            if ((long)sqlCommand.ExecuteScalar() == 0)
                            {
                                MessageBox.Show("Проверьте правильность ввода пароля!");

                                conn.Close();
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Не удалось войти в систему! " + ex.Message);
                            conn.Close();
                            return;
                        }
                    }
                    //Запись в переменную статус админа
                    sqlCommand = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = @"select isadmin from users where login = @currentLogin"
                    };
                    sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);
                    isAdmin = (int)sqlCommand.ExecuteScalar();

                    //Запись в переменную логина
                    sqlCommand = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = @"select Login from users where login = @currentLogin"
                    };
                    sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);
                    userName = (string)sqlCommand.ExecuteScalar();

                    sqlCommand.Dispose();
                    conn.Close();
                    MessageBox.Show("Вход успешно выполнен");
                }
            }
            else
            //Регистрация
            {
                if (PassTextBox.Text != RePassTextBox.Text)
                {
                    MessageBox.Show("Введенные пароли не совпадают");
                    return;
                }

                // Конннекшн
                using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось осуществить регистрацию");
                        return;
                    }

                    // Проверяем, есть ли человек с таким логинов в базе
                    try
                    {
                        sqlCommand = new NpgsqlCommand
                        {
                            Connection = conn,
                            CommandText = @"select count(*) from users where login = @currentLogin"
                        };

                        sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);

                        // Если такой логин нашли
                        if ((long)sqlCommand.ExecuteScalar() != 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                            conn.Close();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось осуществить регистрацию");
                        conn.Close();
                        return;
                    }
                    // Добавляем пользователя в базу
                    using (var cryp = new SHA1CryptoServiceProvider())
                    {
                        // Хэширование пароля
                        string str = BitConverter.ToString(cryp.ComputeHash(Encoding.UTF8.GetBytes(PassTextBox.Text)));

                        // Хэширование с помощью серийного номера жесткого диска
                        str = BitConverter.ToString(cryp.ComputeHash(Encoding.UTF8.GetBytes(str + "Roflan")));

                        // Добавляем в базу
                        try
                        {
                            sqlCommand = new NpgsqlCommand
                            {
                                Connection = conn,
                                CommandText = @"insert into users values ((select max(id) + 1 from users),@currentLogin, @saltedPass,  @isadmin)"
                            };

                            sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@saltedPass", str);
                            sqlCommand.Parameters.AddWithValue("@isadmin", 0);

                            sqlCommand.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Простите, не удалось осуществить регистрацию");
                            MessageBox.Show(ex.Message);
                            MessageBox.Show(ex.StackTrace);
                            conn.Close();
                            return;
                        }

                        sqlCommand.Dispose();
                        conn.Close();
                        MessageBox.Show("Регистрация успешно выполнена");
                    }
                    //Запись в переменную логина
                    conn.Open();
                    sqlCommand = new NpgsqlCommand
                    {
                        Connection = conn,
                        CommandText = @"select Login from users where login = @currentLogin"
                    };
                    sqlCommand.Parameters.AddWithValue("@currentLogin", LogTextBox.Text);
                    userName = (string)sqlCommand.ExecuteScalar();

                    sqlCommand.Dispose();
                    conn.Close();
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SwitchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SwitchLinkLabel.Text == "Нет профиля? Зарегистрируйся!")
            {
                SwitchLinkLabel.Text = "Уже зарегистрирован? Войди!";
                LogButton.Text = "Sign up";
                LogButton.Location = new Point(111, 256);
                RePassLabel.Visible = true;
                RePassTextBox.Visible = true;
            }
            else
            {
                SwitchLinkLabel.Text = "Нет профиля? Зарегистрируйся!";
                LogButton.Text = "Login";
                LogButton.Location = new Point(111, 196);
                RePassLabel.Visible = false;
                RePassTextBox.Visible = false;
            }
        }
    }
}