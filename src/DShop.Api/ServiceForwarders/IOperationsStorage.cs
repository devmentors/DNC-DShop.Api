using System;
using System.Threading.Tasks;
using RestEase;
using DShop.Services.Storage.Models.Operations;

namespace DShop.Api.ServiceForwarders
{
    public interface IOperationsStorage
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}