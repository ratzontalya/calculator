using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class ArithmeticMethod : ArithmeticSign
    {
        protected Dictionary<int, string[]> operationsOrder = new Dictionary<int,string[]>(){ 
            { 1, new string[]{"+", "-"} }, 
            { 2, new string[] { "~" } },  
            { 3, new string[] { "*", "/" } }, 
            { 4, new string[] { "(", ")" } } 
        };
        protected abstract double Operation(params double[] numbers);
        protected List<string> HigherOperatorsSubExercise(List<string> exercise, string currentOperation)
        {
            int currentOperationLevel = operationsOrder.FirstOrDefault(keyValue => keyValue.Value.Contains(currentOperation)).Key;
            string[] lowerOperations = operationsOrder.Keys.ToList().FindAll(key => key <= currentOperationLevel)
                                                                   .Select(key => operationsOrder[key])
                                                                   .SelectMany(value => value).ToArray();
            int openBrackets = 0;
            bool isFinished = false;
            List<string> subExercise = exercise.Where((character) =>
            {
                bool addCharacter = false;
                if (openBrackets == 0 && lowerOperations.Contains(character))
                    isFinished = true;
                if (character == "(") openBrackets += 1;
                if (character == ")") openBrackets -= 1;
                if (!isFinished)
                    addCharacter = true;
                return addCharacter;
            }).ToList();
            return subExercise;
        }
        
    }
}
