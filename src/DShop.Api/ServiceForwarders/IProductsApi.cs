using DShop.Services.Storage.Models.Products;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.ServiceForwarders
{
    public interface IProductsApi
    {
        [Get("api/Products/{id}/Details")]
        Task<Product> GetProductDetailsAsync([Path] Guid id);

        [Get("api/Products/All")]
        Task<IEnumerable<Product>> GetAllProductsAsync();

        [Get("api/Products/Filtered")]
        Task<IEnumerable<Product>> GetProductsByVendorAsync(string vendor);
    }
}
