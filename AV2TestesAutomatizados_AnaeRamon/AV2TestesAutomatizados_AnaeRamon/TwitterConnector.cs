using LinqToTwitter;

namespace AV2TestesAutomatizados_AnaeRamon
{
    public class TwitterConnector
    {
        public SingleUserAuthorizer authorization()
        {

           SingleUserAuthorizer authorizer = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = "nYHCaQAkZ695OUiiN52E6UHWa",
                    ConsumerSecret = "wkBV85KVAR8ecbI7Z5i5YsoVbgegaGUnv26eBichhbj86C703h",
                    AccessToken = "775706440128487424-q2Wp7EUFIMBxX8li9CzdSqpmnRyPmZ9",
                    AccessTokenSecret = "yWrfJ2lvZuUIeMpBRefhnawN7CFUvlK6y3kDCVx8iHK1b"
                }
            };

            return authorizer;
        }
    }
}
