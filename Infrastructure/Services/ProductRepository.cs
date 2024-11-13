using Microsoft.EntityFrameworkCore;
using SimpleServerProducts.Infrastructure.Data;
using SimpleServerProducts.Core.Models;
using SimpleServerProducts.Core.Interfaces;
namespace SimpleServerProducts.Infrastructure.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreContext _context;

        public ProductRepository(MyStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Product>();
            }
        }

        public async Task<Product?> GetOneAsync(int id)
        {
            try
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<Product?> CreateAsync(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
        public async Task<Product?> UpdateAsync(int id, Product product)
        {
            try
            {
                Product? productToUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (productToUpdate == null)
                {
                    return null;
                }
                productToUpdate.Price = product.Price;
                productToUpdate.Name = product.Name;
                await _context.SaveChangesAsync();
                return productToUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public async Task<Product?> DeleteAsync(int id)
        {
            try
            {
                Product? productToDelete = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                if (productToDelete == null)
                {
                    return null;
                }
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
                return productToDelete;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
