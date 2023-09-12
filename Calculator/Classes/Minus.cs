using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Minus : BinaryOperator
    {
        protected override double Operation(double[] numbers)
        {
            return numbers[0] - numbers[1];
        }


    }
}
