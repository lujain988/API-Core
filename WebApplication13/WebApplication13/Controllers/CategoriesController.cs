using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
