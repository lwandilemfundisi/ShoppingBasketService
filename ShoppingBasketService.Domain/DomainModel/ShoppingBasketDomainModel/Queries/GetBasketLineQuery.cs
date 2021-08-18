using Microservice.Framework.Common;
using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using Microservice.Framework.Persistence.EFCore.Queries.Filtering;
using Microservice.Framework.Persistence.Extensions;
using Microservice.Framework.Persistence.Queries.Filtering;
using ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Queries
{
    public class GetBasketLineQuery 
        : EFCoreCriteriaDomainQuery<Basket>, IQuery<BasketLine>
    {
        public GetBasketLineQuery(
            BasketId basketId,
            BasketLineId basketLineId)
        {
            Id = basketId;
            BasketLineId = basketLineId;
        }

        public BasketLineId BasketLineId { get; }
    }

    public class GetBasketLineQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Basket>, IQueryHandler<GetBasketLineQuery, BasketLine>
    {
        public GetBasketLineQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        public async Task<BasketLine> ExecuteQueryAsync(
            GetBasketLineQuery query, 
            CancellationToken cancellationToken)
        {
            var basket = await Find(query);

            if(basket.IsNull())
            {
                return null;
            }

            return basket.BasketLines.First(bl => bl.Id == query.BasketLineId);
        }
    }
}
