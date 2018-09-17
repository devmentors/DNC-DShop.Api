using DShop.Common.Types;
using DShop.Api.Models.Products;
using DShop.Api.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsService
    {
        [AllowAnyStatusCode]
        [Get("products/{id}")]
        Task<Product> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("products")]
        Task<PagedResult<Product>> BrowseAsync([Query] BrowseProducts query);
    }
}
