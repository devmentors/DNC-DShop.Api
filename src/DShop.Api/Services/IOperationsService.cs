using System;
using System.Threading.Tasks;
using RestEase;
using DShop.Api.Models.Operations;

namespace DShop.Api.Services
{
    public interface IOperationsService
    {
        [AllowAnyStatusCode]
        [Get("operations/{id}")]
        Task<Operation> GetAsync([Path] Guid id);          
    }
}