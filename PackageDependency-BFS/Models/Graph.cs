using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDependency_DFS
{
    public class Graph
    {
        // No. of vertices
        private int NumVertices;

        // Adjacency List as ArrayList
        // of ArrayList's
        private List<List<int>> adj;       

        // Constructor
        public Graph(int v)
        {
            NumVertices = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public void AddEdge(int v, int w) { adj[v].Add(w); }

        // A recursive function used by topologicalSort.
        // In this case we used Depth First Traversal (DFS), which required a temporal stack
        // that is going to printed as the dependency secuence.
        public void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {
            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices
            // adjacent to this vertex
            foreach (var vertex in adj[v])
            {
                if (!visited[vertex])
                    TopologicalSortUtil(vertex, visited, stack);
            }

            // Push current vertex to
            // stack which stores result
            stack.Push(v);
        }

        // The function to do Topological Sort.
        // It uses recursive topologicalSortUtil()
        //The return type is to be able Unit Test test the function. 
        //public void TopologicalSort()
        public Stack<int> TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited
            var visited = new bool[NumVertices];

            // Call the recursive helper function
            // to store Topological Sort starting
            // from all vertices one by one
            for (int i = 0; i < NumVertices; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            // Print contents of stack
            Console.WriteLine("The dependencies have to be installed as follows: ");
            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");
            }
            return stack;

        }
    

        //This function is handling the readjusting the size of the graph.
        public void ResizeGraph(int newNumVertices)
        {
            // If new number of vertices is greater than the current number, add new empty lists
            while (adj.Count < newNumVertices)
            {
                adj.Add(new List<int>());
            }

            // If new number of vertices is less than the current number, remove lists
            while (adj.Count > newNumVertices)
            {
                adj.RemoveAt(adj.Count - 1);
            }

            // Update the number of vertices
            NumVertices = newNumVertices;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("*********************************");
            Console.WriteLine("Matrix of dependencies");
            Console.WriteLine("Vertex {No.} goes to Vertex {No.}");
            for (int i = 0; i < adj.Count; i++)
            {
                sb.Append($"Vertex {i}: ");
                sb.AppendLine(string.Join(", ", adj[i]));
            }

            return sb.ToString();
        }

    }
}
