using Microsoft.AspNetCore.WebUtilities;
using ShoppingBasketService.Domain.Extensions;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _httpClient;

        public EventCatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EventExternalDtoModel> GetEvent(
            string id, 
            CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(
                $"/Event/getEvent/{id}",
                cancellationToken);

            return await response.As<EventExternalDtoModel>();
        }

        public async Task<EventExternalDtosModel> GetEvents(
            IEnumerable<string> ids, 
            CancellationToken cancellationToken)
        {
            var debug = $"/Event/getEvents?{CollectionToQueryParam("ids", ids.ToArray())}";
            var response = await _httpClient.GetAsync(
                debug,
                cancellationToken);

            return await response.As<EventExternalDtosModel>();
        }

        private string CollectionToQueryParam(string name, object[] coll)
        {
            var query = string.Empty;

            for(int i = 0; i < coll.Length; i++)
            {
                query += $"{name}={coll[i]}";
                if (i < coll.Length - 1)
                    query += "&";

            }

            return query;
        }
    }
}
