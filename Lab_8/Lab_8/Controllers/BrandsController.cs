using Lab_8.Models;
using Lab_8.ServicesLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class BrandsController : Controller
{
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    // GET: /Brands
    public IActionResult Index()
    {
        var brands = _brandService.GetAllBrands();
        ViewBag.BrandId = new SelectList(brands, "Id", "Name");
        return View(brands); // Tìm Views/Brands/Index.cshtml
    }

    // GET: /Brands/Create
    public IActionResult Create()
    {
        var brands = _brandService.GetAllBrands(); // hoặc từ DbContext nếu không dùng service
        ViewBag.BrandId = new SelectList(brands, "Id", "Name");

        return View();
    }

    // POST: /Brands/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Brand brand)
    {
        if (!ModelState.IsValid)
            return View(brand);

        _brandService.CreateBrand(brand);
        return RedirectToAction(nameof(Index));
    }

    // GET: /Brands/Edit/5
    public IActionResult Edit(int id)
    {
        var brand = _brandService.GetBrandById(id);
        if (brand == null) return NotFound();
        return View(brand);
    }

    // POST: /Brands/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Brand brand)
    {
        if (!ModelState.IsValid)
            return View(brand);

        _brandService.UpdateBrand(brand);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int id)
    {
        var brand = _brandService.GetBrandById(id);
        if (brand == null) return NotFound();
        return View(brand);
    }

    // GET: /Brands/Delete/5
    public IActionResult Delete(int id)
    {
        _brandService.DeleteBrand(id);
        return RedirectToAction(nameof(Index));
    }
}