using Lab_8.Data;
using Lab_8.Models;
using Lab_8.ServicesLayer.Interface;
using Microsoft.EntityFrameworkCore;

namespace Lab_8.ServicesLayer.Implementation
{
    public class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;

        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {
            return _context.Cars.Include(c => c.Brand).ToList();
        }

        public Car? GetCarById(int id)
        {
            return _context.Cars.Include(c => c.Brand)
                                .FirstOrDefault(c => c.Id == id);
        }

        public void CreateCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _context.Cars.Find(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }
    }
}