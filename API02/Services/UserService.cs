using API02.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace API02.Services
{
    public class UserService
    {
        private static string baseUrl = "https://reqres.in/api/users";

        public static async Task<IEnumerable<User>> GetUsersAsync(HttpClient client)
        {
            string endpoint = baseUrl + "?per_page=12";
            var response = await client.GetAsync(endpoint);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json_str = await response.Content.ReadAsStringAsync();
                var src= Deserialize<Source>(json_str);
                return src.data;
            }
            return null;
        }

        public async static Task<User> GetUserAsync(int id,HttpClient client)
        {
            string endpoint = baseUrl + "/" + id;
            var response = await client.GetAsync(endpoint);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json_str = await response.Content.ReadAsStringAsync();
                var src = Deserialize<SourceSingle>(json_str);
                return src.data;
            }
            return null;
        }

        public async static Task<string> PostAsync(User user,HttpClient client)
        {
            string endpoint = baseUrl;
            string payload = "{\"name\":\"ilker turan\",\"job\": \"teacher\"}";
            HttpContent body = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(endpoint,body);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                var json_str = await response.Content.ReadAsStringAsync();
                return json_str;
            }
            return "";
        }

        private static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }

        private static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize<T>(obj);
        }
    }
}
