using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private static Calculator instance;
        public static IActionFactory actionFactory = new ActionFactory();
        public static Dictionary<string, ArithmeticSign> actionDictionary = new Dictionary<string, ArithmeticSign>(){
            {"*", new Mult()},
            { "(", new Bracket()},
            { "/", new Divide() },
            { "+", new Plus()},
            { "-", new Minus()},
            { "~", new HonoraryMinus()  } };

        protected Calculator() { }
        public static Calculator Instance()
        {
            if (instance == null)
            {
                instance = new Calculator();
            }
            return instance;
        }
        public void ValidateExercise(string exercise)
        {
            int validateBrackets = 0;
            foreach (char character in exercise)
            {
                validateBrackets += character == '(' ? 1 : 0;
                validateBrackets -= character == ')' ? 1 : 0;
                if (validateBrackets == -1) throw new Exception("Please use the brackets correctly.");
            }
            if (validateBrackets != 0) throw new Exception("Please use the brackets correctly.");

            if (exercise.Contains("*/")) throw new Exception("Please don't use */ together");
            if (exercise.Contains("/*")) throw new Exception("Please don't use /* together");
            if (exercise.Contains("/0")) throw new Exception("You can't divide number with zero");

            if (!Regex.IsMatch(exercise, @"^[0-9*()+-\/]+$"))
                throw new Exception("Please use only numbers and arithmetic signs");
            if(Regex.IsMatch(exercise, @"^[0-9]+[(]+|[)]+[0-9]+$"))
                throw new Exception("Please write arithmetic sign before and after brackets");
        }
        public static string[] GetArithmeticSigns()
        {
            string[] arithmeticSigns = new string[actionDictionary.Keys.Count];
            foreach (string key in actionDictionary.Keys)
            {
                arithmeticSigns.Append(key);
            }
            return arithmeticSigns;
        }

        public List<string> ConvertExerciseToList(string exercise)
        {
            exercise = exercise.Replace("+-", "-");
            exercise = exercise.Replace("-+", "-");

            List<string> splittedExercise = Regex.Split(exercise, @"(\+|\(|\)|\)|\*|\/|\-)").ToList();
            splittedExercise.RemoveAll(character => character == "");

            int index = 0;
            List<string> convertedExercise = splittedExercise.Select(character =>
            {
                if (character == "-" && (index == 0 || GetArithmeticSigns().Contains(character)))
                    character = "~";
                index += 1;
                return character;
            }).ToList();

            return convertedExercise;
        }
        public double Calculate(List<string> exercise, int index = 0)
        {
            double result;
            if (exercise.Count == 0) return 0;
            if (exercise.Count == 1 && Double.TryParse(exercise[0], out result)) return result;
            if (actionDictionary.ContainsKey(exercise[index]))
            {
                ArithmeticSign arithmeticSign = actionFactory.CreateAction(exercise[index]);
                result = arithmeticSign.CalculateOperator(exercise, index);
            }
            else
            {
                result = Calculate(exercise, index + 1);
            }
            return result;
        }
    }
}
