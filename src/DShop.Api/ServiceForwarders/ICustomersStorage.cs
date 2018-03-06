using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Models.Queries;
using RestEase;

namespace DShop.Api.ServiceForwarders
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface ICustomersStorage
    {
        [AllowAnyStatusCode]
        [Get("customers/{id}")]
        Task<Customer> GetAsync([Path] Guid id);  

        [AllowAnyStatusCode]
        [Get("customers")]
        Task<IEnumerable<Customer>> BrowseAsync([Query] BrowseCustomers query);
    }
}