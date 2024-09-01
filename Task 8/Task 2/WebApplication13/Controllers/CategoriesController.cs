using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using NCalc;
using System.Data;
using WebApplication13.DTOs;
using WebApplication13.Models;


namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _Db;
        private readonly IMemoryCache _cache;


        public CategoriesController(MyDbContext db, IMemoryCache memoryCache)
        {

            _Db = db;
            _cache = memoryCache;

        }

       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetCat()
        {
                // Define a cache key
                var cacheKey = "categoriesCache";
                // Try to get the categories from the cache
                if (!_cache.TryGetValue(cacheKey, out List<Category> cat))
                {
                    // If not found in cache, retrieve from the database
                    cat = _Db.Categories.ToList();

                    if (cat == null || !cat.Any())
                    {
                        return NotFound("No categories found.");
                    }

                    // Set cache options (e.g., cache for 5 minutes)
                    var cacheOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                    };

                    // Store the categories in cache
                    _cache.Set(cacheKey, cat, cacheOptions);
                }

                return Ok(cat);
    
        }
        [HttpPost("clear-cache")]
        public IActionResult ClearCache()
        {
            try
            {
                var cacheKey = "categoriesCache";
                _cache.Remove(cacheKey);
                return Ok("Cache cleared successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while clearing the cache.");
            }
        }




        [HttpGet("{id:int}")]
           [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCatByID(int id)
        {
            var cat = _Db.Categories.Join(_Db.Products,
                cat => cat.Id,
                product => product.CategoryId,
                (cat, product) => new
                {
                    id = cat.Id,
                    categoryName = cat.CategoryName,
                    categoryImage = cat.CategoryImage,
                    products = product.ProductName
                }
                ).Where(c => c.id == id).FirstOrDefault();
            if (cat == null) { return NotFound("No categories found."); }

            return Ok(cat);
        }
        [HttpGet("Name/{name}")]
        public IActionResult GetProByID(string name)
        {
            var pro = _Db.Categories.Where(p => p.CategoryName == name).ToList();
            if (pro == null) { return NotFound("No categories found."); }

            return Ok(pro);
        }

        [HttpPost]
        public IActionResult PostNew([FromForm] categoryRequestDTO category)
        {
            if (category == null)
            {
                return BadRequest("Category data is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(UploadedFolder))
            {
                Directory.CreateDirectory(UploadedFolder);
            }
            var ImageFile = Path.Combine(UploadedFolder, category.CategoryImage.FileName);
            using (var strem = new FileStream(ImageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(strem);
            }

            var categorynew = new Category
            {
                CategoryName = category.CategoryName,
                CategoryImage = category.CategoryImage.FileName,
            };
            {

            };
            _Db.Categories.Add(categorynew);
            _Db.SaveChanges();

            return Ok(categorynew);

        }
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, [FromForm] categoryRequestDTO category)
        {
            // Check if the category exists
            var existingCategory = _Db.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }
            var UploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(UploadedFolder))
            {
                Directory.CreateDirectory(UploadedFolder);
            }
            var ImageFile = Path.Combine(UploadedFolder, category.CategoryImage.FileName);
            using (var strem = new FileStream(ImageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(strem);
            }
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryImage = category.CategoryImage.FileName;

            _Db.Categories.Update(existingCategory);
            _Db.SaveChanges();

            return Ok(existingCategory);
        }
        [HttpDelete("{id}")]

        public IActionResult DeletePro(int id)
        {
            var pro = _Db.Categories.FirstOrDefault(p => p.Id == id);

            _Db.Products.RemoveRange(pro.Products);
            _Db.Categories.Remove(pro);
            _Db.SaveChanges();
            return Ok(pro);
        }

    }

} 

