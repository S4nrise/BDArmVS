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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();

            // Берем данные из справочника с производителями в список        
            NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString);
            DataSet dSet;
            NpgsqlDataAdapter npgsqlDataAdapter;
            string CommandText = "select mname from maker order by mname";
            conn.Open();
            dSet = new DataSet();
            npgsqlDataAdapter = new NpgsqlDataAdapter();
            npgsqlDataAdapter.SelectCommand = new NpgsqlCommand(CommandText, conn);
            npgsqlDataAdapter.Fill(dSet);
            MakerComboBox.DataSource = dSet.Tables[0];
            MakerComboBox.DisplayMember = "mname";
            conn.Close();

            // Берем данные из справочника с моделями
            CommandText = "select name from model order by name";
            conn.Open();
            dSet = new DataSet();
            npgsqlDataAdapter = new NpgsqlDataAdapter();
            npgsqlDataAdapter.SelectCommand = new NpgsqlCommand(CommandText, conn);
            npgsqlDataAdapter.Fill(dSet);
            ModelComboBox.DataSource = dSet.Tables[0];
            ModelComboBox.DisplayMember = "name";
            conn.Close();

            // Берем данные из справочника с категориями
            CommandText = "select name from category order by name";
            conn.Open();
            dSet = new DataSet();
            npgsqlDataAdapter = new NpgsqlDataAdapter();
            npgsqlDataAdapter.SelectCommand = new NpgsqlCommand(CommandText, conn);
            npgsqlDataAdapter.Fill(dSet);
            CategoryСomboBox.DataSource = dSet.Tables[0];
            CategoryСomboBox.DisplayMember = "name";
            conn.Close();

            MakerComboBox.SelectedIndex = 0;
            ModelComboBox.SelectedIndex = 0;
            CategoryСomboBox.SelectedIndex = 0;
        }

        NpgsqlCommand sqlCommand = new NpgsqlCommand();
        
        enum mode
        {
            Maker,
            Model,
            Category
        }

        //Берем ID из нужной таблицы
        private int GetId(string text, mode mode)
        {
            string cmd="";
            if (mode == mode.Maker) cmd = @"select id from maker where mname = @currentName";
            else if (mode==mode.Model) cmd = @"select id from model where name = @currentName";
            else if (mode==mode.Category) cmd = @"select id from category where name = @currentName";

            int id;
            using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
            {
                conn.Open();
                sqlCommand = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = cmd
                };
                sqlCommand.Parameters.AddWithValue("@currentName", text);

                id = (int)sqlCommand.ExecuteScalar();

                conn.Close();
            }
            return id;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var makerID = GetId(MakerComboBox.Text,mode.Maker);
            var modelID = GetId(ModelComboBox.Text,mode.Model);
            var categoryID = GetId(CategoryСomboBox.Text,mode.Category);

            using (NpgsqlConnection conn = new NpgsqlConnection(MainForm.ConnString))
            {
                conn.Open();
                sqlCommand = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = @"insert into product values ((select max(id)+1 from product), @newMaker,@newModel,
                                    @newCategory,@newSales,@newPrice,@newCount)"
                };
                sqlCommand.Parameters.AddWithValue("@newMaker", makerID);
                sqlCommand.Parameters.AddWithValue("@newModel", modelID);
                sqlCommand.Parameters.AddWithValue("@newCategory", categoryID);
                sqlCommand.Parameters.AddWithValue("@newSales", SalesNumericUpDown.Value);
                sqlCommand.Parameters.AddWithValue("@newPrice", PriceNumericUpDown.Value);
                sqlCommand.Parameters.AddWithValue("@newCount", CountNumericUpDown.Value);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            

            DialogResult = DialogResult.OK;
        }
    }
}
