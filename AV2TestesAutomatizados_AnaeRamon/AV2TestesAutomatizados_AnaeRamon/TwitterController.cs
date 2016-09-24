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

        public async Task <Status> RetweetAsync(ulong tweetID, SingleUserAuthorizer autho)
        {
            var twitterContext = new TwitterContext(autho);

            tweetID = 196991337554378752;

            var publicTweets =
                await
                (from tweet in twitterContext.Status
                 where tweet.Type == StatusType.Retweets &&
                       tweet.ID == tweetID
                 select tweet)
                .ToListAsync();

            if (publicTweets != null)
                publicTweets.ForEach(tweet =>
                {
                    if (tweet != null && tweet.User != null)
                        Console.WriteLine(
                            "@{0} {1} ({2})",
                            tweet.User.ScreenNameResponse,
                            tweet.Text,
                            tweet.RetweetCount);
                });
            return null;
        }
    }
}
