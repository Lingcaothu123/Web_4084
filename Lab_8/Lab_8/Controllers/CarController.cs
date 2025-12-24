using Lab_8.Data;
using Lab_8.Models;
using Lab_8.ServicesLayer.Implementation;
using Lab_8.ServicesLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;

        public CarController(ICarService carService, IBrandService brandService)
        {
            _carService = carService;
            _brandService = brandService;
        }
        // GET: /Car
        public IActionResult Index()
        {
            return View(_carService.GetAllCars());
        }
        // GET: /Car/Details/5
        public IActionResult Details(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null) return NotFound();
            return View(car);
            
       
        }
        // GET: /Car/Create
        public IActionResult Create()
        {
            var brands = _brandService.GetAllBrands();
            ViewBag.BrandId = new SelectList(brands, "Id", "Name");
            return View();
        }

        // POST: /Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);
            _carService.CreateCar(car);
            return RedirectToAction(nameof(Index));
        }
        // GET: /Car/Edit/5
        public IActionResult Edit(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null) return NotFound();
            return View(car);
        }
        // POST: /Car/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
            {
                // 🔴 BẮT BUỘC load lại Brand list
                var brands = _brandService.GetAllBrands();
                ViewBag.BrandId = new SelectList(brands, "Id", "Name", car.BrandId);

                return View(car);
            }

            _carService.CreateCar(car);
            return RedirectToAction(nameof(Index));
        }
        // GET: /Car/Delete/5
        public IActionResult Delete(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
