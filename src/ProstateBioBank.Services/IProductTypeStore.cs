using ProstateBioBank.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProstateBioBank.Services
{
    public interface IProductTypeStore
    {
        Task<IEnumerable<ProductType>> GetProductTypesAsync();
        Task AddProductTypeAsync(ProductType productType);
    }
}
