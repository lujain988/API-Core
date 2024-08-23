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
            return Ok(cat);
        }
        [HttpGet("{id}")]
        public IActionResult GetCatByID(int id)
        {
            var cat = _Db.Categories.Where(c => c.Id == id).FirstOrDefault();
  
            return Ok(cat);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetProByID(string name)
        {
            var pro = _Db.Categories.Include(p=>p.Products).Where(p => p.CategoryName == name).ToList();
            return Ok(pro);
        }
        [HttpDelete]

        public IActionResult DeletePro(int id)
        {
            var pro = _Db.Categories.Include(p => p.Products).FirstOrDefault(p => p.Id == id);
            _Db.Products.RemoveRange(pro.Products);
            _Db.Categories.Remove(pro);
            return Ok(pro);
        }

    }
}
