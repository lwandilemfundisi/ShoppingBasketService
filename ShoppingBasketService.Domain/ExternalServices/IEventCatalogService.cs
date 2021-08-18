using ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices
{
    public interface IEventCatalogService
    {
        Task<EventExternalDtoModel> GetEvent(string id, CancellationToken cancellationToken);
    }
}
