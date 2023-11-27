using TestTasks.DIYClasses;

namespace TestTasks.SearchTests
{
    internal abstract class ArraySearchingAlgorithm : SearchingAlgorithm
    {
        public abstract string Find(int key, int[] source);

        public abstract string Find(string key, string[] source);
    }
}
