using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Vendista.Models;

namespace Vendista.Service
{
    public class TokenService
    {
        private const string baseUrl = "http://178.57.218.210:198/";
        protected HttpClient httpClient = new HttpClient();

        public TokenService() {
            Configuration();
        }

        protected async Task<string> GetToken()
        {
            DataToken token = new DataToken();
            HttpResponseMessage res = await httpClient.GetAsync("token?login=part&password=part");
            if (res.IsSuccessStatusCode)
            {
                var response = res.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<DataToken>(response);
            }
            return token.Token;
        }

        private HttpClient Configuration()
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}
