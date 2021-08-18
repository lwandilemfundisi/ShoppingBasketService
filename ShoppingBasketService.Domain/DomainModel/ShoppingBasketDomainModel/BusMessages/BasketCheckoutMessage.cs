using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using ShoppingBasketService.Integration.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.BusMessages
{
    public class BasketCheckoutMessage : IntegrationBaseMessage
    {
        public BasketCheckoutMessage()
        {
            BasketLines = new List<BasketLineMessage>();
        }

        public BasketId BasketId { get; set; }

        //user info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }


        //payment information
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }

        //order info
        public List<BasketLineMessage> BasketLines { get; set; }
        public int BasketTotal { get; set; }
    }

    public class BasketLineMessage
    {
        public BasketLineId BasketLineId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}
