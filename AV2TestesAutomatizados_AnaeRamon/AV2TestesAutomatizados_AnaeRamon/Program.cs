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
            
            //conexao com twitter 
            var _twitterController = new TwitterConnector();
            SingleUserAuthorizer authorizer = _twitterController.authorization();
            Console.WriteLine("Conectado ao twitter.");

            Console.WriteLine("Varrendo a timeline...");

            //metodos com o twitter 
            List<String> tweets = TwitterController.GetMostRecent200HomeTimeLine(authorizer);
            foreach (var tweet in tweets)
            {
                Console.WriteLine(tweet);
                
            }
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
