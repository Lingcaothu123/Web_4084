using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using bookweb.Models;
namespace bookweb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<BookController> _logger;

        public BookController(BookDbContext context, IWebHostEnvironment env, ILogger<BookController> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        // LIST
        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Category).ToList();
            return View(books);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Book book, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(
                    _context.Categories, "CategoryId", "CategoryName");
                return View(book);
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                string folder = Path.Combine(_env.WebRootPath, "Content/ImageBooks");
                Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(folder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);

                book.Image = fileName;
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAIL PAGE
        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == id);
            return View(book);
        }
    }

}
