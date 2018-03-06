using DShop.Services.Storage.Models.Orders;
using DShop.Services.Storage.Models.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.ServiceForwarders
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IOrdersStorage
    {
        [Get("customers/{id}")]
        Task<OrderDetails> GetAsync([Path] Guid id);

        [Get("customers")]
        Task<IEnumerable<Order>> BrowseAsync([Query] BrowseOrders query);
    }
}
