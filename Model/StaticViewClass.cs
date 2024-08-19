using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creating_Invoices.Model
{
    public static class StaticViewClass
    {

        public static string _mess;
        public static event Action Message;
        public static void Mess(string mess)
        {
            _mess = mess;
            Message.Invoke();
        }
    }
}
