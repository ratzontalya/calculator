using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class BinaryOperator :ArithmeticMethod
    {
        public override double CalculateOperator(List<string> exercise, int operationIndex)
        {
            List<string> localExercise = new List<string>(exercise);
            List<string> subExercise = HigherOperatorsSubExercise(localExercise.GetRange(operationIndex + 1, localExercise.Count - operationIndex - 1), localExercise[operationIndex]);
            int subExerciseLength = subExercise.Count;
            double subExerciseResult = calculator.Calculate(subExercise);

            localExercise.RemoveRange(operationIndex + 1, subExerciseLength);
            localExercise.Insert(operationIndex + 1, subExerciseResult.ToString());

            if (localExercise.Count < 3 || !Double.TryParse(localExercise[operationIndex - 1], out double left) || !Double.TryParse(localExercise[operationIndex + 1], out double right))
                throw new Exception("This operator is a binary operator, you need 2 numbers for it");
            double operatorResult = Operation(left, right);
            localExercise.RemoveRange(operationIndex - 1, 3);
            localExercise.Insert(operationIndex - 1, operatorResult.ToString());

            return calculator.Calculate(localExercise, operationIndex);
        }
    }
}
