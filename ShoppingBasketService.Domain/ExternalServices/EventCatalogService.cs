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
    }
}
