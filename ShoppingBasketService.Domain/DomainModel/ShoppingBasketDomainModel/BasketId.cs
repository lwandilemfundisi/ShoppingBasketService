using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel
{
    public class BasketId : Identity<BasketId>
    {
        #region Constructors

        public BasketId(string value)
            : base(value)
        {

        }

        #endregion
    }
}
