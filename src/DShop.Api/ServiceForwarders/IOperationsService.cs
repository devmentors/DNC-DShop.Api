using System;
using System.Threading.Tasks;
using RestEase;
using DShop.Services.Storage.Models.Operations;

namespace DShop.Api.ServiceForwarders
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}