using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly MyDbContext _Db;



        public CartController(MyDbContext db)
        {

            _Db = db;

        }
        [HttpGet]
        [Authorize]
        public IActionResult getCart() {

            var item = _Db.Carts.ToList();        
        return Ok(item);    
        }
    }
}
