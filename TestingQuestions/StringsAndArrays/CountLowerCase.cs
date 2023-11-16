namespace TestTasks.TestingQuestions.StringsAndArrays
{
    internal class CountLowerCase : ITestTask
    {
        public void Begin()
        {
            Console.WriteLine("\nEnter a line to count lower case letters in it:\n");

            string inputString = Console.ReadLine() ?? "";

            Console.WriteLine("\nThe string contains " + GetLowerCaseCount(inputString)
                + " lower case letter(s).\n");
        }

        private int GetLowerCaseCount(string s)
        {
            int count = 0; //1
            foreach (char c in s) //sugarcoated FOR loop: (1 ; n+1 ; n)
            {
                if (char.IsLower(c)) //n
                {
                    count++; //from 0 to n
                }
            }
            return count; //1
            //θmin(1 + 1 + n+1 + n + n + 0 + 1) = θ(3n+4) => Ω(n)
            //θmax(1 + 1 + n+1 + n + n + n + 1) = θ(4n+4) => O(n)
        }
    }
}
