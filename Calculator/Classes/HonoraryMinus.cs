using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class HonoraryMinus : HonoraryOperator
    {
        protected override double Operation(params double[] numbers)
        {
            return -numbers[0];
        }
    }
}
