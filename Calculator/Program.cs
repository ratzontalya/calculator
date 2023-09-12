using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string toContinue = "y";
                while (toContinue == "y")
                {
                    Console.WriteLine("Please enter:");
                    string exercise = Console.ReadLine();

                    Calculator calculator = Calculator.Instance();
                    calculator.ValidateExercise(exercise);
                    List<string> convertedExercise = calculator.ConvertExerciseToList(exercise);

                    double result = calculator.Calculate(convertedExercise);
                    Console.WriteLine(result);

                    Console.WriteLine("Do you want to continue?y/n");
                    toContinue = Console.ReadLine();
                }
            } catch(Exception error)
            {
                Console.WriteLine(error.Message);
                Console.ReadKey();
            }
        }
    }
}
