using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2MalikovaAA_BPI2301.Classes
{
    public class SecantFunction : TrigonometricFunction
    {
        public SecantFunction(double coefficient = 1.0, double phaseShift = 0.0)
            : base(coefficient, phaseShift)
        {
        }

        public override double Calculate(double x)
        {
            CheckDomain(x, "sec");

            double argument = Coefficient * x + PhaseShift;
            double cosValue = Math.Cos(argument);

            if (Math.Abs(cosValue) < 1e-10)
                throw new ArgumentException($"Секанс не определен для x = {x} (cos({argument}) = 0)");

            return 1.0 / cosValue;
        }

        public override IFunction GetDerivative()
        {
            return new CompositeFunction(
                new SecantFunction(Coefficient, PhaseShift),
                new TangentFunction(Coefficient, PhaseShift),
                (sec, tan) => sec * tan * Coefficient
            );
        }

        public override string ToString()
        {
            if (PhaseShift == 0)
                return $"sec({Coefficient}x)";
            else
                return $"sec({Coefficient}x + {PhaseShift})";
        }
    }
}
