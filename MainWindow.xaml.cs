using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab1._2MalikovaAA_BPI2301.Classes;

namespace Lab1._2MalikovaAA_BPI2301
{

    public partial class MainWindow : Window
    {
        private SecantFunction secant;
        private CosecantFunction cosecant;
        private CotangentFunction cotangent;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFunctions();
        }

        private void InitializeFunctions()
        {
            secant = new SecantFunction(2.0, 0.5);
            cosecant = new CosecantFunction(1.5, -0.3);
            cotangent = new CotangentFunction(1.0, 0.2);

            statusText.Text = "Функции инициализированы";
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = double.Parse(txtX.Text);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("=== ВЫЧИСЛЕНИЕ ЗНАЧЕНИЙ ФУНКЦИЙ ===");
                sb.AppendLine($"x = {x}");
                sb.AppendLine();

                DemonstrateFunctions(sb, x);

                txtResults.Text = sb.ToString();
                statusText.Text = "Вычисления завершены успешно";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                statusText.Text = "Ошибка при вычислениях";
            }
        }

        private void BtnDerivatives_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("=== ПРОИЗВОДНЫЕ ФУНКЦИЙ ===");
                sb.AppendLine();

                DemonstrateDerivatives(sb);

                txtResults.Text = sb.ToString();
                statusText.Text = "Производные вычислены";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                statusText.Text = "Ошибка при вычислении производных";
            }
        }

        private void BtnTestAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("=== ТЕСТ ВСЕХ МЕТОДОВ КЛАССОВ ===");
                sb.AppendLine();

                TestAllMethods(sb);

                txtResults.Text = sb.ToString();
                statusText.Text = "Все тесты выполнены";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                statusText.Text = "Ошибка при тестировании";
            }
        }

     
        private void DemonstrateFunctions(StringBuilder sb, double x)
        {
            try
            {
                double secValue = secant.Calculate(x);
                sb.AppendLine($"1. {secant} = {secValue:F6}");
                sb.AppendLine($"   Коэффициент: {secant.Coefficient}, Сдвиг: {secant.PhaseShift}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"1. {secant} = ОШИБКА: {ex.Message}");
            }

            try
            {
                double cscValue = cosecant.Calculate(x);
                sb.AppendLine($"2. {cosecant} = {cscValue:F6}");
                sb.AppendLine($"   Коэффициент: {cosecant.Coefficient}, Сдвиг: {cosecant.PhaseShift}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"2. {cosecant} = ОШИБКА: {ex.Message}");
            }

            try
            {
                double cotValue = cotangent.Calculate(x);
                sb.AppendLine($"3. {cotangent} = {cotValue:F6}");
                sb.AppendLine($"   Коэффициент: {cotangent.Coefficient}, Сдвиг: {cotangent.PhaseShift}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"3. {cotangent} = ОШИБКА: {ex.Message}");
            }
        }

 
        private void DemonstrateDerivatives(StringBuilder sb)
        {
            try
            {
                IFunction secDerivative = secant.GetDerivative();
                sb.AppendLine($"1. Производная {secant}:");
                sb.AppendLine($"   {secDerivative}");
                sb.AppendLine($"   Тип: {secDerivative.GetType().Name}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"1. Ошибка производной секанса: {ex.Message}");
            }

            try
            {
                IFunction cscDerivative = cosecant.GetDerivative();
                sb.AppendLine($"2. Производная {cosecant}:");
                sb.AppendLine($"   {cscDerivative}");
                sb.AppendLine($"   Тип: {cscDerivative.GetType().Name}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"2. Ошибка производной косеканса: {ex.Message}");
            }

            try
            {
                IFunction cotDerivative = cotangent.GetDerivative();
                sb.AppendLine($"3. Производная {cotangent}:");
                sb.AppendLine($"   {cotDerivative}");
                sb.AppendLine($"   Тип: {cotDerivative.GetType().Name}");
            }
            catch (Exception ex)
            {
                sb.AppendLine($"3. Ошибка производной котангенса: {ex.Message}");
                sb.AppendLine("   (Это ожидаемо - метод не переопределен в классе CotangentFunction)");
            }
        }

        private void TestAllMethods(StringBuilder sb)
        {
            sb.AppendLine("=== ДЕМОНСТРАЦИЯ НАСЛЕДОВАНИЯ ===");
            sb.AppendLine("Создание функций с вызовом конструктора базового класса:");
            sb.AppendLine($"- SecantFunction(2.0, 0.5) -> Coefficient={secant.Coefficient}, PhaseShift={secant.PhaseShift}");
            sb.AppendLine($"- CosecantFunction(1.5, -0.3) -> Coefficient={cosecant.Coefficient}, PhaseShift={cosecant.PhaseShift}");
            sb.AppendLine($"- CotangentFunction(1.0, 0.2) -> Coefficient={cotangent.Coefficient}, PhaseShift={cotangent.PhaseShift}");
            sb.AppendLine();

            sb.AppendLine("=== РАБОТА С ИНТЕРФЕЙСОМ IFunction ===");
            IFunction[] functions = { secant, cosecant, cotangent };

            for (int i = 0; i < functions.Length; i++)
            {
                sb.AppendLine($"{i + 1}. Функция через интерфейс:");
                sb.AppendLine($"   ToString(): {functions[i].ToString()}");
                sb.AppendLine($"   Тип: {functions[i].GetType().Name}");

                try
                {
                    double testValue = functions[i].Calculate(0.5);
                    sb.AppendLine($"   Calculate(0.5) = {testValue:F6}");
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"   Calculate(0.5) = ОШИБКА: {ex.Message}");
                }
                sb.AppendLine();
            }

            sb.AppendLine("=== ПЕРЕГРУЖЕННЫЕ МЕТОДЫ ToString() ===");
            sb.AppendLine($"Секанс: {secant.ToString()}");
            sb.AppendLine($"Косеканс: {cosecant.ToString()}");
            sb.AppendLine($"Котангенс: {cotangent.ToString()}");
            sb.AppendLine();

            sb.AppendLine("=== ТЕСТ ГРАНИЧНЫХ ЗНАЧЕНИЙ ===");
            double[] testPoints = { 0.1, Math.PI / 4, Math.PI / 2, Math.PI };

            foreach (double point in testPoints)
            {
                sb.AppendLine($"x = {point:F4}:");

                foreach (var func in functions)
                {
                    try
                    {
                        double value = func.Calculate(point);
                        sb.AppendLine($"   {func.GetType().Name}: {value:F6}");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine($"   {func.GetType().Name}: НЕ ОПРЕДЕЛЕН ({ex.Message})");
                    }
                }
                sb.AppendLine();
            }
        }
    }
}
