using Calculator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        const string shouldContinue = "y";
        static void Main(string[] args)
        {
            try
            {
                string toContinue = shouldContinue;
                while (toContinue == shouldContinue)
                {
                    Console.WriteLine("Please enter:");
                    string exercise = Console.ReadLine();

                    Calculator calculator = Calculator.Instance();
                    Validator validator = new Validator();
                    validator.ValidateExercise(exercise);
                    Converter converter = new Converter();
                    List<string> convertedExercise = converter.ConvertExerciseToList(exercise);

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
