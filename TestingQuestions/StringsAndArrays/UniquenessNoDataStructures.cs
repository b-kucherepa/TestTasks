namespace TestTasks.TestingQuestions.StringsAndArrays
{
    public class UniquenessNoDataStructures : ITestTask
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