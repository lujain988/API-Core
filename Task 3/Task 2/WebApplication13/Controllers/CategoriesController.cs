using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _Db;

        public CategoriesController(MyDbContext db)
        {

            _Db = db;
        }
        [HttpGet]
        public IActionResult GetCat()
        {
            var cat = _Db.Categories.ToList();
            if (cat == null) {
            return NotFound("No categories found.");
            }
            return Ok(cat);
        }
        [HttpGet("{id:min(5)}")]
        public IActionResult GetCatByID(int id)
        {
            var cat = _Db.Categories.Where(c => c.Id == id).FirstOrDefault();
            if (cat == null) { return NotFound("No categories found."); }
  
            return Ok(cat);
        }
        [HttpGet("Name/{name}")]
        public IActionResult GetProByID(string name)
        {
            var pro = _Db.Categories.Include(p=>p.Products).Where(p => p.CategoryName == name).ToList();
            if (pro == null) { return NotFound("No categories found."); }

            return Ok(pro);
        }
        [HttpDelete]

        public IActionResult DeletePro(int id)
        {
            var pro = _Db.Categories.Include(p => p.Products).FirstOrDefault(p => p.Id == id);

            _Db.Products.RemoveRange(pro.Products);
            _Db.Categories.Remove(pro);
            _Db.SaveChanges();
            return Ok(pro);
        }

    }
}
