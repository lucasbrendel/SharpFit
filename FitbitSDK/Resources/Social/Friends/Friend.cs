// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using FitbitSDK.OAuth;

namespace FitbitSDK.Resources.Social.FriendInfo
{

    public class Friend
    {

        [JsonProperty("user")]
        public User User { get; set; }

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

        public delegate void GetFriendsEventHandler(object sender, GetFriendsEventArgs e);

        public event GetFriendsEventHandler GetFriendsComplete;

        public void NotifyGetComplete(FitBitFriends friend)
        {
            if (GetFriendsComplete != null)
            {
                GetFriendsComplete(this, new GetFriendsEventArgs(friend));
            }
        }
    }

    public class GetFriendsEventArgs : EventArgs
    {
        public FitBitFriends FriendList;

        public GetFriendsEventArgs(FitBitFriends Friends)
        {
            FriendList = Friends;
        }
    }
}
