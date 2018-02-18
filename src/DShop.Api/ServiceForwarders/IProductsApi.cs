using DShop.Services.Products.Dtos;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.ServiceForwarders
{
    public interface IProductsApi
    {
        [Get("api/Products/{id}/Details")]
        Task<ProductDto> GetProductDetailsAsync([Path] Guid id);

        [Get("api/Products/All")]
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        [Get("api/Products/Filtered")]
        Task<IEnumerable<ProductDto>> GetProductsByVendorAsync(string vendor);
    }
}
