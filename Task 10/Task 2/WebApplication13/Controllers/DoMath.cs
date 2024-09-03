using Microsoft.AspNetCore.Mvc;
using WebApplication13.DTOs;
using NCalc;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApplication13.Controllers
{
    public class DoMath : Controller
    {
        private object EvaluateExpression(string expression)
        {
            Expression e = new Expression(expression);
            var result = e.Evaluate();

            return result;
        }
        [HttpGet("math")]
        public IActionResult Mathmatics([FromQuery] Mathmatics num)
        {
            if (num == null || string.IsNullOrWhiteSpace(num.Expression))
            {
                return BadRequest("Expression cannot be null or empty.");
            }

            var result = EvaluateExpression(num.Expression);
            return Ok(new { result });
        }

        //[HttpPost("math")]
        //public IActionResult Math([FromForm] Mathmatics num)
        //{
        //    if (num == null || string.IsNullOrWhiteSpace(num.Expression))
        //    {
        //        return BadRequest("Expression cannot be null or empty.");
        //    }

        //    var result = EvaluateExpression(num.Expression);
        //    return Ok(new { result });
        //}


        [HttpGet("mathmatics")]
        public IActionResult Mathmatic([FromQuery] math num)
        {
           
            bool Number = (num.Number1 == 30 || num.Number2 == 30 || (num.Number1 + num.Number2) == 30);

            return Ok(new { result = Number });
        }
        [HttpGet("Math1")]
        public IActionResult Mathmaticss( int num)
        {


            if (num <= 0)
            {
                return BadRequest("Input must be a positive number.");
            }

            bool Number  = (num % 3 == 0 || num % 7 == 0);
            return Ok(new { result = Number });


        }
        [HttpGet("Math2")]
        public IActionResult Mathmaticss1(double num)
        {
            var years = num.ToString();
            years = years.PadLeft(4, '0');
            years = years.Insert(years.Length - 2, ".");
            double Y1 = double.Parse(years);
            var Y = Math.Ceiling(Y1);

            return Ok(Y);
        }
        [HttpGet("%")]
        public IActionResult divide(int n, int x, int y){
            {
                if (n % x == 0 && n % y == 0)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }

            }

            
            }
        [HttpGet("split")]
        public IActionResult split(string s)
        {

            string[] words = s.Split(' ');
            int lujain = words.Min(w => w.Length);

            return Ok(lujain);
        }
        [HttpPost("odd-count-numbers")]
        public IActionResult GetOddCountNumbers([FromBody] List<int> numbers)
        {
            var oddCountNumbers = numbers
                .GroupBy(n => n)
                .Where(g => g.Count() % 2 != 0)
                .Select(g => g.Key)
                .ToList();

            return Ok(oddCountNumbers);
        }
    }


}


