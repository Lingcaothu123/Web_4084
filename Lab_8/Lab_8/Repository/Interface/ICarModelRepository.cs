using Lab_8.Models;
namespace Lab_8.Repository.Interface

{
    public interface ICarModelRepository
    {
        List<CarModel> GetAll();
        CarModel? GetById(int id);
        void Add(CarModel carModel);
        void Update(CarModel carModel);
        void Delete(int id);
    }
    

}
