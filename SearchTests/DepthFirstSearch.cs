using TestTasks.DIYClasses;

namespace TestTasks.SearchTests
{
    /// <summary>
    /// This algorithm checks every branch from top to down consequentially to 
    /// find out int a node containing the required value.
    /// The only difference with breadth-first search is: it uses a stack instead of a queue.
    /// The current implementation searches in a binary tree, though it can be modified to be used with any graph.
    /// </summary>
    /// <remarks>
    /// <remarks>
    /// Worst-case asymptotic complexity (order of the execution time) is 
    /// O(|V| + |E|), where V is the number of vertices and E is the number of edges.
    /// Average asymptotic complexity is
    /// ϴ(N * log2(N)).
    /// Best-case asymptotic complexity is 
    /// Ω(1).
    /// Worst-case space complexity (order of the memory usage) is 
    /// O(|V|), where V is the number of vertices.
    /// </remarks>
    internal class DepthFirstSearch : TreeSortingAlgorithm
    {
        public override BinaryNode<DummyData>? Find(int key, BinaryTree<DummyData> tree, out string searchPath)
        {
            //for educational purpose:
            searchPath = "";

            //a list of already visited nodes
            HashSet<BinaryNode<DummyData>> visitedNodes = new();

            //a prospectedNodes of nodes to visit in the future:
            Stack<BinaryNode<DummyData>> prospectedNodes = new();

            //the first one to visit it root obviously:
            prospectedNodes.Push(tree.Root);

            //while prospectedNodes isn't empty:
            while (prospectedNodes.Any())
            {
                //takes the first node in the queue:
                BinaryNode<DummyData> node = prospectedNodes.Pop();

                searchPath += " -> " + node.Data.Id;

                //if the node contains desired key in its data, that's it:
                if (node.Data.Id == key)
                {
                    return node;
                }

                //it checked the node, it can be counted visited now. But before the loop iteration ends...
                visitedNodes.Add(node);

                //...it checks if there are any unchecked children the current node has, and
                //adds them into the queue to check them and their own children later.
                //NB! Left and right child checks are switched to provide the left-to-right search direction:
                bool rightChildExists = !(node.RightChild is null || visitedNodes.Contains(node.RightChild));
                if (rightChildExists)
                {
                    prospectedNodes.Push(node.RightChild);
                }

                bool leftChildExists = !(node.LeftChild is null || visitedNodes.Contains(node.LeftChild));
                if (leftChildExists)
                {
                    prospectedNodes.Push(node.LeftChild);
                }
            }

            //if no nodes were found during the WHILE loop, returns null:
            return null;
        }
    }
}