using System;
using System.Net.Http;

namespace RandomNumberFrontend
{
	public class Server
	{
        private static readonly HttpClient client = new HttpClient();
        private static readonly string prefix = "http://localhost:7071/api";

        public static async Task<(bool, string)> Authorization(string nickname, string password)
        {
            var response = await client.PostAsync($"{prefix}/Authorization?nickname={nickname}&password={password}", null);
            var responseString = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, responseString);
        }

        public static async Task<(bool, string)> Registration(string nickname, string password)
        {
            var response = await client.PostAsync($"{prefix}/Registration?nickname={nickname}&password={password}", null);
            var responseString = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, responseString);
        }
    }
}
