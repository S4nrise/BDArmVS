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
            UpdPromo
        }

        public InsOrUpd insOrUpd;
        public string strOld="";
        public AddForm(InsOrUpd insOrUpd,string str)
        {
            InitializeComponent();

            if (insOrUpd == InsOrUpd.InsMaker)
            {
                CompleteButton.Text = "Добавить производителя";
                this.insOrUpd = InsOrUpd.InsMaker;
            }
            else if (insOrUpd == InsOrUpd.UpdMaker)
            {
                CompleteButton.Text = "Изменить производителя";
                this.insOrUpd = InsOrUpd.UpdMaker;
                EditTextBox.Text = str;
                strOld = str;
            }
            else if (insOrUpd == InsOrUpd.InsPromo)
            {
                CompleteButton.Text = "Добавить промокод";
                this.insOrUpd = InsOrUpd.InsPromo;
            }
            else if (insOrUpd == InsOrUpd.UpdPromo)
            {
                CompleteButton.Text = "Изменить промокод";
                this.insOrUpd = InsOrUpd.UpdPromo;
            }
        }       

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (insOrUpd == InsOrUpd.InsMaker)
            {
                InsertContext insertContext = new InsertContext(new InsertContentMaker());
                insertContext.VisionLogic(EditTextBox.Text);
            }
            else if (insOrUpd == InsOrUpd.InsPromo)
            {
                InsertContext insertContext = new InsertContext(new InsertPromo());
                insertContext.VisionLogic(EditTextBox.Text);
            }
            else if (insOrUpd == InsOrUpd.UpdMaker)
            {
                UpdateContext updateContext = new UpdateContext(new UpdateContentMaker());
                updateContext.VisionLogic(strOld, EditTextBox.Text);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
