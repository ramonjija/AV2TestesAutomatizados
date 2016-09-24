using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
