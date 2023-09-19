using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ActionFactory : IActionFactory
    {
        public static Dictionary<string, ArithmeticSign> actionDictionary = new Dictionary<string, ArithmeticSign>(){
            {"*", new Mult()},
            { "(", new RoundParentheses("(")},
            { ")", new RoundParentheses(")")},
            { "/", new Divide() },
            { "+", new Plus()},
            { "-", new Minus()},
            { "~", new HonoraryMinus()  } };

        public List<string> GetArithmeticSigns()
        {
            List<string> arithmeticSigns = new List<String>();
            foreach (string key in actionDictionary.Keys)
            {
                arithmeticSigns = arithmeticSigns.Append(key).ToList();
            }
            return arithmeticSigns;
        }
        public ArithmeticSign CreateAction(string sign)
        {
            ArithmeticSign arithmeticSign;
            if (actionDictionary.ContainsKey(sign))
                arithmeticSign = actionDictionary[sign];
            else
                throw new Exception($"The sign {sign} is not valid");
            return arithmeticSign;
        }
    }
}
