using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace iread_story.Web.Service
{
    public class ConsulHttpClientService:IConsulHttpClientService
    {
         private readonly HttpClient _client;
        private IConsulClient _consulClient;
        
        public ConsulHttpClientService(HttpClient client, IConsulClient consulclient)
        {
            _client = client;
            _consulClient = consulclient;
        }
        
        public async Task<T> GetAsync<T>(string serviceName, string requestUri)
        {
            var uri = await GetRequestUriAsync(serviceName, requestUri);
            
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
        
        public async Task<T> PostAsync<T>(string serviceName, string requestUri,
            Dictionary<string, string> obj, List<IFormFile>? attachments)
        {
            var uri = await GetRequestUriAsync(serviceName, requestUri);

            var formDataContent = new MultipartFormDataContent();

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    formDataContent.Add(
                        new StreamContent(attachment.OpenReadStream())
                        {
                            Headers =
                            {
                                ContentLength = attachment.Length,
                                ContentType = new MediaTypeHeaderValue(attachment.ContentType)
                            }
                        },"File",attachment.FileName);
                }
            }

            //var x = new StringContent(new FormUrlEncodedContent(obj), Encoding.UTF8, "application/json");
            if (obj != null)
            {
                foreach (var ob in obj)
                {
                    formDataContent.Add(new StringContent(ob.Value),ob.Key);
                }
            }
            var response = await _client.PostAsync(uri,formDataContent);

            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        
        private async Task<Uri> GetRequestUriAsync(string serviceName, string uri)
        {
            //Get all services registered on Consul
            var allRegisteredServices = await _consulClient.Agent.Services();

            //Get all instance of the service went to send a request to
            var registeredServices = allRegisteredServices.Response?.Where(s => s.Value.Service.Equals(serviceName, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToList();

            //Get a random instance of the service
            var service = GetRandomInstance(registeredServices, serviceName);

            if (service == null)
            {
                throw new Exception($"Consul service: '{serviceName}' was not found.");
            }
            
            var uriBuilder = new UriBuilder
            {
                Host = service.Address,
                Port = service.Port,
                Path = uri
            };

            return uriBuilder.Uri;
        }

        private AgentService GetRandomInstance(IList<AgentService> services, string serviceName)
        {
            Random _random = new Random();

            AgentService servToUse = null;

            servToUse = services[_random.Next(0, services.Count)];

            return servToUse;
        }

    }
}