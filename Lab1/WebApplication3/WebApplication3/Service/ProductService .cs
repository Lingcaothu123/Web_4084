using WebApplication3.Models;
using WebApplication3.Repository;

namespace WebApplication3.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Product>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Product?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Product product) => _repo.AddAsync(product);
        public Task UpdateAsync(Product product) => _repo.UpdateAsync(product);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
