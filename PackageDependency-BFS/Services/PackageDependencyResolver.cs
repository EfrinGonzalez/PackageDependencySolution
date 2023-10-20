
namespace PackageDependency_DFS
{
    
    public class PackageDependencyResolver
    {
        static Graph g = new Graph(0);
        static Dictionary<string, int> packageMap = new Dictionary<string, int>();        
        static int packageCounter = 0;

        public Graph ParseFileReturnGraph(String path) 
        {  
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int lineNumber = 0;
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        lineNumber++;                      
                        ProcessLine(line, lineNumber);   
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.ToString());
            }
            return g; 
        }
  
        static void ProcessLine(string line, int lineNumber)
        {   
            // Skip lines with single integers
            if (line.All(char.IsDigit))
            {              
                return ;
            }
           
            string[] values = line.Split(',');           
            Console.WriteLine($"Line {lineNumber}: {string.Join(", ", values)}");

            // Assemble strings like "A,1" as "A1" and assign each unique combination a number
            List<int> tempintValues = new List<int>();
            int firstValue = 0;
            for (int i = 0; i < values.Length; i += 2)
            {
                string packageName = values[i];
                string version = values[i + 1];
                string packageVersion = packageName + version;            

                if (i == 0) firstValue = packageCounter;
                if (!packageMap.ContainsKey(packageVersion))
                {                    
                    packageMap[packageVersion] = packageCounter++; 
                }
              
                Console.WriteLine($"Package: {packageVersion}, Number: {packageMap[packageVersion]}");
                tempintValues.Add(packageMap[packageVersion]);
            }

            // Traverse the list in reverse order. Here we will build the graph as such.
            for (int i = tempintValues.Count - 1; i >= 0; i--)
            { 
                if (i > 0) {
                    g.ResizeGraph(packageCounter);
                    int currentValue = tempintValues[i];
                    int toValue = tempintValues[i - 1];
                     g.AddEdge(currentValue, toValue);
                    Console.WriteLine($"Edge created: {currentValue} -> {toValue}");
                } 
            }
        }
    }
}
