using CTCI.DesignPatterns.FactoryPattern;
using CTCI.DesignPatterns.TemplatePattern;
using System;

namespace CTCI
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            CTCIString cTCI = new CTCIString();
            cTCI.AllStrings();

            //CTCITrees cTCITree = new CTCITrees();
            //cTCITree.AllTree();

            //CTCIRecursionDP R = new CTCIRecursionDP();
            //R.AllRecursionDP();

            //CTCIModerate M = new CTCIModerate();
            //M.AllModerate();

            //Design Patterns
            //ClientFactory c = new ClientFactory();
            //c.Calculate();

            //ClientTemplete c = new ClientTemplete();
            //c.Process();

            //CTCIGraphs g = new CTCIGraphs();
            //g.AllGraphs();

            //CTCISortSearch g = new CTCISortSearch();
            //g.AllSortSearch();
        }
    }
}
