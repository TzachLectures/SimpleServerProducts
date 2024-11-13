using SimpleServerProducts.Core.Models;

namespace SimpleServerProducts.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product?> GetOne(int id);
        Task<Product?> Create(Product product);
        Task<Product?> Update(int id, Product product);
        Task<Product?> Delete(int id);
    }
}
