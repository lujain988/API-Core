using Microsoft.AspNetCore.Mvc;
using WebApplication13.DTOs;
using NCalc;


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

        [HttpPost("math")]
        public IActionResult Math([FromForm] Mathmatics num)
        {
            if (num == null || string.IsNullOrWhiteSpace(num.Expression))
            {
                return BadRequest("Expression cannot be null or empty.");
            }

            var result = EvaluateExpression(num.Expression);
            return Ok(new { result });
        }


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
    }
}
