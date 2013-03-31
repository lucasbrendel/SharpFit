using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;

namespace SharpFit.OAuth
{
    public class OAuthLogin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void LoginCompleteHandler(object sender, LoginCompleteEventArgs e);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AccessTokenReceivedHandler(object sender, AccessTokenReceivedEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event LoginCompleteHandler LoginComplete;

        /// <summary>
        /// 
        /// </summary>
        public event AccessTokenReceivedHandler AccessTokenReceived;

        /// <summary>
        /// 
        /// </summary>
        public OAuthLogin()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void StartLogin()
        {
            var client = new RestClient(OAuthCredentials.APIAccessString);
            client.Authenticator = OAuth1Authenticator.ForRequestToken(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret);
            var request = new RestRequest("oauth/request_token");
            client.ExecuteAsync(request, response =>
            {
                if (OAuthCredentials.GetQueryParameter(response.Content, "oauth_problem") == String.Empty && response.Content != String.Empty)
                {
                    OAuthCredentials.OAuthToken = OAuthCredentials.GetQueryParameter(response.Content, "oauth_token");
                    OAuthCredentials.OAuthSecret = OAuthCredentials.GetQueryParameter(response.Content, "oauth_token_secret");
                    string authorizeUrl = OAuthCredentials.AuthorizeAccessString + "?oauth_token=" + OAuthCredentials.OAuthToken + "&locale=en_US&display=touch&requestCredentials=true";
                    NotifyLoginComplete(authorizeUrl);
                }

            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        private void NotifyLoginComplete(string url)
        {
            if (LoginComplete != null)
            {
                LoginComplete(this, new LoginCompleteEventArgs(url));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void NotifyAccessTokenReceived(AccessTokenReceivedEventArgs.AccessState state)
        {
            if (AccessTokenReceived != null)
            {
                AccessTokenReceived(this, new AccessTokenReceivedEventArgs(AccessTokenReceivedEventArgs.AccessState.Success));
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        public void GetAccessToken()
        {            
            var client = new RestClient(OAuthCredentials.APIAccessString);
            client.Authenticator = OAuth1Authenticator.ForAccessToken(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.OAuthToken, OAuthCredentials.OAuthSecret);
            var request = new RestRequest("oauth/access_token");
            request.AddParameter("oauth_verifier", OAuthCredentials.OAuthVerifier);
            request.AddParameter("oauth_token", OAuthCredentials.OAuthToken);
            client.ExecuteAsync(request, response =>
            {
                string token, secret;
                token = OAuthCredentials.GetQueryParameter(response.Content, "oauth_token");
                secret = OAuthCredentials.GetQueryParameter(response.Content, "oauth_token_secret");
                OAuthCredentials.SetAccessTokens(token, secret);
                OAuthCredentials.SetUserID(OAuthCredentials.GetQueryParameter(response.Content, "encoded_user_id"));
                NotifyAccessTokenReceived(AccessTokenReceivedEventArgs.AccessState.Success);
            });
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LoginCompleteEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Uri AurthorizeURL
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public LoginCompleteEventArgs(string url)
        {
            AurthorizeURL = new Uri(url);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AccessTokenReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public enum AccessState
        {
            Success,
            Failure
        };

        /// <summary>
        /// 
        /// </summary>
        public AccessState State
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public AccessTokenReceivedEventArgs(AccessState state)
        {
            State = state;
        }
    }
}
