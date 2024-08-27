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

      

    }
}
