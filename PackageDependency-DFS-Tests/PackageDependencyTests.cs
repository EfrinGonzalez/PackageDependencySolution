using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageDependency_DFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDependency_DFS_Tests
{
    [TestClass]
    public class PackageDependencyTests
    {

        private PackageDependencyResolver? parse;
        private Graph? graph;

        string inputFilesPath000 = "";

       [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the FileParser instance
           // parse = new FileParser()
                   parse = new PackageDependencyResolver();
           inputFilesPath000 = "C:\\Users\\efrin\\OneDrive\\Documents\\Visual Studio 2022\\Code Snippets\\Visual C#\\My Code Snippets\\Algorithms\\PackageDependency-DFS-Tests\\input-files\\input000.txt";
            //string inputFilesPath000 = "..\\input000.txt";
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Perform any necessary cleanup after each test
        }



        public static IEnumerable<object[]> GetTestFiles()
        {
            // Absolute path to the input-files directory
            //string inputFilesPath = "C:\\Users\\efrin\\OneDrive\\Documents\\Visual Studio 2022\\Code Snippets\\Visual C#\\My Code Snippets\\Algorithms\\PackageDependency-DFS-Tests\\input-files";
            string inputFilesPath = "input000.txt";
            //string inputFilesPath = @"C:\Users\efrin\OneDrive\Documents\Visual Studio 2022\Code Snippets\Visual C#\My Code Snippets\Algorithms\PackageDependency-DFS-Tests\input-files";

            string[] fileNames = Directory.GetFiles(inputFilesPath);

            foreach (string fileName in fileNames)
            {
                Console.WriteLine(fileName);
                yield return new object[] { fileName };
            }
        }

        [TestMethod]
       // [DynamicData(nameof(GetTestFiles), DynamicDataSourceType.Method)]
        [DataRow("input000.txt", new int[] { 1,0})]          
        // Add more DataRow attributes with your specific test cases and expected results
        public void TestTopologicalSort(string fileName, int[] expectedOrder)
    {
           //string filePath = "C:\\Users\\efrin\\OneDrive\\Documents\\Visual Studio 2022\\Code Snippets\\Visual C#\\My Code Snippets\\Algorithms\\PackageDependency-BFS\\input000.txt";
            
            graph = parse.ParseFileReturnGraph(inputFilesPath000);
            
        // Act
        Stack<int> actualOrderStack = graph.TopologicalSort();
        int[] actualOrderArray = actualOrderStack.ToArray();

        // Assert
        CollectionAssert.AreEqual(expectedOrder, actualOrderArray);
    }









    }
}
