namespace TestTasks.TestingQuestions.StringsAndArrays
{
    public class UniquenessNoDataStructures : ITestTask
    {
        public void Begin()
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
            for (int ch = 0; ch < s.Length; ch++)
            {
                for (int comp = ch + 1; comp < s.Length; comp++)
                {
                    if (s[comp] == s[ch])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}