using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    public class Converter
    {
        public List<string> ConvertExerciseToList(string exercise)
        {
            exercise = exercise.Replace("+-", "-");
            exercise = exercise.Replace("-+", "-");

            List<string> splittedExercise = Regex.Split(exercise, @"(\+|\(|\)|\)|\*|\/|\-)").ToList();
            splittedExercise.RemoveAll(character => character == "");

            IActionFactory actionFactory = new ActionFactory();
            int index = 0;
            List<string> convertedExercise = splittedExercise.Select(character =>
            {
                if (character == "-" && (index == 0 || actionFactory.GetArithmeticSigns().Contains(splittedExercise[index - 1])))
                    character = "~";
                index += 1;
                return character;
            }).ToList();

            return convertedExercise;
        }
    }
}
