using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Lab1._2MalikovaAA_BPI2301.Classes
{
    public abstract class TrigonometricFunction : IFunction
    {
        public double Coefficient { get; protected set; }
        public double PhaseShift { get; protected set; }
        protected TrigonometricFunction(double coefficient = 1.0, double phaseShift = 0.0)
        {
            Coefficient = coefficient;
            PhaseShift = phaseShift;
        }
        public abstract double Calculate(double x);
        public virtual IFunction GetDerivative()
        {
            throw new NotImplementedException("Метод должен быть переопределен в производном классе");

        }
        public virtual string ToString()
        {
            return $"Тригонометрическая функция";

        }
        protected void CheckDomain(double x, string functionName)
        {
            if (double.IsInfinity(x) || double.IsNaN(x))
                throw new ArgumentException($"Недопустимое значение х для функции {functionName}");

        }
    }
}
