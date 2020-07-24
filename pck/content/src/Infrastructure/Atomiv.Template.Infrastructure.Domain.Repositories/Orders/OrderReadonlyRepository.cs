﻿using Microsoft.EntityFrameworkCore;
using Atomiv.Template.Core.Domain.Orders;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System.Threading.Tasks;
using Atomiv.Template.Infrastructure.Domain.Persistence;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Orders
{
    public class OrderReadonlyRepository : Repository, IOrderReadonlyRepository
    {
        public OrderReadonlyRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(OrderIdentity orderId)
        {
            var orderRecordId = orderId.TryToGuid();

            if(orderRecordId == null)
            {
                return Task.FromResult(false);
            }

            return Context.Orders.AsNoTracking()
                .AnyAsync(e => e.Id == orderRecordId);
        }

        public Task<long> CountAsync()
        {
            return Context.Orders
                .LongCountAsync();
        }
    }
}