using SimpleServerProducts.Application.Interfaces;
using SimpleServerProducts.Core.Interfaces;
using SimpleServerProducts.Core.Models;

namespace SimpleServerProducts.Application.Services
{
    public class ProductService : IProductService
    {


        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetOne(int id)
        {
            return await _productRepository.GetOneAsync(id);
        }

        public async Task<Product?> Create(Product product)
        {
            if (product == null || product.Price < 0)
            {
                return null;
            }
            //List<Product> lstP = (await _productRepository.GetAllAsync());
            //product.Id = lstP.Count;
            Product? productToReturn = await _productRepository.CreateAsync(product);
            return productToReturn;
        }

        public async Task<Product?> Update(int id, Product product)
        {
            if (product == null || product.Price < 0)
            {
                return null;
            }
            return await _productRepository.UpdateAsync(id, product);
        }

        public async Task<Product?> Delete(int id)
        {
            return await _productRepository.DeleteAsync(id);

        }
    }
}
