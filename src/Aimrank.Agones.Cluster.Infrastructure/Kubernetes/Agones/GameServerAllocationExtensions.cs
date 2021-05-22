using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aimrank.Agones.Cluster.Infrastructure.Kubernetes.Agones
{
    internal static class GameServerAllocationExtensions
    {
        public static async Task<GameServerAllocation> CreateNamespacedGameServerAllocationAsync(
            this k8s.Kubernetes kubernetes, string @namespace, Guid matchId, string map, string whitelist)
        {
            var allocation = GameServerAllocation.Create(
                new Dictionary<string, string> {["game"] = "csgo"},
                new Dictionary<string, string> {["mode"] = "competitive"},
                new Dictionary<string, string>
                {
                    [GameServerAllocation.AgonesMap] = map,
                    [GameServerAllocation.AgonesMatchId] = matchId.ToString(),
                    [GameServerAllocation.AgonesWhitelist] = whitelist
                });
            
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(kubernetes.BaseUri + string.Format(GameServerAllocation.ResourceAddress, @namespace)),
                Content = JsonContent.Create(allocation, options: new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true
                })
            };
            
            await kubernetes.Credentials.ProcessHttpRequestAsync(request, CancellationToken.None);
            
            var response = await kubernetes.HttpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GameServerAllocation>();
                if (result is not null)
                {
                    return result;
                }
            }
            
            return null;
        }
    }
}