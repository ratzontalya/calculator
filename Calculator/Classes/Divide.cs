using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Divide : BinaryOperator
    {
        protected  override double Operation(double[] numbers)
        {
            if (numbers[1] == 0)
                throw new Exception("You can't divide number by zero");
            return numbers[0] / numbers[1];
        }
    }
}
