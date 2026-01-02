
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    using WebApplication3.Models;

    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(int id);
    }




}
