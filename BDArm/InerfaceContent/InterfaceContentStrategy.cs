using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDArm.InerfaceContent
{
    public interface InterfaceContentStrategy
    {
        void InsertContent(string str);
    }
    public interface InterfaceUpdateContent
    {
        void UpdateMakerContent(string strOld,string strNew);
    }
}
