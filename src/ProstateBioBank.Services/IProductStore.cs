using ProstateBioBank.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
