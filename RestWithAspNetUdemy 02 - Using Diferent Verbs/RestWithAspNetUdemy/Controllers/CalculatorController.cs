using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        // GET api/Calculator/sum/5/5
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculator/subtraction/5/5
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculator/division/5/5
        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {

                if (ConvertToDecimal(secondNumber) != 0)
                {
                    var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                    return Ok(division.ToString());
                }
                else {
                    return BadRequest("Invalid divisor");
                }
            }

            return BadRequest("Invalid Imput");

        }

        // GET api/Calculator/multiplication/5/5
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculator/mean/5/5
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = ( ( ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) ) / 2 );

                return Ok(mean.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        // GET api/Calculator/square-root/5
        [HttpGet("square-root/{number}")]
        public IActionResult Squareroot(string number)
        {
            if (IsNumeric(number))
            {
                var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));

                return Ok(squareRoot.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;

        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;

        }
    }
}
