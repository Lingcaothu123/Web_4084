using Lab_8.Data;
using Lab_8.Models;
using Lab_8.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Lab_8.Repository.Implementation
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // JOIN 2 bảng: CarModels + Brands
        public List<CarModel> GetAll()
        {
            return _context.CarModels
                .Include(cm => cm.Brand)
                .Select(cm => new CarModel
                {
                    Id = cm.Id,
                    Name = cm.Name,
                    BrandId = cm.BrandId,
                    Brand = cm.Brand
                })
                .ToList();
        }

        public CarModel? GetById(int id)
        {
            return _context.CarModels
                .Include(cm => cm.Brand) // nếu muốn lấy cả Brand
                .FirstOrDefault(cm => cm.Id == id);
        }

        public void Add(CarModel carModel)
        {
            _context.CarModels.Add(carModel);
            _context.SaveChanges();
        }

        public void Update(CarModel carModel)
        {
            _context.CarModels.Update(carModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var carModel = _context.CarModels.Find(id);
            if (carModel != null)
            {
                _context.CarModels.Remove(carModel);
                _context.SaveChanges();
            }
        }
    }
}