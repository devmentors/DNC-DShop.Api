using DShop.Common.Types;
using DShop.Services.Storage.Models.Products;
using DShop.Services.Storage.Models.Queries;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.ServiceForwarders
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IProductsStorage
    {
        [AllowAnyStatusCode]
        [Get("/products/{id}")]
        Task<Product> GetAsync([Path] Guid id);

        [AllowAnyStatusCode]
        [Get("/products")]
        Task<PagedResult<Product>> BrowseAsync([Query] BrowseProducts query);
    }
}
