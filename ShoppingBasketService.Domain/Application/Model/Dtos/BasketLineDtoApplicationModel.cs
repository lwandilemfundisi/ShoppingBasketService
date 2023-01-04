using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.Application.Model.Dtos
{
    public class BasketLineDtoApplicationModel
    {
        public BasketLineId Id { get; set; }
        public BasketId BasketId { get; set; }
        public string EventName { get; set; }
        public string Date { get; set; }
        public decimal TicketPrice { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public string EventId { get; set; }
    }

    public class BasketLinseDtoApplicationModel
    {
        public BasketLinseDtoApplicationModel()
        {
            BasketLines = new List<BasketLineDtoApplicationModel>();
        }

        public IList<BasketLineDtoApplicationModel> BasketLines { get; set; }
    }
}
