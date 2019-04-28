using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Text.RegularExpressions;

namespace BDArm.Classes
{
    class ChekText
    {
        // Функция для проверки, пуста ли строка
        public bool isStringEmpty(string s)
        {
            if (s == "")
                return true;
            return false;
        }
        
        // Функция для проверки строки на наличие в ней недопустимых элементов
        public bool isStringDeadly(string s)
        {
            Regex r = new Regex(@"[*; ]");
            if (r.IsMatch(s))
                return true;
            return false;
        }
    }
}
