using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            AV2Logic start = new AV2Logic();
            start.Menu();
        }

    }
}
