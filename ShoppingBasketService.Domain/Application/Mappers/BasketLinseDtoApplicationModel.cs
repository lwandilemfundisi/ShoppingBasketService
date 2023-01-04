using Microservice.Framework.Common;
using ShoppingBasketService.Domain.Application.Model.Dtos;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using ShoppingBasketService.Domain.ExternalServices.Models.ExternalDtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.Application.Mappers
{
    public class BasketLinseDtoApplicationModelMapper
    {
        private readonly EventExternalDtosModel _events;
        private readonly ICollection<BasketLine> _basketLines;

        public BasketLinseDtoApplicationModelMapper(
            EventExternalDtosModel events, 
            ICollection<BasketLine> basketLines)
        {
            _events = events;
            _basketLines = basketLines;
        }

        public BasketLinseDtoApplicationModel Map()
        {
            if (_events.IsNull()) throw new ArgumentException($"Attempt to map a null object in {GetType().PrettyPrint()}");

            var toReturn = new BasketLinseDtoApplicationModel();

            foreach (var ev in _events.Events)
            {
                var matchingBasketLine = _basketLines.First(bl => bl.EventId == ev.Id);

                toReturn.BasketLines.Add(new BasketLineDtoApplicationModel 
                {
                    EventId = ev.Id,
                    EventName = ev.EventName,
                    Date = ev.Date.ToUniversalTime().ToString("yyyy-MM-dd"),
                    Quantity = matchingBasketLine.TicketAmount,
                    TicketPrice = matchingBasketLine.Price,
                    Total = matchingBasketLine.TicketAmount * matchingBasketLine.Price

                });
            }    

            return toReturn;
        }
    }
}
