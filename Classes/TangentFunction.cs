using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2MalikovaAA_BPI2301.Classes
{
    public class TangentFunction : TrigonometricFunction
    {
        public TangentFunction(double coefficient = 1.0, double phaseShift = 0.0)
            : base(coefficient, phaseShift)
        {
        }


        public override double Calculate(double x)
        {
            CheckDomain(x, "tan");

            double argument = Coefficient * x + PhaseShift;

            double cosValue = Math.Cos(argument);
            if (Math.Abs(cosValue) < 1e-10)
                throw new ArgumentException($"Тангенс не определен для x = {x} (cos({argument}) = 0)");

            return Math.Tan(argument);
        }


        public override IFunction GetDerivative()
        {
            return new CompositeFunction(
                new SecantFunction(Coefficient, PhaseShift),
                new SecantFunction(Coefficient, PhaseShift),
                (sec1, sec2) => sec1 * sec2 * Coefficient
            );

        }

        public override string ToString()
        {
            if (PhaseShift == 0)
                return $"tan({Coefficient}x)";
            else
                return $"tan({Coefficient}x + {PhaseShift})";
        }
    }
}
