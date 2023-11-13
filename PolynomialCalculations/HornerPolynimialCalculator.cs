namespace TestTasks.PolynomialCalculations
{
    /// <summary>
    /// The algorithm to calculate polynomial equation with specified coefficients and known x,
    /// based on Horner's rule, in which a polynomial is written in nested form:
    /// a[0] + a[1]*x + a[2]*x^2 + a[3]*x^2 + ... + a[n]*x^n = 
    /// a[0] + x * (a[1] + x * (a[2] + x * (a[3] + ... + x(a[n-1] + x*a[n])...))).
    /// </summary>
    /// <remarks>
    /// Multiplications total:
    /// N, where N is the count of polynomials.
    /// Additions total:
    /// N, where N is the count of polynomials.
    /// </remarks>
    internal class HornerPolynimialCalculator : PolynimialCalculator
    {
        internal override long Solve(int x, int[] coefficient)
        {
            long result = 0;
            for (int i = coefficient.Length-1; i >= 0; i--)
            {
                result *= x;
                result = result + coefficient[i];
            }
            return result;
        }
    }
}
