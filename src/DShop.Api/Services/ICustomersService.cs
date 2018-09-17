using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Common.Types;
using DShop.Api.Models.Customers;
using DShop.Api.Queries;
using RestEase;

namespace DShop.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomersService
    {
        [AllowAnyStatusCode]
        [Get("customers/{id}")]
        Task<Customer> GetAsync([Path] Guid id);  

        [AllowAnyStatusCode]
        [Get("customers")]
        Task<PagedResult<Customer>> BrowseAsync([Query] BrowseCustomers query);

        [AllowAnyStatusCode]
        [Get("carts/{id}")]
        Task<Cart> GetCartAsync([Path] Guid id);  
    }
}