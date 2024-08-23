﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _Db;

        public ProductsController(MyDbContext db)
        {
            _Db = db;
        }

        [HttpGet("All")]
        public IActionResult GetPro()
        {
            var pro = _Db.Products.Include(p => p.Category).ToList();
            if (pro == null )
            {
                return NoContent(); // 204 No Content if no products are found
            }
            return Ok(pro); // 200 OK with products data
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProByID(int id, [FromQuery]int id2)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID."); // 400 Bad Request for invalid ID
            }

            var pro = _Db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id && id2==2);
            if (pro == null)
            {
                return NotFound(); // 404 Not Found if product does not exist
            }
            return Ok(pro); // 200 OK with product data
        }

        // GET: api/products/name/{name}
        [HttpGet("Name/{name:max(10)}")]
        public IActionResult GetProByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Product name cannot be empty."); // 400 Bad Request for invalid name
            }

            var pro = _Db.Products.Include(p => p.Category).Where(p => p.ProductName == name).ToList();
            if (pro == null )
            {
                return NoContent(); // 204 No Content if no products are found with the specified name
            }
            return Ok(pro); // 200 OK with products data
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePro(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid product ID."); // 400 Bad Request for invalid ID
            }

            var pro = _Db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (pro == null)
            {
                return NotFound(); // 404 Not Found if product does not exist
            }

            _Db.Products.Remove(pro);
            _Db.SaveChanges(); 
            return NoContent(); // 204 No Content for successful deletion
        }
    }
}
