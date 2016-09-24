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
        
        public static List<ulong> BuscarTwitters(SingleUserAuthorizer autho, string searchTerm)
        {
            List<ulong> statusTwitters = new List<ulong>();
            var twitterContext = new TwitterContext(autho);

            var srch =
               Enumerable.SingleOrDefault((from search in twitterContext.Search
                                           where search.Type == SearchType.Search &&
                                           search.Query == searchTerm &&
                                           search.Count == 5
                                           select search));
                      
            if (srch != null && srch.Statuses.Count > 0)
            {
                foreach (var statuses in srch.Statuses)
                {
                    statusTwitters.Add(statuses.StatusID);
                }
                return statusTwitters;
            }

            return null;
        }
    }
}
