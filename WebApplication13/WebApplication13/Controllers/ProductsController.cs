using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _Db;

        public ProductsController(MyDbContext db)
        {

            _Db = db;
        }
        [HttpGet]
        public IActionResult GetPro()
        {
            var pro = _Db.Products.Include(p=> p.Category).ToList();
            return Ok(pro);
        }
        [HttpGet("{id}")]
        public IActionResult GetProByID(int id)
        {
            var pro = _Db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            return Ok(pro);
        }
    }
}
