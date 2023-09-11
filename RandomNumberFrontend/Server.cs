using System;
using System.Net.Http;
using System.Text.Json;

namespace RandomNumberFrontend
{
	public class Server
	{
        private static readonly HttpClient client = new HttpClient();
        private static readonly string prefix = "http://localhost:7071/api";

        public static async Task<(bool, string)> StartGame(string nickname)
        {
            var response = await client.PostAsync($"{prefix}/StartGame?nickname={nickname}", null);
            var responseString = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, responseString);
        }

        public static async Task<(bool, string)> Play(string nickname, int myNumber)
        {
            var response = await client.PostAsync($"{prefix}/Play?nickname={nickname}&myNumber={myNumber}", null);
            var responseString = await response.Content.ReadAsStringAsync();
            return (response.IsSuccessStatusCode, responseString);
        }

        public static async Task<(bool, Dictionary<string, int>)> GlobalStatistics()
        {
            var response = await client.GetAsync($"{prefix}/GlobalStatistics");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JsonDocument.Parse(responseString);
            var responseDictionary = JsonSerializer.Deserialize<Dictionary<string, int>>(responseJson);
            return (response.IsSuccessStatusCode, responseDictionary);
        }

        public static async Task<(bool, List<int>)> UserStatistics(string nickname)
        {
            var response = await client.GetAsync($"{prefix}/UserStatistics?nickname={nickname}");
            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JsonDocument.Parse(responseString);
            var responseList = JsonSerializer.Deserialize<List<int>>(responseJson);
            return (response.IsSuccessStatusCode, responseList);
        }

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
