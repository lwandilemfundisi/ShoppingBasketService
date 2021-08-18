using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using Microservice.Framework.Persistence.EFCore.Queries.Filtering;
using Microservice.Framework.Persistence.Extensions;
using Microservice.Framework.Persistence.Queries.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasketService.Domain.DomainModel.ShoppingBasketDomainModel.Queries
{
    public class GetBasketQuery 
        : EFCoreCriteriaDomainQuery<Basket>, IQuery<Basket>
    {
        public GetBasketQuery(
            BasketId basketId, 
            string userId)
        {
            Id = basketId;
            UserId = userId;
        }

        public string UserId { get; }

        protected override void OnBuildDomainCriteria(EFCoreDomainCriteria domainCriteria)
        {
            domainCriteria.SafeAnd(new EqualityFilter("UserId", UserId, FilterType.Equal));
        }
    }

    public class GetBasketQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Basket>, IQueryHandler<GetBasketQuery, Basket>
    {
        public GetBasketQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        public Task<Basket> ExecuteQueryAsync(
            GetBasketQuery query, 
            CancellationToken cancellationToken)
        {
            return Find(query);
        }
    }
}
