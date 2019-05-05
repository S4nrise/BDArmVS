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
using BDArm.InerfaceContent;

namespace BDArm
{
    public partial class AddForm : Form
    {
        public enum InsOrUpd
        {
            InsMaker,
            UpdMaker,
            InsPromo,
            UpdPromo,
            InsModel,
            UpdModel
        }

        public InsOrUpd insOrUpd;
        public string strOld="";
        public AddForm(InsOrUpd insOrUpd,string str, string date)
        {
            InitializeComponent();

            if (insOrUpd == InsOrUpd.InsMaker)
            {
                CompleteButton.Text = "Добавить производителя";
                this.insOrUpd = InsOrUpd.InsMaker;
                InsertDateTimePicker.Visible = false;
            }
            else if (insOrUpd == InsOrUpd.UpdMaker)
            {
                CompleteButton.Text = "Изменить производителя";
                this.insOrUpd = InsOrUpd.UpdMaker;
                EditTextBox.Text = str;
                strOld = str;
                InsertDateTimePicker.Visible = false;
            }
            else if (insOrUpd == InsOrUpd.InsPromo)
            {
                CompleteButton.Text = "Добавить промокод";
                this.insOrUpd = InsOrUpd.InsPromo;
                InsertDateTimePicker.Visible = true;
            }
            else if (insOrUpd == InsOrUpd.UpdPromo)
            {
                CompleteButton.Text = "Изменить промокод";
                EditTextBox.Text = str;
                this.insOrUpd = InsOrUpd.UpdPromo;
                strOld = str;
                InsertDateTimePicker.Visible = true;
            }
            else if (insOrUpd == InsOrUpd.InsModel)
            {
                CompleteButton.Text = "Добавить модель";
                this.insOrUpd = InsOrUpd.InsModel;
                InsertDateTimePicker.Visible = false;
            }
        }       

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (insOrUpd == InsOrUpd.InsMaker)
            {
                InsertContext insertContext = new InsertContext(new InsertContentMaker());
                insertContext.VisionLogic(EditTextBox.Text, InsertDateTimePicker.Value.ToShortDateString());
            }
            else if (insOrUpd == InsOrUpd.InsPromo)
            {
                InsertContext insertContext = new InsertContext(new InsertPromo());
                insertContext.VisionLogic(EditTextBox.Text, InsertDateTimePicker.Value.ToShortDateString());
            }
            else if (insOrUpd == InsOrUpd.InsModel)
            {
                InsertContext insertContext = new InsertContext(new InsertModel());
                insertContext.VisionLogic(EditTextBox.Text, InsertDateTimePicker.Value.ToShortDateString());
            }
            else if (insOrUpd == InsOrUpd.UpdMaker)
            {
                UpdateContext updateContext = new UpdateContext(new UpdateContentMaker());
                updateContext.VisionLogic(strOld, EditTextBox.Text, InsertDateTimePicker.Value.ToShortDateString());
            }
            else if (insOrUpd == InsOrUpd.UpdPromo)
            {
                UpdateContext updateContext = new UpdateContext(new UpdatePromoContent());
                updateContext.VisionLogic(strOld, EditTextBox.Text, InsertDateTimePicker.Value.ToShortDateString());
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
