using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace BDArm.InerfaceContent
{
    class InsertContext
    {
        private InterfaceContentStrategy insertStrategy;

        public InsertContext() { }

        public InsertContext(InterfaceContentStrategy insertStrategy)
        {
            this.insertStrategy = insertStrategy;
        }
        public void SetStrategy(InterfaceContentStrategy insertStrategy)
        {
            this.insertStrategy = insertStrategy;
        }

        public void VisionLogic(string str)
        {
            this.insertStrategy.InsertContent(str);
        }
    }

    class UpdateContext
    {
        private InterfaceUpdateContent updateStrategy;

        public UpdateContext() { }

        public UpdateContext(InterfaceUpdateContent updateStrategy)
        {
            this.updateStrategy = updateStrategy;
        }

        public void SetStrategy(InterfaceUpdateContent updateStrategy)
        {
            this.updateStrategy = updateStrategy;
        }

        public void VisionLogic(string strOld,string strNew)
        {
            this.updateStrategy.UpdateMakerContent(strOld, strNew);
        }
    }
}
