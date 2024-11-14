using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingDemo
{
    internal class Program
    {

        static async Task DoThisWorkAsync()
        {
            await Task.Delay(5000);
            for (int i = 100; i < 150; i++)
            {
                Console.WriteLine(i);
            }

        }

        static async Task<string> ReadAllTextAsync(object o)
        {
            string p = (string)o;
            FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read);
            string content=null;
            StreamReader sr = null;
            using ( sr = new StreamReader(p))
            {
                 content=await sr.ReadToEndAsync();
                         
            }
            sr.Close();
            sr.Dispose();
            fs.Flush(); 
           fs.Close();
            fs.Dispose();
        return  content;
        }

        static List<Products> plist = new List<Products>()
        {
            new Products{Productid=1,Name="tea",Price=10 },
            new Products{Productid=2,Name="tea1",Price=10 },
            new Products{Productid=3,Name="tea2",Price=20 },
            new Products{Productid=4,Name="tea3",Price=30 },
            new Products{Productid=5,Name="tea4",Price=40 },
            new Products{Productid=6,Name="tea5",Price=50 },
            new Products{Productid=7,Name="tea6",Price=60 },

        };

        static async Task<Products> FindProduct(object id)
        {
            int i = (int)id;
        Products found=  plist.Find(p1=>p1.Productid==i);
        return found;
        
        }



        static async Task Main()
        {
            //Console.WriteLine("starting async method");
            //Task t = DoThisWorkAsync();
            //Console.WriteLine("Continuing Execution of main method");
            //await t;
            //Console.WriteLine("completed async execution");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("enter product to find");
            int id=Convert.ToInt32(Console.ReadLine());
            Products productfound=await FindProduct(id);

            //     string path = "example.txt";
            //     Console.WriteLine("Now I will start Reading the file.... ");
            ////Task t=ReadAllTextAsync(path);
            //     string filecontent= await Program.ReadAllTextAsync(path);
            //     Console.WriteLine("The contents of the file are: ");
            //     Console.WriteLine(filecontent);
            Console.WriteLine(productfound.Productid);
            Console.WriteLine(productfound.Name);
            Console.WriteLine(productfound.Price);


            Console.ReadLine();

        }


        //internal void FirstMethod()
        //{
        //    Console.WriteLine("Hello");
        //}

        //internal void SecondMethod()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("Second Thread " + i);
        //    }

        //}

        //public  void ThirdMethod(object j)
        //{
        //  //  int cnt = (int)j;
        //    for (int i = 0; i < 20; i++)
        //    {
        //        Console.WriteLine("Third Thread " + i);
        //    }
        //}

        //static void WorkOnThis(object s)
        //{

        //    Console.WriteLine("Starting the work....");
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int ans = 10 * i;
        //        Console.WriteLine($"10*{i}={ans}");
        //        Thread.Sleep(1000);


        //    }
        //    Console.WriteLine("completed the work....");
        //}


        //static void DoWork()
        //{
        //    Thread.Sleep(5000);
        //    for (int i = 100; i < 150; i++)
        //    {
        //        Console.WriteLine(i);
        //    }

        //}

        //static void Main(string[] args)
        //{
        //    //threaddemo();
        //    //ThreadPool();
        //    Console.WriteLine("Starting sync method.....");
        //    DoWork();
        //    Console.WriteLine("Completed sync method");


        //    Console.Read();
        //}




        //private static void ThreadPool()
        //{
        //    System.Threading.ThreadPool.QueueUserWorkItem(WorkOnThis);
        //    Console.WriteLine("Now Working on the main theread");
        //    Console.WriteLine("Now Working on the main theread");
        //    Console.WriteLine("Now Working on the main theread");
        //    Console.WriteLine("Now Working on the main theread");
        //    Program p = new Program();
        //    System.Threading.ThreadPool.QueueUserWorkItem(p.ThirdMethod);
        //}

        //private static void threaddemo()
        //{
        //    Program p = new Program();
        //    ThreadStart ts = new ThreadStart(p.FirstMethod);
        //    Thread t1 = new Thread(ts);
        //    t1.Start();
        //    Console.WriteLine("---------------");
        //    Thread t2 = new Thread(new ThreadStart(p.SecondMethod));
        //    t2.Start();

        //    Console.WriteLine("-------------------");
        //    ParameterizedThreadStart ts1 = new ParameterizedThreadStart(p.ThirdMethod);
        //    Thread t3 = new Thread(ts1);
        //    t3.Start(5);
        //}



    }
}
