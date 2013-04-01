using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.Events;
using SharpFit.OAuth;
using System.Collections.Generic;

namespace SharpFit.Resources.User
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitUser
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user")]
        public Profile User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void GetUserInfo()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/profile.json");
            client.ExecuteAsync(request, response =>
            {
                FitBitUser p = new FitBitUser();
                p = JsonConvert.DeserializeObject<FitBitUser>(response.Content);
                NotifyProfileComplete(p);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GetProfileHandler(object sender, ProfileEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event GetProfileHandler GetProfileCompleted;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void UpdateUserInfo(Dictionary<string, string> param)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/profile.json", Method.POST);
            foreach (KeyValuePair<string, string> p in param)
            {
                request.AddParameter(p.Key, p.Value);
            }
            client.ExecuteAsync(request, response =>
            {
                FitBitUser prof = new FitBitUser();
                prof = JsonConvert.DeserializeObject<FitBitUser>(response.Content);
                NotifyProfileComplete(prof);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        private void NotifyProfileComplete(FitBitUser profile)
        {
            if (GetProfileCompleted != null)
            {
                GetProfileCompleted(this, new ProfileEventArgs(profile));
            }
        } 
    }


}
