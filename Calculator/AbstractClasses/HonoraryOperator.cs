using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class HonoraryOperator : ArithmeticMethod
    {
        public override double CalculateOperator(List<string> exercise, int operationIndex)
        {
            List<string> subExercise = HigherOperatorsSubExercise(exercise.GetRange(operationIndex + 1, exercise.Count - operationIndex - 1), exercise[operationIndex]);
            int subExerciseLength = subExercise.Count;
            double subExerciseResult = calculator.Calculate(subExercise);

            exercise.RemoveRange(operationIndex + 1, subExerciseLength);
            exercise.Insert(operationIndex + 1, subExerciseResult.ToString());

            if ((exercise.Count < 2) || (!Double.TryParse(exercise[operationIndex + 1], out double number)))
                throw new Exception("Incorrect input ");
            double operatorResult = Operation(number);
            exercise.RemoveRange(operationIndex, 2);
            exercise.Insert(operationIndex, operatorResult.ToString());

            return calculator.Calculate(exercise, operationIndex);
        }
    }
}
