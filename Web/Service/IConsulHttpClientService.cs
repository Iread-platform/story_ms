using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.Service
{
    public interface IConsulHttpClientService
    {
        Task<T> GetAsync<T>(string serviceName, string requestUri);
        Task<T> PostAsync<T>(string serviceName, string requestUri, Dictionary<string, string> obj,
            List<IFormFile>? attachments);
    }
}
