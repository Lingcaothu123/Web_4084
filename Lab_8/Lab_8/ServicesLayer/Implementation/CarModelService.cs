using Lab_8.Models;
using Lab_8.Repository.Interface;
using Lab_8.ServicesLayer.Interface;

namespace Lab_8.ServicesLayer.Implementation
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _repository;
        public CarModelService(ICarModelRepository repository)
        {
            _repository = repository;
        }
        public List<CarModel> GetCarModels()
        {
            return _repository.GetAll();
        }
        public CarModel? GetCarModelById(int id)
        {
            return _repository.GetById(id);
        }
        public void CreateCarModel(CarModel carModel)
        {
            _repository.Add(carModel);
        }
        public void UpdateCarModel(CarModel carModel)
        {
            _repository.Update(carModel);
        }
        public void DeleteCarModel(int id)
        {
            _repository.Delete(id);
        }
    }

}
