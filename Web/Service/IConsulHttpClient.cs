using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consul;

namespace iread_story.Web.Service
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string serviceName, string requestUri);
        Task<T> PostAsync<T>(string serviceName, string requestUri, Object obj);
    }
}