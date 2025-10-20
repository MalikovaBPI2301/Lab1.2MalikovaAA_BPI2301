using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2MalikovaAA_BPI2301.Classes
{
    public class CosecantFunction : TrigonometricFunction
    {
        public CosecantFunction(double coefficient = 1.0, double phaseShift = 0.0)
            : base (coefficient, phaseShift)
        {

        }
        public override double Calculate(double x)
        {
            CheckDomain(x, "csc");

            double argument = Coefficient * x + PhaseShift;
            double sinValue = Math.Sin(argument);

            if (Math.Abs(sinValue) < 1e-10)
                throw new ArgumentException($"Косеканс не определен для x = {x} (sin({argument}) = 0)");

            return 1.0 / sinValue;
        }
        public override IFunction GetDerivative()
        {
            return new CompositeFunction(
                new CosecantFunction(Coefficient, PhaseShift),
                new CotangentFunction(Coefficient, PhaseShift),
                (csc, cot) => -csc * cot * Coefficient
            );
        }

        
        public override string ToString()
        {
            string coefficientStr = Coefficient == 1 ? "" : Coefficient.ToString();
            string phaseStr = PhaseShift == 0 ? "" : PhaseShift > 0 ? $" + {PhaseShift}" : $" - {Math.Abs(PhaseShift)}";

            return $"csc({coefficientStr}x{phaseStr})";
        }
    }
}