using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DShop.Services.Storage.Models.Customers;
using DShop.Services.Storage.Models.Queries;
using RestEase;

namespace DShop.Api.ServiceForwarders
{
    public interface ICustomersStorage
    {
        [Get("customers/{id}")]
        Task<Customer> GetAsync([Path] Guid id);  

        [Get("customers")]
        Task<IEnumerable<Customer>> BrowseAsync([Query] BrowseCustomers query);
    }
}