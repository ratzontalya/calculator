using Calculator.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class Validator
    {
        public static IActionFactory actionFactory = new ActionFactory();
        public void ValidateBrackets(string exercise)
        {
            int validateBrackets = 0;
            foreach (char character in exercise)
            {
                if (!Double.TryParse(character.ToString(), out double result))
                {
                    ArithmeticSign arithmeticSign = actionFactory.CreateAction(character.ToString());
                    validateBrackets += arithmeticSign is Parentheses && ((Parentheses)arithmeticSign).isOpen ? 1 : 0;
                    validateBrackets -= arithmeticSign is Parentheses && !((Parentheses)arithmeticSign).isOpen ? 1 : 0;
                    if (validateBrackets == -1) throw new Exception("Please use the brackets correctly.");
                }
            }
            if (validateBrackets != 0) throw new Exception("Please use the brackets correctly.");
        }
        public void ValidateSignsType(string exercise)
        {
            if (!Regex.IsMatch(exercise, @"^[0-9*()+-\/]+$"))
                throw new Exception("Please use only numbers and arithmetic signs");
        }
        public void ValidateSignsAfterBrackets(string exercise)
        {
            if (Regex.IsMatch(exercise, @"^[0-9]+[(]+|[)]+[0-9]+$"))
                throw new Exception("Please write arithmetic sign before and after brackets");
        }
        public void ValidateExercise(string exercise)
        {
            ValidateBrackets(exercise);
            ValidateSignsType(exercise);
            ValidateSignsAfterBrackets(exercise);
        }
    }
}
