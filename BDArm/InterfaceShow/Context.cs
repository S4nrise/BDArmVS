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

    class Context
    {
        private InterfaceGridViewStrategy gridViewStrategy;
        public Context() { }
        public Context(InterfaceGridViewStrategy gridViewStrategy)
        {
            this.gridViewStrategy = gridViewStrategy;
        }
        public void SetStrategy(InterfaceGridViewStrategy gridViewStrategy)
        {
            this.gridViewStrategy = gridViewStrategy;
        }

        public void VisionLogic(DataGridView gridView)
        {
            this.gridViewStrategy.ShowOnGrid(gridView);
        }
    }
}
