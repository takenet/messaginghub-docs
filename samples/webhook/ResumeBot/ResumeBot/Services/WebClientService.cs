using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ResumeBot.Services
{
    public class WebClientService
    {
        public WebClientService(Uri uri, string apiKey)
        {
            Uri = uri ?? new Uri("https://msging.net/messages");
            AuthorizationHeader = new AuthenticationHeaderValue("Key", apiKey);
        }

        private readonly Uri Uri;

        private readonly AuthenticationHeaderValue AuthorizationHeader;

        private const int MaxRetries = 3;

        public async Task<HttpResponseMessage> SendMessageAsync(string jsonMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await SendAsync(Uri, HttpMethod.Post, jsonMessage, cancellationToken);
        }
        
        private async Task<HttpResponseMessage> SendAsync<T>(Uri uri, HttpMethod httpMethod, T payload, CancellationToken cancellationToken)
        {
            using (var webClient = GetWebClient(MaxRetries))
            {
                HttpContent content = null;

                if (payload != null)
                {
                    if (payload is string)
                    {
                        content = new StringContent(payload as string, System.Text.Encoding.UTF8, "application/json");
                    }
                    else
                    {
                        content = new ObjectContent<T>(payload, new JsonMediaTypeFormatter());
                    }
                }

                using (var request = new HttpRequestMessage
                {
                    Content = content,
                    RequestUri = uri,
                    Method = httpMethod
                })
                {
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    await TraceRequestDataAsync(request);

                    var response = await webClient.SendAsync(request, cancellationToken);

                    await TraceResponseDataAsync(response);

                    if (response.IsSuccessStatusCode)
                        return response;

                    throw new HttpException((int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private HttpClient GetWebClient(int retries)
        {
            var client = new HttpClient(new HttpRetryHandler(new HttpClientHandler(), retries));

            client.DefaultRequestHeaders.Authorization = AuthorizationHeader;
            client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(Thread.CurrentThread.CurrentUICulture.Name));

            return client;
        }

        private void Log(string log)
        {
            Trace.WriteLine(log);
        }

        private async Task TraceRequestDataAsync(HttpRequestMessage request)
        {
            var requestData = $"{nameof(HttpRequestMessage)} => {request.Version} {request.Method} {request.RequestUri} | P: {string.Join(";", request.Properties.Select(p => $"{p.Key}={p.Value}").ToArray())} | H: {request.Headers} | B: { await ParseContentAsync(request.Content) }";

            Log(requestData);
        }

        private async Task TraceResponseDataAsync(HttpResponseMessage response)
        {
            var responseData = $"{nameof(HttpResponseMessage)} => {response.Version} {response.StatusCode} {response.ReasonPhrase} | H: {response.Headers} | B: { await ParseContentAsync(response.Content) }";

            Log(responseData);
        }

        private async Task<string> ParseContentAsync(HttpContent content)
        {
            if (content == null)
                return null;

            var data = await content.ReadAsStringAsync();
            data = data.Substring(0, Math.Min(data.Length, 4096));
            return data;
        }
    }
}