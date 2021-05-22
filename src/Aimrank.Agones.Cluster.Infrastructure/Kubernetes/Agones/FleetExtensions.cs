using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aimrank.Agones.Cluster.Infrastructure.Kubernetes.Agones
{
    internal static class FleetExtensions
    {
        public static async Task<Fleet> GetNamespacedFleetAsync(this k8s.Kubernetes kubernetes, string @namespace, string fleet)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(kubernetes.BaseUri + string.Format(Fleet.ResourceAddress, @namespace, fleet))
            };
            
            await kubernetes.Credentials.ProcessHttpRequestAsync(request, CancellationToken.None);

            var response = await kubernetes.HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Fleet>();
                if (result is not null)
                {
                    return result;
                }
            }

            return null;
        }
    }
}