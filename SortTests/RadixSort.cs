using System.ComponentModel;

namespace TestTasks.SortTests
{
    /// <summary>
    /// This non-comparative algorithm moves from the lowest number (or element key) position to 
    /// the highest one. This way, all elements have their digits at the lowest positions sorted 
    /// on every stage, and when the elements are sorted by the highest position digits, 
    /// they are already sorted by the rest of the digits too.
    /// Since the algorithm doesn't need to exactly compare numbers, it splits them in groups
    /// according to the digit at every step, and combines them again in the proper order
    /// on every step.
    /// The current implementation uses the radix (base) of two, it splits them into two groups 
    /// according to their binary digits on each step. It uses the first half of 
    /// the initial array to store elements with "zeros" in those positions, and 
    /// an additional stack to store the "ones" groups, which are re-inserted at 
    /// the second half of the initial array once the grouping is complete
    /// </summary>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(W * N), where N is the number of keys, and W is the key length.
    /// Average asymptotic complexity is
    /// ϴ(W * N).
    /// Best-case asymptotic complexity is 
    /// Ω(W * N).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(W + N).
    /// </remarks>
    internal class RadixSort : SortAlgorithm
    {
        public override int[] SortArray(int[] array)
        { 
            //iterates through every binary position of every number in array
            for (int shift = 0; shift < 32; shift++)
            {
                //calculates a mask to compare only necessary digits in each binary position:
                int mask = 0b_1 << shift;

                //an index for rewriting the first half of the array to store elements
                //with "zeroes" on their current binary position:
                int zeroIndex = 0;

                //the stack to store "ones" from the current binary position:
                Stack <int> onesStack = new();

                //iterates through the array and...
                for (int sortedIndex = 0; sortedIndex < array.Length; sortedIndex++)
                {
                    //...checks if the digit left by applying the mask goes to the "zeroes" group
                    //(to be stored into the first half of the initial array)...
                    if ((array[sortedIndex] & mask) == 0)
                    {
                        array[zeroIndex] = array[sortedIndex];
                        zeroIndex++;
                    }
                    //or goes to "ones" group (to be stored into separate stack).
                    else
                    {
                        onesStack.Push(array[sortedIndex]);
                    }
                }

                //pops "ones" to add them back at the second half of the initial array:
                for (int popIndex = array.Length - 1; onesStack.Any(); popIndex--)
                {
                    array[popIndex] = onesStack.Pop();
                }
            }

            return array;
        }
    }
}
