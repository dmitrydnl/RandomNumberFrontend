using System;
using System.Net.Http;

namespace RandomNumberFrontend
{
	public class Server
	{
        private static readonly HttpClient client = new HttpClient();

        public static async Task<(bool, string)> Registration(string nickname, string password)
        {
            var response = await client.PostAsync($"http://localhost:7071/api/Registration?nickname={nickname}&password={password}", null);
            var responseString = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, responseString);
        }
    }
}
