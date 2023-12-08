namespace TestTasks.PolynomialCalculations
{
    internal class PolynomialMenu : TestMenu
    {
        private const int MIN_X = -100000;
        private const int MAX_X = 100000;
        private const int MIN_COEFFICIENT = -10000;
        private const int MAX_COEFFICIENT = 10000;

        private int[] _polynomialCoefficients = GenerateRandomArray(5, 
            MIN_COEFFICIENT, MAX_COEFFICIENT);
        private int _polynomialVariable = 0;
        private int _innerTestNumber;

        public override void Select()
        {
            ConsoleIO.PrintLine("Select a polynomial solve algorithm:");
            ConsoleIO.PrintLine("> Enter 1 to use primitive implementation,");
            ConsoleIO.PrintLine("> Enter 2 to use Horner scheme algorithm,");
            ConsoleIO.PrintLine("< Enter any other key to return.");

            PolynimialCalculator calculator;
            switch (ConsoleIO.Read())
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
            ConsoleIO.EmptyLine();

            SetupCoefficients();

            SetupPolynomialVariable();

            long result = -1;
            string executionTime = MeasureTime(() =>
            {
                result = calculator.Solve(_polynomialVariable, _polynomialCoefficients);
            });

            ConsoleIO.PrintLine("The result is:");
            ConsoleIO.PrintLine(result);
            ConsoleIO.EmptyLine();
            ConsoleIO.PrintLine("An approximate execution time (more precise with bigger equations): "
                + executionTime + "ms.");
            ConsoleIO.EmptyLine();

            _innerTestNumber++;

            Select();
        }


        private int[] SetupCoefficients()
        {
            ConsoleIO.PrintLine("Input polynomial coefficients as integers separated by space "
                + $"({MIN_COEFFICIENT}-{MAX_COEFFICIENT}), ");

            if (_innerTestNumber == 1)
            {
                ConsoleIO.PrintLine("or enter any other key to use a sequence " +
                    $"of the default length {_polynomialCoefficients.Length}:");
            }
            else
            {
                ConsoleIO.PrintLine("or enter any other key to keep the same array:");
            }

            bool isSuccessful = ConsoleIO.ReadIntegersArray(" ", MIN_COEFFICIENT, MAX_COEFFICIENT, out int[] array);
            if (isSuccessful) 
            {
                _polynomialCoefficients = array;
            }

            string equation = DisplayPolynomialEquation(_polynomialCoefficients);

            ConsoleIO.EmptyLine();
            ConsoleIO.PrintLine("Equation to sort is:");
            ConsoleIO.PrintLine(equation);
            ConsoleIO.EmptyLine();
            return _polynomialCoefficients;
        }


        private void SetupPolynomialVariable()
        {
            ConsoleIO.PrintLine($"Enter x to calculate the evaluation ({MIN_X}-{MAX_X}), ");
            
            if (_innerTestNumber == 1)
            {
                ConsoleIO.PrintLine("or enter any other key to use the default value of " +
                    $"{_polynomialVariable}:");
            }
            else
            {
                ConsoleIO.PrintLine("or enter any other key to keep the same value:");
            }

            bool readIsSuccessful = ConsoleIO.ReadNumberInLimit(MIN_X, MAX_X, out int polynomialVariable);
            if (readIsSuccessful)
            {
                _polynomialVariable = polynomialVariable;
            }

            ConsoleIO.EmptyLine();
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

            ConsoleIO.EmptyLine();

            return equation;
        }
    }
}
