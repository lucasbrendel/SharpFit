using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitbitSDK.OAuth;

namespace FitbitSDKTest.OAuth
{
    [TestClass]
    public class OAuthCredentialsTest
    {
        [TestMethod]
        public void SetUserIDTest()
        {
            OAuthCredentials.SetUserID("MyUserID");
            Assert.AreEqual("MyUserID", OAuthCredentials.UserID);
        }

        [TestMethod]
        public void SetAccessTokensTest()
        {
            OAuthCredentials.SetAccessTokens("1122ede3d", "5hfh9g94h");
            Assert.AreEqual("1122ede3d", OAuthCredentials.AccessToken);
            Assert.AreEqual("5hfh9g94h", OAuthCredentials.AccessTokenSecret);
        }

        [TestMethod]
        public void SetConsumerTokensTest()
        {
            OAuthCredentials.SetConsumerTokens("hellom34t", "asdkfjml4f");
            Assert.AreEqual("hellom34t", OAuthCredentials.ConsumerKey);
            Assert.AreEqual("asdkfjml4f", OAuthCredentials.ConsumerSecret);
        }

        [TestMethod]
        public void GetQueryParameterTest()
        {
            string value = OAuthCredentials.GetQueryParameter("hello=5&goodbye=4", "goodbye");
            Assert.AreEqual("4", value);

            value = OAuthCredentials.GetQueryParameter("hello=5&goodbye=4", "solong");
            Assert.AreEqual(String.Empty, value);
        }

        [TestMethod]
        public void SetVerifier()
        {
            OAuthCredentials.SetVerifier("verified");
            Assert.AreEqual("verified", OAuthCredentials.OAuthVerifier);
        }
    }
}
