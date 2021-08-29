using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetFileIO
{
    class ThreadDemo
    {
        static void Main(string[] args)
        {
            //single thread
            Thread thr = new Thread(Mythread);
            thr.Start();

            //threadpool
            ThreadPool.QueueUserWorkItem(ThreadpoolThread);
            Console.WriteLine("Main thread does some work, then sleeps.");
            Thread.Sleep(500);

            Console.WriteLine("Main thread exits.");

            var source = Enumerable.Range(1, 10000);

            // Opt in to PLINQ with AsParallel.
            var evenNums = from num in source.AsParallel()
                           where num % 2 == 0
                           select num;
            Console.WriteLine("{0} even numbers out of {1} total",
                              evenNums.Count(), source.Count());

            //TPL
            Task mytask = new Task(TPLTask);
            mytask.Start();
            mytask.Wait();

            Console.WriteLine("Main Thread Ends!!");

            Console.ReadLine();



        }

        static void Mythread()
        {
            for (int c = 0; c <= 3; c++)
            {

                Console.WriteLine("mythread is in progress!!");
                Thread.Sleep(1000);
            }
            Console.WriteLine("mythread ends!!");
        }

        static void ThreadpoolThread(Object stateInfo)
        {
            Console.WriteLine("Threedpool thread");
            Thread.Sleep(1000);
        }

        static void TPLTask()
        {
            Console.WriteLine("TPL TASK");
            Task.Delay(5000);
        }

    }
}
