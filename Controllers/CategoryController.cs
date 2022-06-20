using IevaShop.Context;
using IevaShop.Context.Entity;
using IevaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IevaShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IevaShopDbContext _context;
        public CategoryController(IevaShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            using (_context)
            {
                categories = _context.Categories.Select(categoryFromDb => new CategoryModel
                {
                    Id = categoryFromDb.Id,
                    Name = categoryFromDb.Name
                }).ToList();
            }

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categoryModel = new CategoryModel
            {
                AllClothings = new List<ClothingModel>()
            };
            return View(categoryModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            ModelState.Remove(nameof(category.AllClothings));
            if (ModelState.IsValid)
            {
                var createdCategory = new Category
                {
                    Name = category.Name
                };
                _context.Categories.Add(createdCategory);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // adress.com/Category/View/{id} --> FIND ALL PRODUCTS UNDER A SPECIFIC CATEGORY
        public IActionResult View(int id)
        {
            var viewAllClothingModel = new ViewClothingModel();
            using (_context)
            {
                var selectedCategory = _context.Categories.Include(c => c.AllClothings).FirstOrDefault(c => c.Id == id);
                if (selectedCategory is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    viewAllClothingModel.CategoryName = selectedCategory.Name;

                    viewAllClothingModel.AllClothings = selectedCategory.AllClothings is not null ?
                        selectedCategory.AllClothings.Select(clothingFromDb =>
                    new ClothingModel
                    {
                        Id = clothingFromDb.Id,
                        Name = clothingFromDb.Name,
                        Description = clothingFromDb.Description,
                        Price = clothingFromDb.Price,
                    }).ToList() : new List<ClothingModel>();
                }
            }

            return View(viewAllClothingModel);
        }

    }
}
