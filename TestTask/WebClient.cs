using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestTask
{
    // P.S. Использовать в лоб HttpClient не самая лучшая практика.
    // В работе с экземплярами HttpClient есть особенности при высвобождении ресурсов системы и при работе с кешом.
    // Во избежании непредвиденных ошибок обычно используется IHttpClientFactory через DI контейнер. 
    internal class WebClient
    {
        private readonly HttpClient _httpClient;

        public WebClient(HttpClient httpClient)
        {         
            _httpClient = httpClient;
        }

        public async Task<HttpStatusCode> SendData(IEnumerable<int> data, CancellationToken cancellationToken)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,             
            };

            var response = await _httpClient.SendAsync(httpRequestMessage, cancellationToken);
            return response.StatusCode;
        } 
    }
}
