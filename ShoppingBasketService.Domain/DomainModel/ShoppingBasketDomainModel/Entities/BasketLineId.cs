using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities
{
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
