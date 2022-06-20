using IevaShop.Context;
using IevaShop.Context.Entity;
using IevaShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace IevaShop.Controllers
{
    public class ClothingController : Controller
    {
        private readonly IevaShopDbContext _context;
        public ClothingController(IevaShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<ClothingModel> allClothings = new List<ClothingModel>();
            using (_context)
            {
                allClothings = _context.AllClothings.Select(clothingFromDb => new ClothingModel
                {
                    Id = clothingFromDb.Id,
                    Name = clothingFromDb.Name,
                    Description = clothingFromDb.Description,
                    Price = clothingFromDb.Price,
                    Category = new CategoryModel
                    {
                        Id = clothingFromDb.Category.Id,
                        Name = clothingFromDb.Category.Name
                    }
                }).OrderBy(allClothing => allClothing.Name)
                .ToList();
            }

            return View(allClothings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var allClothing = new CreateClothingModel
            {
                Categories = _context.Categories.ToList(),
            };
            return View(allClothing);
        }

        [HttpPost]
        public IActionResult Create(CreateClothingModel allClothing)
        {
            ModelState.Remove(nameof(allClothing.Categories));
            if (ModelState.IsValid)
            {
                var selectedCategory = _context.Categories.First(c => c.Id == allClothing.CategoryId);
                var createdAllClothing = new Clothing
                {
                    Name = allClothing.Name,
                    Description = allClothing.Description,
                    Price = allClothing.Price,
                    Category = selectedCategory
                };

                _context.AllClothings.Add(createdAllClothing);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(allClothing);

        }
        public IActionResult View(int id)
        {
            var allClothingModel = new ClothingModel();
            using (_context)
            {
                var selectedAllClothing = _context.AllClothings.Where(c => c.Id == id).FirstOrDefault();
                if (selectedAllClothing is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var categories = _context.AllClothings.Where(c => c.Id == id).Select(p => p.Category).First();
                    allClothingModel.Id = selectedAllClothing.Id;
                    allClothingModel.Name = selectedAllClothing.Name;
                    allClothingModel.Description = selectedAllClothing.Description;
                    allClothingModel.Price = selectedAllClothing.Price;
                    allClothingModel.Category = new CategoryModel
                    {
                        Name = categories.Name
                    };
                    return View(allClothingModel);
                }
            }
        }
    }
}
