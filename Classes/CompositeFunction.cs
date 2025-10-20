using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2MalikovaAA_BPI2301.Classes
{
    public class CompositeFunction : IFunction
    {
        private IFunction firstFunction;
        private IFunction secondFunction;
        private Func<double, double, double> operation;

        public CompositeFunction(IFunction func1, IFunction func2, Func<double, double, double> op)
        {
            firstFunction = func1;
            secondFunction = func2;
            operation = op;
        }

        public double Calculate(double x)
        {
            double val1 = firstFunction.Calculate(x);
            double val2 = secondFunction.Calculate(x);
            return operation(val1, val2);
        }

        public IFunction GetDerivative()
        {
            return this;
        }

        public override string ToString()
        {
            return $"Composite({firstFunction}, {secondFunction})";
        }
    }
}
