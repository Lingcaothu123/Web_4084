using Lab_8.Models;

namespace Lab_8.ServicesLayer.Interface
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        Car? GetCarById(int id);
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
        
    }

}
