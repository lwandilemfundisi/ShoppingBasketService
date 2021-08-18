using Microservice.Framework.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class BasketLineId : Identity<BasketLineId>
    {
        #region Constructors

        public BasketLineId(string value)
            : base(value)
        {

        }

        #endregion
    }
}
