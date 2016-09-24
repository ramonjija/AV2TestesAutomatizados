using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToTwitter;


namespace AV2TestesAutomatizados_AnaeRamon
{
    class Program
    {

        static void Main(string[] args)
        {
            Test();
        }
       
        private static void Test()
        {
            MenuOperations start = new MenuOperations();
            start.Menu();

        }
    }
}
