namespace TestTasks.TestingQuestions.StringsAndArrays
{
    public class UniquenessNoDataStructures : TestTask
    {
        public override void Begin()
        {
            Console.WriteLine();
            Console.WriteLine("Enter a line to check:");
            Console.WriteLine();

            string inputString = Console.ReadLine() ?? "";
            Console.WriteLine();

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