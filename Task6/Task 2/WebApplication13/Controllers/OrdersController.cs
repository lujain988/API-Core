using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyDbContext _Db;

        public OrdersController(MyDbContext db)
        {

            _Db = db;
        }
        [HttpGet]
        public IActionResult GetOR()
        {
            var order = _Db.Orders.Join(_Db.Products, order=>order.ProductId, 
                product=>product.Id, (order, product)=>new {order,product})
                .Join(_Db.Users, op=>op.order.UserId,
                user=>user.Id, (op, user)=> new
                {
                    id = op.order.Id,
                    userID =    user.Id,
                    orderDate = op.order.OrderDate,
                    productID = op.order.ProductId,
                    quantity = op.order.Quantity,
                    product = op.product.ProductName,
                    user = user.Username
                }).ToList();
            if (order == null)
            {
                return NotFound("No categories found.");
            }
            return Ok(order);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetORByID(int id)
        {
            var order = _Db.Orders.
                Join(_Db.Products, order=>order.ProductId, product=>product.Id, (order, porduct)=> new {order, porduct })
                .Join(_Db.Users,op=>op.order.UserId , user => user.Id, 
                (op, user) => new
            {
                id = op.order.Id,
                userID = user.Id,
                orderDate = op.order.OrderDate,
                productID = op.order.ProductId,
                quantity = op.order.Quantity,
                prouduct = op.porduct.ProductName,
                user = user.Username

            }).Where(c => c.id == id).FirstOrDefault();
            if (order == null) { return NotFound("No orders found."); }

            return Ok(order);
        }
        [HttpGet("{name}")]
        public IActionResult GetORByID(string name)
        {
            var orders = _Db.Orders
                .Include(o => o.Product)
                .Include(o => o.User)
                .Where(o => o.Product.ProductName == name)
                .Select(o => new
                {
                    OrderId = o.Id,
                    UserId = o.UserId,
                    OrderDate = o.OrderDate,
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    ProductName = o.Product.ProductName,
                    UserName = o.User.Username
                })
                .ToList();

            if (!orders.Any())
            {
                return NotFound("No orders found for the specified product.");
            }

            return Ok(orders);
        }

        //[HttpGet("Name/{name}")]
        //public IActionResult GetORByID(string name)
        //{
        //    var orders = _Db.Orders
        //   .Join(_Db.Products,
        //         order => order.ProductId,
        //         product => product.Id,
        //         (order, product) => new { order, product })
        //   .Join(_Db.Users,
        //         op => op.order.UserId,
        //         user => user.Id,
        //         (op, user) => new
        //         {
        //             OrderId = op.order.Id,
        //             UserId = op.order.UserId,
        //             OrderDate = op.order.OrderDate,
        //             ProductId = op.order.ProductId,
        //             Quantity = op.order.Quantity,
        //             ProductName = op.product.ProductName,
        //             UserName = user.Username
        //         })
        //   .Where(o => o.ProductName == name)
        //   .ToList();

        //    if (orders == null )
        //    {
        //        return NotFound("No orders found for the specified product.");
        //    }
        //    return Ok(orders);
        //}
        [HttpDelete]

        public IActionResult DeleteOR(int id)
        {
            var order = _Db.Orders.FirstOrDefault(p => p.Id == id);
            if (order == null)
            {
                return NotFound("Order not found.");
            }
            _Db.Orders.Remove(order);
            _Db.SaveChanges();
            return Ok(order);
        }

    }
}

