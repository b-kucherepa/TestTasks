namespace TestTasks.PolynomialCalculations
{
    internal class PolynomialMenu : TestMenu
    {
        private const int MIN_X = -100000;
        private const int MAX_X = 100000;
        private const int MIN_COEFFICIENT = -10000;
        private const int MAX_COEFFICIENT = 10000;

        public override void Select()
        {
            Console.WriteLine("\nSelect a polynomial solve algorithm:");
            Console.WriteLine("> Enter 1 to use primitive implementation,");
            Console.WriteLine("> Enter 2 to use Horner scheme algorithm,");
            Console.WriteLine("< Enter any other key to return.");

            PolynimialCalculator calculator;
            switch (Console.ReadLine())
            {
                case "1":
                    calculator = new SimplePolynomialCalculator();
                    break;
                case "2":
                    calculator = new HornerPolynimialCalculator();
                    break;
                default:
                    return;
            }

            Console.WriteLine("\nInput polynomial coefficients as integers separated by space "
                + $"({MIN_COEFFICIENT}-{MAX_COEFFICIENT}):");
            int[] polynomialCoefficients = ReadIntegersArray(" ", MIN_COEFFICIENT, MAX_COEFFICIENT);
            string equation = DisplayPolynomialEquation(polynomialCoefficients);

            Console.WriteLine("\nEquation to sort is:");
            Console.WriteLine(equation);

            Console.WriteLine($"\nEnter x to calculate the evaluation ({MIN_X}-{MAX_X}):");
            int x = ReadNumberInLimit(MIN_X, MAX_X);
            _timer.Restart();
            long result = calculator.Solve(x, polynomialCoefficients);
            _timer.Stop();
            Console.WriteLine("\nThe result is:");
            Console.WriteLine(result);
            Console.WriteLine("\nAn approximate execution time (more precise with bigger equations): "
                + _timer.Elapsed + "ms.\n");

            Select();
        }

        private string DisplayPolynomialEquation(int[] coefficients)
        {
            string equation = "";
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                string sign = "";
                string coefficient = "";
                string charge = "";

                if (i < coefficients.Length - 1)
                {
                    if (coefficients[i] > 0)
                    {
                        sign = " + ";
                    }
                    else if (coefficients[i] < 0)
                    {
                        sign = " - ";
                    }
                    else
                    {
                        continue;
                    }
                }

                if (Math.Abs(coefficients[i]) > 1)
                {
                    coefficient += Math.Abs(coefficients[i]);
                }

                if (i == 1)
                {
                    charge += "x";
                }
                else if (i > 1)
                {
                    charge += $"x^{i}";
                }

                equation += sign + coefficient + charge;
            }

            return equation;
        }
    }
}
