using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Storage.Models.Customers;
using RestEase;

namespace DShop.Api.ServiceForwarders
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICartsStorage
    {
        [AllowAnyStatusCode]
        [Get("carts/{id}")]
        Task<Cart> GetAsync([Path] Guid id);  
    }
}