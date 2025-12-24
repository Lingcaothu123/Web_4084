using Lab_8.Models;

namespace Lab_8.ServicesLayer.Interface
{
    public interface ICarModelService
    {
        List<CarModel> GetCarModels();
        CarModel? GetCarModelById(int id);
        void CreateCarModel(CarModel carModel);
        void UpdateCarModel(CarModel carModel);
        void DeleteCarModel(int id);
    }
}
