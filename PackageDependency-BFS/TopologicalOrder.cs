using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PackageDependency_DFS
{
    public class TopologicalOrder
    {

        // Driver code
        public static void Main(string[] args)
        {
            /*PackageDependencyResolver parsea = new PackageDependencyResolver();
            string relativePath = "../../../input-files"; // replace with your relative path
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
            string file = fullPath + "input000.txt";
            Graph b = parsea.ParseFileReturnGraph(file);*/
            

           /*
            * string relativePath = "../../../input-files"; // replace with your relative path
           string fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

           string[] files = Directory.GetFiles(fullPath);
           FileParser parse = new FileParser();
           foreach (string filePath in files)
           {
               Console.WriteLine();
               Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
               string fileName = Path.GetFileName(filePath);
               Console.WriteLine(fileName);
               Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxx");
               Graph d = parse.ParseFile(filePath);
               Console.WriteLine(d.ToString());

               d.TopologicalSort();

           }
           */

           /* 
            References:
            Youtube video of topological sorting:  https://www.youtube.com/watch?v=Q9PIxaNGnig
            Create a graph given in the above diagram: https://www.geeksforgeeks.org/topological-sorting/
            This program uses the algorithm presented here in geeksforgeeks 
            and adapted to the problem of package dependency proposed by Configit as a technical test.
           */

           PackageDependencyResolver parse = new PackageDependencyResolver();
           Graph d =  parse.ParseFileReturnGraph("C:\\Users\\efrin\\OneDrive\\Documents\\Visual Studio 2022\\Code Snippets\\Visual C#\\My Code Snippets\\Algorithms\\PackageDependency-BFS\\input001.txt");
            Console.WriteLine(d.ToString());
            
            d.TopologicalSort();
            


            /*
            Graph g = new Graph(6);
            g.AddEdge(5, 2);
            g.AddEdge(5, 0);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);

            Console.WriteLine("Following is a Topological "
                              + "sort of the given graph");
            
            // Function Call
            g.TopologicalSort();*/


           
        }

    }


}
