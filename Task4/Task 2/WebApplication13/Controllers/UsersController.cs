﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication13.DTOs;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly MyDbContext _Db;

        public UsersController(MyDbContext db)
        {

            _Db = db;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = _Db.Users.Join(_Db.Orders,
                user=>user.Id, order => order.UserId,(user,order)=>new {
                id = user.Id,
                username = user.Username,
                password= user.Password,
                email = user.Email,
                orders = new
                {
                    OrderID = order.Id,
                    OrderDate= order.OrderDate
                
                }

                }
                ).ToList();
            if (user == null)
            {
                return NotFound("No user found.");
            }
            return Ok(user);
        }
        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            var user = _Db.Users.Join(_Db.Orders, 
                user=>user.Id , order=>order.UserId, (user, order)=> new
                {
                    id = user.Id,
                    username = user.Username,
                    password = user.Password,
                    email = user.Email,
                    order= new
                    {
                        OrdedrID = order.Id,
                        OrderDate= order.OrderDate
                    }
                }).Where(c => c.id == id).FirstOrDefault();
            if (user == null) { return NotFound("No user found."); }

            return Ok(user);
        }
        [HttpGet("Name/{name}")]
        public IActionResult GetUserByID(string name)
        {
            var user = _Db.Users.Where(p => p.Username == name).ToList();
            if (user == null) { return NotFound("No user found."); }

            return Ok(user);
        }
        [HttpDelete]

        public IActionResult DeleteUser(int id)
        {
            var user = _Db.Users.Include(o=> o.Orders).FirstOrDefault(p => p.Id == id);
            if (user == null)
            {
                return NotFound("Order not found");
            }
            if (user.Orders != null) { 
            
                _Db.Orders.RemoveRange(user.Orders);
            }

            _Db.Users.Remove(user);
            _Db.SaveChanges();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult PostPro([FromForm] userRequestDTO user)
        {
          
            var newUser = new User
            {
              Username= user.Username,
                Password= user.Password,
                Email= user.Email

            };
            _Db.Add(newUser);
            _Db.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] userRequestDTO user)

        {
            var ExistUser = _Db.Users.Find(id);
            if (ExistUser == null)
            {
                return NotFound();
            }


            ExistUser.Username = user.Username;
            ExistUser.Password = user.Password;
            ExistUser.Email = user.Email;
            _Db.Products.Update(ExistUser);
            _Db.SaveChanges();
            return Ok(user);
        }

    }
}


