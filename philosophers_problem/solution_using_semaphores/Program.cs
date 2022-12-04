using System;
using System.Threading;
using System.Xml.Linq;

namespace Dining_Philosophers
{
    class Dining_Philosophers
    {
        //semaphore class lets you set a limit on the number of threads that have access to a critical section
        //semaphore class is used to control access to a pool of resources

        //Initializes semaphore object with two parameters (InitialCount, MaximumCount)
        public static Semaphore semaphore = new Semaphore(2, 3);
        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                //creates and initializes the thread
                Thread threadObject = new Thread(eat)
                {
                    Name = "philosopher " + i
                };
                //calls thread to start process
                threadObject.Start();
            }
            Console.ReadKey();
        }
        static void eat()
        {
            //Fetches the name of the current thread using Name property
            Console.WriteLine(Thread.CurrentThread.Name + " is thinking");
            try
            {
                //Blocks the current thread until the current WaitHandle receives a signal.   
                semaphore.WaitOne();
                //Decrease the Initial Count Variable by 1
                Console.WriteLine(Thread.CurrentThread.Name + " is eating");
                //Thread.Sleep() temporarily suspends the current execution of the thread for specified millisecond
                //so that other threads can get the chance to start the execution
                Thread.Sleep(100);
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