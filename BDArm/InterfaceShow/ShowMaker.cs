using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;
using BDArm.Properties;

namespace BDArm
{
    class ShowMaker : InterfaceGridViewStrategy
    {
        public void ShowOnGrid(DataGridView gridView)
        {
            string ConnString = new NpgsqlConnectionStringBuilder()
            {
                Port = Settings.Default.port,
                Host = Settings.Default.host,
                Username = Settings.Default.user,
                Password = Settings.Default.password,
                Database = Settings.Default.database,
            }.ConnectionString;

            string command = "select * from maker";
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
                    gridView.DataSource = dataSet.Tables[0];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    class ShowPCode : InterfaceGridViewStrategy
    {
        public void ShowOnGrid(DataGridView gridView)
        {
            string ConnString = new NpgsqlConnectionStringBuilder()
            {
                Port = Settings.Default.port,
                Host = Settings.Default.host,
                Username = Settings.Default.user,
                Password = Settings.Default.password,
                Database = Settings.Default.database,
            }.ConnectionString;

            string command = "select * from promo";
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
                    gridView.DataSource = dataSet.Tables[0];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    class ShowModel : InterfaceGridViewStrategy
    {
        public void ShowOnGrid(DataGridView gridView)
        {
            string ConnString = new NpgsqlConnectionStringBuilder()
            {
                Port = Settings.Default.port,
                Host = Settings.Default.host,
                Username = Settings.Default.user,
                Password = Settings.Default.password,
                Database = Settings.Default.database,
            }.ConnectionString;

            string command = "select * from model";
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
                    gridView.DataSource = dataSet.Tables[0];
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}