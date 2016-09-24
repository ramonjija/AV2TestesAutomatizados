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
            //Test();
            wakeupBoot();
        }
        

        private static void wakeupBoot()
        {

            Console.WriteLine("Wake Up Boot Twitter!");
            
            var _twitterController = new TwitterConnector();
            SingleUserAuthorizer authorizer = _twitterController.authorization();
            Console.WriteLine("Conectado ao twitter.");
            Console.WriteLine("Varrendo o twitter com as palavras cadastradas...");


            //metodos com o twitter 
            List<ulong> arrayTwitters = TwitterController.BuscarTwitters(authorizer, "specflow");
            TwitterController.RetweetAsync(authorizer, arrayTwitters);

            Console.WriteLine("Retweeted Acabou");
            Console.WriteLine("");
            Console.ReadKey();
        }

        private static void Test()
        {
            MenuOperations start = new MenuOperations();
            start.Menu();

        }
    }
}
