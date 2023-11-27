namespace TestTasks.PolynomialCalculations
{
    internal class PolynomialMenu : TestMenu
    {
        private const int MIN_X = -100000;
        private const int MAX_X = 100000;
        private const int MIN_COEFFICIENT = -10000;
        private const int MAX_COEFFICIENT = 10000;

        private int[] _polynomialCoefficients = new int[0];
        private int _polynomialVariable = 0;


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

            SetupCoefficients();

            SetupPolynomialVariable();

            long result = -1;
            string executionTime = MeasureTime(() =>
            {
                result = calculator.Solve(_polynomialVariable, _polynomialCoefficients);
            });

            Console.WriteLine("\nThe result is:");
            Console.WriteLine(result);
            Console.WriteLine("\nAn approximate execution time (more precise with bigger equations): "
                + executionTime + "ms.\n");

            Select();
        }


        private int[] SetupCoefficients()
        {
            Console.WriteLine("\nInput polynomial coefficients as integers separated by space "
                + $"({MIN_COEFFICIENT}-{MAX_COEFFICIENT}):");

            int[] _polynomialCoefficients = ReadIntegersArray(" ", MIN_COEFFICIENT, MAX_COEFFICIENT);
            string equation = DisplayPolynomialEquation(_polynomialCoefficients);

            Console.WriteLine("\nEquation to sort is:");
            Console.WriteLine(equation);
            return _polynomialCoefficients;
        }


        private void SetupPolynomialVariable()
        {
            Console.WriteLine($"\nEnter x to calculate the evaluation ({MIN_X}-{MAX_X}):");

            bool readIsSuccessful = ReadNumberInLimit(MIN_X, MAX_X, out int polynomialVariable);
            if (readIsSuccessful)
            {
                _polynomialVariable = polynomialVariable;
            }
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
                    charge += "polynomialVariable";
                }
                else if (i > 1)
                {
                    charge += $"polynomialVariable^{i}";
                }

                equation += sign + coefficient + charge;
            }

            return equation;
        }
    }
}
