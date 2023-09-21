﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public IActionFactory actionFactory;
        public Calculator() {
            actionFactory = new ActionFactory();
        }

        public double Calculate(List<string> exercise, int index = 0)
        {
            double result;
            if (exercise.Count == 0) return 0;
            if (exercise.Count == 1 && Double.TryParse(exercise[0], out result)) return result;
            if (actionFactory.GetArithmeticSigns().Contains(exercise[index]))
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
