using Lab_8.Models;

namespace Lab_8.ServicesLayer.Interface
{
    public interface IBrandService
    {
        List<Brand> GetAllBrands();
        Brand? GetBrandById(int id);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int id);
    }

}
