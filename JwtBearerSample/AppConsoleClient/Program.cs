using System;
using System.Net.Http;
using System.Net.Http.Headers;
using AspNetCore.Http.Extensions;
using Newtonsoft.Json.Linq;

namespace AppConsoleClient
{
    class Program
    {
        static string TokenUrl = "Https://localhost:45001/Token/GetToken";

        static string ApiUrl = "https://localhost:45002/HolleWorld/Test";

        static void Main(string[] args)
        {
            var token = GetToken();
            var data = GetData(token);
            Console.WriteLine(data);
            Console.ReadKey();
        }

        static string GetToken()
        {
            HttpClient client = new HttpClient();
            var userInfo = new { UserName = "admin", Password = "123456" };
            var response = client.PostAsJsonAsync(TokenUrl, userInfo).Result;
            var jsonObject = response.Content.ReadAsJsonAsync<JObject>().Result;
            return jsonObject["token"].Value<string>();
        }

        static string GetData(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client.GetStringAsync(ApiUrl).Result;
        }
    }
}
