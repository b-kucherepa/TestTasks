namespace TestTasks.TestingQuestions.StringsAndArrays
{
    public class UniquenessWithHash : TestTask
    {
        public override void Begin()
        {
            Console.WriteLine("\nEnter a line to check:\n");

            string inputString = Console.ReadLine() ?? "";

            if (CheckCharUniqueness(inputString))
            {
                Console.WriteLine("\nThe string has no duplicates!\n");
            }
            else
            {
                Console.WriteLine("\nSome characters in the string are repetitive...\n");
            }
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