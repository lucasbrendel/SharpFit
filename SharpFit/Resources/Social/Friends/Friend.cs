// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;

namespace SharpFit.Resources.Social.FriendInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void GetFriends()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/friends.json", Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitBitFriends friends = new FitBitFriends();
                friends = JsonConvert.DeserializeObject<FitBitFriends>(response.Content);
                NotifyGetComplete(friends);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GetFriendsEventHandler(object sender, GetFriendsEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event GetFriendsEventHandler GetFriendsComplete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friend"></param>
        public void NotifyGetComplete(FitBitFriends friend)
        {
            if (GetFriendsComplete != null)
            {
                GetFriendsComplete(this, new GetFriendsEventArgs(friend));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetFriendsEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitFriends FriendList;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Friends"></param>
        public GetFriendsEventArgs(FitBitFriends Friends)
        {
            FriendList = Friends;
        }
    }
}
