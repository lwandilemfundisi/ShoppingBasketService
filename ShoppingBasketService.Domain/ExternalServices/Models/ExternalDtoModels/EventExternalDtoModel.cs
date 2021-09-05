using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels
{
    public class EventExternalDtoModel
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; }
    }

    public class EventExternalDtosModel
    {
        public IList<EventExternalDtoModel> Events { get; set; }
    }
}
