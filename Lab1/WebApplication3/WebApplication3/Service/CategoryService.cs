using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Category>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Category?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Category category) => _repo.AddAsync(category);
        public Task UpdateAsync(Category category) => _repo.UpdateAsync(category);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }




}
