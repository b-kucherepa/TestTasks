﻿using TestTasks.DIYClasses;

namespace TestTasks.SearchTests
{
    internal abstract class TreeSortingAlgorithm
    {
        public abstract BinaryNode<DummyData>? Find(int key, BinaryTree<DummyData> tree, out string searchPath);
    }
}
