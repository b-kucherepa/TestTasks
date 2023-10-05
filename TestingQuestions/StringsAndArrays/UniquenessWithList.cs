using TestTasks;

namespace TestTasks.TestingQuestions.StringsAndArrays
{
    public class UniquenessWithHash : TestTask
    {
        public override void Begin()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a line to check:");
            Console.WriteLine();

            string inputString = Console.ReadLine() ?? "";

            if (CheckCharUniqueness(inputString))
            {
                Console.WriteLine("The string has no duplicates!");
            }
            else
            {
                Console.WriteLine("Some characters in the string are repetitive...");
            }

            Console.WriteLine();
        }

        private bool CheckCharUniqueness(string s)
        {
            var charOccurrences = new HashSet<char>();

            foreach (char c in s)
            {
                if (charOccurrences.Contains(c))
                {
                    return false;
                }
                else
                {
                    charOccurrences.Add(c);
                }
            }
            return true;
        }

    }
}