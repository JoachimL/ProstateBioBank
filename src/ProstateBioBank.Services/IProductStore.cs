using ProstateBioBank.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProstateBioBank.Services
{
    public interface IProductStore
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task AddProductTypeAsync(ProductType productType);
    }
}
