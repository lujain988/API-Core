﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NCalc;
using System.Data;
using WebApplication13.DTOs;
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
        [HttpGet("{id:int}")]
        public IActionResult GetCatByID(int id)
        {
            var cat = _Db.Categories.Join(_Db.Products,
                cat => cat.Id,
                product => product.CategoryId,
                (cat, product) => new
                {
                    id = cat.Id,
                    categoryName = cat.CategoryName,
                    categoryImage = cat.CategoryImage,
                    products = product.ProductName
                }
                ).Where(c => c.id == id).FirstOrDefault();
            if (cat == null) { return NotFound("No categories found."); }

            return Ok(cat);
        }
        [HttpGet("Name/{name}")]
        public IActionResult GetProByID(string name)
        {
            var pro = _Db.Categories.Where(p => p.CategoryName == name).ToList();
            if (pro == null) { return NotFound("No categories found."); }

            return Ok(pro);
        }

        [HttpPost]
        public IActionResult PostNew([FromForm] categoryRequestDTO category)
        {
            if (category == null)
            {
                return BadRequest("Category data is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(UploadedFolder))
            {
                Directory.CreateDirectory(UploadedFolder);
            }
            var ImageFile = Path.Combine(UploadedFolder, category.CategoryImage.FileName);
            using (var strem = new FileStream(ImageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(strem);
            }

            var categorynew = new Category
            {
                CategoryName = category.CategoryName,
                CategoryImage = category.CategoryImage.FileName,
            };
            {

            };
            _Db.Categories.Add(categorynew);
            _Db.SaveChanges();

            return Ok(categorynew);

        }
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, [FromForm] categoryRequestDTO category)
        {
            // Check if the category exists
            var existingCategory = _Db.Categories.Find(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }
            var UploadedFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(UploadedFolder))
            {
                Directory.CreateDirectory(UploadedFolder);
            }
            var ImageFile = Path.Combine(UploadedFolder, category.CategoryImage.FileName);
            using (var strem = new FileStream(ImageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(strem);
            }
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryImage = category.CategoryImage.FileName;

            _Db.Categories.Update(existingCategory);
            _Db.SaveChanges();

            return Ok(existingCategory);
        }
        [HttpDelete("{id}")]

        public IActionResult DeletePro(int id)
        {
            var pro = _Db.Categories.FirstOrDefault(p => p.Id == id);

            _Db.Products.RemoveRange(pro.Products);
            _Db.Categories.Remove(pro);
            _Db.SaveChanges();
            return Ok(pro);
        }

    }

} 

