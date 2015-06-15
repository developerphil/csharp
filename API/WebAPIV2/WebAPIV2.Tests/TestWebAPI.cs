using System;
using System.Net.Http;
using System.Threading;
using NUnit.Framework;
using Thinktecture.IdentityModel.Client;

namespace WebAPIV2.Tests
{
    [TestFixture]
    public class TestWebAPI
    {
        [Test]
        public void TestWeb()
        {
            var response = GetToken();
            CallService(response.AccessToken);

            var refreshResponse = RefreshToken(response.RefreshToken);
            CallService(refreshResponse.AccessToken);

            refreshResponse = RefreshToken(refreshResponse.RefreshToken);
            CallService(refreshResponse.AccessToken);
        }

        private static TokenResponse GetToken()
        {
            var client = new OAuth2Client(
                new Uri("http://webapiversiontwo.local/token"),
                "client1",
                "secret");

            var response = client.RequestResourceOwnerPasswordAsync("bob", "bob", null, null, new CancellationToken()).Result;
            return response;
        }

        private static TokenResponse RefreshToken(string refreshToken)
        {
            var client = new OAuth2Client(
                new Uri("http://webapiversiontwo.local/token"),
                "client1",
                "secret");

            var response = client.RequestRefreshTokenAsync(refreshToken, null, new CancellationToken()).Result;
            return response;
        }

        private static void CallService(string token)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);
            var response = client.GetStringAsync(new Uri("http://webapiversiontwo.local/api/identity")).Result;

            Console.WriteLine(response);
        }
    }
}
