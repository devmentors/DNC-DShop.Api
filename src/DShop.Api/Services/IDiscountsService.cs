using System;
using System.Threading.Tasks;
using RestEase;

namespace DShop.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IDiscountsService
    {
        [AllowAnyStatusCode]
        [Get("discounts/{id}")]
        Task<object> GetAsync([Path] Guid id);  
        
        [AllowAnyStatusCode]
        [Get("discounts")]
        Task<object> FindAsync(Guid customerId); 
    }
}