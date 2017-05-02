using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace WoW.Api
{
    public class ApiClient : IDisposable
    {
        private const string ApiKey = "6yzmuwn5ezbwyvk3pe8qw7fbdhrfrg32";
        private const string Locale = "en_GB";


        private readonly HttpClient _httpClient;

        public ApiClient()
        {
           _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            var uri = AppendDefaultParams(url);

            var responseMessage = await _httpClient.GetAsync(uri);
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsStringAsync();
        }

        private Uri AppendDefaultParams(string url)
        {
            var builder = new UriBuilder(url);

            var defaultParams = $"locale={Locale}&apikey={ApiKey}";

            if (builder.Uri.Query.Length > 0)
            {
                builder.Query += $"&{defaultParams}";
            }
            else
            {
                builder.Query += $"?{defaultParams}";
            }

            return builder.Uri;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
