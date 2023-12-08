namespace TestTasks.TestingQuestions.StringsAndArrays
{
    public class UniquenessWithHash : ITestTask
    {
        public void Begin()
        {
            ConsoleIO.PrintLine("Enter a line to check:");

            string inputString = ConsoleIO.Read() ?? "";
            ConsoleIO.EmptyLine();

            if (CheckCharUniqueness(inputString))
            {
                ConsoleIO.PrintLine("The string has no duplicates!");
            }
            else
            {
                ConsoleIO.PrintLine("Some characters in the string are repetitive...");
            }
            ConsoleIO.EmptyLine();
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