using System;
using System.Threading;

namespace dining_philosophers
{
    class Dining_Philosophers
    {
        //Initializes semaphore object with two parameters (InitialCount, MaximumCount)
        public static Semaphore semaphore = new Semaphore(2, 3);
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread threadObject = new Thread(eat)
                {
                    Name = "philosopher " + i
                };
                threadObject.Start();
            }
            Console.ReadKey();
        }
        static void eat()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " is thinking");
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.   
                semaphore.WaitOne();
                //Decrease the Initial Count Variable by 1
                Console.WriteLine(Thread.CurrentThread.Name + " is eating");
                Thread.Sleep(1000);
                Console.WriteLine(Thread.CurrentThread.Name + " stopped eating");
            }
            finally
            {
                //Release() method to release semaphore  
                //Increase the Initial Count Variable by 1
                semaphore.Release();
            }
        }
    }
}