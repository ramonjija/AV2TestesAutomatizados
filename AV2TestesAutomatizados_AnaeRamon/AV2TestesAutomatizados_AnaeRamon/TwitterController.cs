using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;

namespace AV2TestesAutomatizados_AnaeRamon
{
    public class TwitterController
    {
        public static List<String> GetMostRecent200HomeTimeLine(SingleUserAuthorizer autho)
        {
            List<Status> currentTweets;
            List<String> myTweets = new List<string>();
            var twitterContext = new TwitterContext(autho);

            var tweets = from tweet in twitterContext.Status
                where tweet.Type == StatusType.Home &&
                      tweet.Count == 200
                select tweet;

            currentTweets = tweets.ToList();

            foreach (var current in currentTweets)
            {
                myTweets.Add(current.Text);
            }

            return myTweets;
        }

        public static async void RetweetAsync(SingleUserAuthorizer autho, List<ulong> statusTweets)
        {
            try
            {
                var twitterContext = new TwitterContext(autho);


                foreach (var statustweets in statusTweets)
                {
                    var retweet = await twitterContext.RetweetAsync(statustweets);

                    if (retweet != null &&
                        retweet.RetweetedStatus != null &&
                        retweet.RetweetedStatus.User != null)
                    {
                        Console.WriteLine("Retweeted um Tweet: ");
                        Console.WriteLine(
                            "\nUsuario: " + retweet.RetweetedStatus.User.ScreenNameResponse +
                            "\nTweet: " + retweet.RetweetedStatus.Text + "\n");
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("");
                Console.WriteLine(":::::::::::::::::ERRO NO RETWITTER :::::::::::::::::::::");
                Console.WriteLine("Esse tweet já foi retwitado ");
                Console.WriteLine("Não é possivel retwitar duas vezes ");
            }

        }
        
        public static List<ulong> BuscarTwitters(SingleUserAuthorizer autho, List<GeracaoPalavras.TermosDeBusca> listSearchTerm)
        {
            List<ulong> statusTwitters = new List<ulong>();
            var twitterContext = new TwitterContext(autho);         

            foreach (var searchTerm in listSearchTerm)
            {
                if (searchTerm.singular != null)
                {
                     var srchSingular =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.singular &&
                                                   search.Count == 5
                                                   select search));

                    foreach (var statuses in srchSingular.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                    
                }

                if (searchTerm.plural != null)
                {
                    var srchPlural =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.plural &&
                                                   search.Count == 5
                                                   select search));

                    foreach (var statuses in srchPlural.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                }
                if (searchTerm.minusculo != null)
                {
                    var srchMinusculo =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.minusculo &&
                                                   search.Count == 5
                                                   select search));

                    foreach (var statuses in srchMinusculo.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                }
                if (searchTerm.maiusculo != null)
                {
                    var srchMaiusculo =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.maiusculo &&
                                                   search.Count == 5
                                                   select search));
                    foreach (var statuses in srchMaiusculo.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                }
                if (searchTerm.semEspacos != null)
                {
                    var srchSemEspacos =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.semEspacos &&
                                                   search.Count == 5
                                                   select search));
                    foreach (var statuses in srchSemEspacos.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                }
                if (searchTerm.semCaracteresEspeciais != null)
                {
                    var srchsemCaracteresEspeciais =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.semCaracteresEspeciais &&
                                                   search.Count == 5
                                                   select search));

                    foreach (var statuses in srchsemCaracteresEspeciais.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                }
                if (searchTerm.palavraCadastrada != null)
                {
                    var srchPalavraCadastrada =
                       Enumerable.SingleOrDefault((from search in twitterContext.Search
                                                   where search.Type == SearchType.Search &&
                                                   search.Query == searchTerm.palavraCadastrada &&
                                                   search.Count == 5
                                                   select search));
                    foreach (var statuses in srchPalavraCadastrada.Statuses)
                    {
                        statusTwitters.Add(statuses.StatusID);
                    }
                }
            }

            var distinctIdStatus = statusTwitters.Distinct().ToList();
            return distinctIdStatus;

        }
    }
}
