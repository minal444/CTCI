using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace CTCI.DesignPatterns.Singleton
{
    /*
     * We can use this when we need to ensure only one isntance of the class is created 
     * Shared data , configuration data, caching , logging , printer setting . DB connection
     * We need to use sealed keyword otherwise nested class can inherite the class and it will violate the single instance creation
     * 
     * Eager loading is thred safe as instance of the class is created right before the need and no need to check for the lock and just reaturn the object. It is expensive and not optimal to use as some object creation is heavy or not as frequqntly used.
     * Lazy loading is the best but not thread safe. in C# 4.0 there is Lazy keyworkd introduced which is thredsafe 
     *  
     *  Static and Singleton Diff
     *  1. Static is language feature while Singleton is DP
     *  2. we can not instatiate the static but can have one imstamce of Singleton 
     *  3. Singleton can be loaded lazily while static will initialized when it is first loaded for the first time
     *  4. It is not possible to pass the static class as a method parameter whereas we can pass the singleton instance as a method parameter in C#.
     *  5. We can use inheritance with Singleton but not with static
     *  6. We can clone the Singleton class object whereas it is not possible to clone a static class. 
     *  7. We cannot implement the Dependency Injection design pattern using Static class because the static class is not interface driven.
     * 
     */
    public sealed class Singleton
    {
        private static Singleton instance = null;
        //private static readonly Lazy<Singleton> instanceLock = new Lazy<Singleton>(() => new Singleton()); //Lazy loading of C#
        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }

        private static int counter = 0;
        private static readonly object lockObj = new Object(); //added for multi-threded environment 
        
        //No thread safe singleton DP
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)//double check locking to make it work faster as lock will slow down the execution
                {
                    lock (lockObj) //added lock so that it will work in multi-threaded environment . If instance is not created then only we synchronize the method 
                    {
                        if (instance == null)
                            instance = new Singleton();
                    }
                }
                return instance;


                //return instanceLock.Value //Lazy loading of the value
            }
        }




        //thread safe singleton DP
        //The Thread-Safety Singleton Design pattern implementation using Double-Check Locking.
    }

    public class ClientSingleton
    {
        
        public void SingletonClient()
        {
            //No thread safe
            Singleton singleton = Singleton.GetInstance;
            Singleton singleton2 = Singleton.GetInstance;


            //Thread safe implementation 
            //Parallel.Invoke(
            //    () => Thread1(),
            //    () => Thread2()
            //    );


        }

        private void Thread1()
        {
            Singleton singleton = Singleton.GetInstance;
            Console.WriteLine("From Thread 1");
        }

        private void Thread2()
        {
            Singleton singleton = Singleton.GetInstance;
            Console.WriteLine("From Thread 2");
        }

    }


    //Real Time Example 1:
    //Step 1: 
    public interface ILog
    {
        void LogException(string message);
    }

    public sealed class Log : ILog
    {
        private Log()
        {
        }
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        public static Log GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }

    public class EmployeeController
    {
        private ILog _ILog;
        //private EmployeeDBContext db = new EmployeeDBContext();
        public EmployeeController()
        {
            _ILog = Log.GetInstance;
        }
       /* protected override void OnException(ExceptionContext filterContext)
        {
            _ILog.LogException(filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
           // this.View("Error").ExecuteResult(this.ControllerContext);
        }
       */
    }


    //Real Time Example 2:
    //Caching 
    //Step 1:
    public interface IGlobalCaching
    {
        public void AddItem(string key, object value);
        public void RemoveItem(string key);
        public object GetItem(string key);
    }
    //Step 2:
    public sealed class GlobalCaching : IGlobalCaching
    {
        private static  GlobalCaching instance = null;
        private static readonly Object lockObj = new Object();
        protected MemoryCache cache = new MemoryCache("MyCache"); 
        private GlobalCaching()
        {

        }

        public static GlobalCaching GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new GlobalCaching();
                        }
                       
                    }
                }
                return instance;
            }

        }
        public void AddItem(string key, object value)
        {
            lock(lockObj)
            {
                cache.Add(key, value,System.DateTime.Now.AddDays(4));
            }
        }

        public object GetItem(string key)
        {
            lock(lockObj)
            {
                return cache[key];
            }
            
        }

        public void RemoveItem(string key)
        {
            lock (lockObj)
            {
                if(cache[key]!=null)
                    cache.Remove(key);
            }
        }
    }

    //Step 3:
    public class CacheClient
    {
        private IGlobalCaching _IGlobalCache;
        //private EmployeeDBContext db = new EmployeeDBContext();
        public CacheClient()
        {
            _IGlobalCache = GlobalCaching.GetInstance;
        }
        public  void AddToCache()
        {
            GlobalCaching.GetInstance.AddItem("ConnectionDB", "TestDB");
            GlobalCaching.GetInstance.AddItem("TimeOut", "50");

            Console.WriteLine(GlobalCaching.GetInstance.GetItem("ConnectionDB"));
            // this.View("Error").ExecuteResult(this.ControllerContext);
        }

    }
}
