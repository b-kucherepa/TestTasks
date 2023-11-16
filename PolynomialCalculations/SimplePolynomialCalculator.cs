namespace TestTasks.PolynomialCalculations
{
    /// <summary>
    /// The naive algorithm to calculate polynomial equation with specified coefficients and known x.
    /// </summary>
    /// <remarks>
    /// Multiplications total:
    /// 2N-1, where N is the count of polynomials.
    /// Additions total:
    /// N, where N is the count of polynomials.
    /// </remarks>
    internal class SimplePolynomialCalculator : PolynimialCalculator
    {
        public override long Solve(int x, int[] coefficient)
        {
            long result = coefficient[0];
            int powerOfX = 1;
            for (int i = 1; i < coefficient.Length; i++)
            {
                powerOfX = powerOfX * x;
                result = result + coefficient[i] * powerOfX;
            }
            return result;
        }
    }
}
