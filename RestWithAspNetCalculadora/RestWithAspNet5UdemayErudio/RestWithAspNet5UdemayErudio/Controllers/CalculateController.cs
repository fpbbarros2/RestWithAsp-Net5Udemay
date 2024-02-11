using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet5UdemayErudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateController : ControllerBase
    {
      

        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());


            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(sub.ToString());


            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(mult.ToString());


            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2 ;

                return Ok(med.ToString());


            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("SquareRoot/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {

            if (IsNumeric(firstNumber))
            {
                var raiz =  Math.Sqrt(ConvertToDouble(firstNumber));

                return Ok(raiz.ToString());


            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                if (secondNumber == "0")
                {
                    return BadRequest("It is not possible to divide by zero");
                }

                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());


            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strNumber)
        {

            decimal decimalValue;

            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        private double ConvertToDouble(string strNumber)
        {

            double doubleValue;

            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }

            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = Double.TryParse(strNumber, System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }
    }
}
