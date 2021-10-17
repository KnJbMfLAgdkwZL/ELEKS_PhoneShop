using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Models.Entities;

namespace DataAccess.Interfaces
{
    public interface IStockSubscribersRep
    {
        Task<StockSubscriber> GetOneAsync(Expression<Func<StockSubscriber, bool>> predicate, CancellationToken token);
        Task InsertAsync(StockSubscriber stockSubs, CancellationToken token);

        Task<List<StockSubscriber>> GetAllAsync(Expression<Func<StockSubscriber, bool>> predicate,
            CancellationToken token);
    }
}