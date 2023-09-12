using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ActionFactory : IActionFactory
    {
        public ArithmeticSign CreateAction(string sign)
        {
            ArithmeticSign arithmeticSign;
            if (Calculator.actionDictionary.ContainsKey(sign))
                arithmeticSign = Calculator.actionDictionary[sign];
            else
                throw new Exception($"The sign {sign} is not valid");
            return arithmeticSign;
        }
    }
}
