using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;

namespace SharpFit.OAuth
{
    public class OAuthCredentials
    {
        public const string APIAccessString = "https://api.fitbit.com/";

        public const string AuthorizeAccessString = "https://www.fitbit.com/oauth/authorize";

        public static string OAuthVerifier
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ConsumerKey
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ConsumerSecret
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string AccessToken
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string AccessTokenSecret
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string UserID;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void SetUserID(string id)
        {
            UserID = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="accessTokenSecret"></param>
        public static void SetAccessTokens(string accessToken, string accessTokenSecret)
        {
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumerKey"></param>
        /// <param name="consumerSecret"></param>
        public static void SetConsumerTokens(string consumerKey, string consumerSecret)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static string GetQueryParameter(string input, string parameterName)
        {
            foreach (string item in input.Split('&'))
            {
                var parts = item.Split('=');
                if (parts[0] == parameterName)
                {
                    return parts[1];
                }
            }
            return String.Empty;
        }

        public static void SetVerifier(string verifier)
        {
            OAuthVerifier = verifier;
        }

        public static string OAuthToken { get; set; }

        public static string OAuthSecret { get; set; }

        public const string APIVersion = "1";
        public const string APIAccessStringWithVersion = APIAccessString + APIVersion;
    }
}
