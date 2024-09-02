using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication13.DTOs;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cartItemController : ControllerBase
    {
        private readonly MyDbContext _Db;

        private readonly ILogger<OrdersController> _logger;


        public cartItemController(MyDbContext db, ILogger<OrdersController> logger)
        {

            _Db = db;
            _logger = logger;

        }

        [HttpGet]
        public IActionResult getItem()
        {
            var Item = _Db.CartItems.Join(_Db.Products,
                cart => cart.ProductId,
                product => product.Id,
                (cart, product) => new
                {
                    id = cart.Id,
                    cartId = cart.CartId,
                    quantity = cart.Quantity,
                    product = new {
                        ProductId = product.Id,
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Description= product.Description,
                        ProductImage = product.ProductImage,
                    }
                }
                ).ToList();
            _logger.LogInformation("I am Lujain ,");


            return Ok(Item);
        }

        [HttpPost]
        public IActionResult PostItem([FromBody] cartitemRequestDTO cart)
        {
            if (cart == null)
            {
                return BadRequest("Invalid cart item data.");
            }

            var cartItem = new CartItem
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity
            };

            _Db.CartItems.Add(cartItem);
            _Db.SaveChanges();

            return Ok(cartItem);
        }

        [HttpPut("{id}")]
        public IActionResult PutCartItem(int id, [FromBody] cartitemRequestDTO cart)
        {
            var existingItem = _Db.CartItems.Find(id);

            existingItem.CartId= cart.CartId;
            existingItem.ProductId= cart.ProductId;
            existingItem.Quantity = cart.Quantity;
            _Db.CartItems.Update(existingItem);
            _Db.SaveChanges();

            return Ok(existingItem);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCartItem(int id) {

            var Delete = _Db.CartItems.FirstOrDefault(x => x.Id==id);
            _Db.CartItems.Remove(Delete);
            _Db.SaveChanges();
            return Ok(Delete);
        }

        [HttpPut("/increment/{id}")]
        public IActionResult Increment([FromBody] cartitemRequestDTO2 cart, int id)
        {
            var item = _Db.CartItems.Find(id);

            if (item.Quantity > 1)
            {

                item.Quantity += cart.Quantity;
                _Db.CartItems.Update(item);
            }
            else
            {

                _Db.CartItems.Remove(item);
            }
            _Db.SaveChanges();
            return Ok(item.Quantity);
        }

        //[HttpPut("/decrement/{id}")]
        //public IActionResult Decrement([FromBody] cartitemRequestDTO2 cart, int id)
        //{
        //    var item = _Db.CartItems.Find(id);
        //    if (item.Quantity > 0)
        //    {

        //        item.Quantity += cart.Quantity;
        //        _Db.CartItems.Update(item);
        //        _Db.SaveChanges();
        //    }
        //    return Ok(item.Quantity);

        //}

    }
}
