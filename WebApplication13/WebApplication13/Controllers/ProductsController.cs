using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var pro = _Db.Products.ToList();
            return Ok(pro);
        }
        [HttpGet("{id}")]
        public IActionResult GetProByID(int id)
        {
            var pro = _Db.Categories.Where(p => p.Id == id).FirstOrDefault();

            return Ok(pro);
        }
    }
}
