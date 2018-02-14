using DShop.Messages.ReadModels;
using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DShop.Api.ServiceForwarders
{
    public interface IProductsApi
    {
        [Get("api/Products/{id}/Details")]
        Task<ProductDetailsReadModel> GetProductDetailsAsync([Path] Guid id);

        [Get("api/Products/All")]
        Task<IEnumerable<ProductReadModel>> GetAllProductsAsync();

        [Get("api/Products/Filtered")]
        Task<IEnumerable<ProductReadModel>> GetProductsByVendorAsync(string vendor);
    }
}
