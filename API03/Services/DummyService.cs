namespace API03.Services
{
    public class DummyService
    {
        private readonly HttpClient _httpClient;

        public DummyService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://dummyapi.io/data/v1/");
            httpClient.DefaultRequestHeaders.Add("app-id", "63ad4b881cc36571f61a1cca");
            _httpClient = httpClient;
        }

        public async Task<string> Users()
        {
            return await _httpClient.GetStringAsync("user");
        }

        public async Task<string> User(string id)
        {
            return await _httpClient.GetStringAsync($"user/{id}");
        }
    }
}
