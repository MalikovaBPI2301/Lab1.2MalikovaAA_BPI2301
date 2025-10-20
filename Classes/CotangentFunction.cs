using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2MalikovaAA_BPI2301.Classes
{
    public class CotangentFunction : TrigonometricFunction
    {
        public CotangentFunction(double coefficient = 1.0, double phaseShift = 0.0)
            : base(coefficient, phaseShift)
        {
        }

    
        public override double Calculate(double x)
        {
            CheckDomain(x, "cot");

            double argument = Coefficient * x + PhaseShift;
            double tanValue = Math.Tan(argument);

            if (Math.Abs(tanValue) < 1e-10)
                throw new ArgumentException($"Котангенс не определен для x = {x} (tan({argument}) = 0)");

            return 1.0 / tanValue;
        }

        public override string ToString()
        {
            return $"cot({Coefficient}x + {PhaseShift})";
        }
    }
}
