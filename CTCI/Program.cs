using CTCI.DesignPatterns.FactoryPattern;
using CTCI.DesignPatterns.Singleton;
using CTCI.DesignPatterns.Prototype;
using CTCI.DesignPatterns.SOLID;
using CTCI.DesignPatterns.TemplatePattern;
using CTCI.DesignPatterns.Adapter;
using CTCI.DesignPatterns.FacadePattern;
using System;
using CTCI.DesignPatterns.FactoryMethod;
using CTCI.DesignPatterns.Builder;
using CTCI.DesignPatterns.DependancyInjection;
using CTCI.DesignPatterns.Observer;

namespace CTCI
{
    class Program
    {
        public static void Main(string[] args)
        {
            ////Console.WriteLine("Hello World!");
            //CTCIString cTCI = new CTCIString();
            //cTCI.AllStrings();

            //CTCITrees cTCITree = new CTCITrees();
            //cTCITree.AllTree();

            // CTCIRecursionDP R = new CTCIRecursionDP();
            // R.AllRecursionDP();

            //CTCIModerate M = new CTCIModerate();
            //M.AllModerate();

            //Design Patterns
            //ClientFactory c = new ClientFactory();
            //c.Calculate();

            //ClientTemplete c = new ClientTemplete();
            //c.Process();

            CTCIGraphs g = new CTCIGraphs();
            g.AllGraphs();

            //CTCISortSearch g = new CTCISortSearch();
            //g.AllSortSearch();


            //CTCIStacksQueue sq = new CTCIStacksQueue();
            //sq.AllStack();


            /*******************SOLID*****************/
            //SingleResponsibility sr = new SingleResponsibility();
            //sr.Purchase();

            //OpenClose oc = new OpenClose();
            //oc.GetInvoiceDiscount();

            //LiskovSubstitution ls = new LiskovSubstitution();
            //ls.SubmitApp();

            //InterfaceSegration s = new InterfaceSegration();
            //s.GetProfile();

            //DependancyInversionExample2 di = new DependancyInversionExample2();
            //di.Notification();

            /***************************************************/
            //Design Pattern
            ClientSingleton c = new ClientSingleton();
            c.SingletonClient();

            CacheClient cache = new CacheClient();
            cache.AddToCache();


            Prototype p = new Prototype();
            p.PrototypeDP();

            FactoryMethodDP fm = new FactoryMethodDP();
            fm.FactoryMethod();

            BuilderDP b = new BuilderDP();
            b.BuildCar();

            AdapterDP a = new AdapterDP();
            a.GetClientProfile();

            Facade f = new Facade();
            f.ApplicationSumission();

            DependancyInjectionDP d = new DependancyInjectionDP();
            d.GetEmployee();

            Observer_PubSub ps = new Observer_PubSub();
            ps.Observer();
        }
    }
}
