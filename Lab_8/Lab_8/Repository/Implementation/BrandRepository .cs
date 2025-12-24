using Lab_8.Data;
using Lab_8.Models;
using Lab_8.Repository.Interface;

namespace Lab_8.Repository.Implementation
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }
        public Brand? GetById(int id)
        {
            return _context.Brands.Find(id);
        }
        public void Add(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
        public void Update(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var brand = _context.Brands.Find(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
            }
        }

    }
}
