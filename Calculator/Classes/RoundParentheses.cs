using Calculator.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class RoundParentheses : Parentheses
    {
        public RoundParentheses(string character)
        {
            isOpen = character == "(" ? true : false;
        }
        public override double CalculateOperator(List<string> exercise, int index)
        {
            return calculator.Calculate(exercise.GetRange(1, exercise.Count - 2), index + 1);
        }
    }
}
