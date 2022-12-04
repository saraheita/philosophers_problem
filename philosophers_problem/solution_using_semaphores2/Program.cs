using System;
using System.Threading;

namespace Dining_Philosphers2
{
    class Dining_Philosphers2
    {
        static Semaphore[] Forks = new Semaphore[5];
        static void Main(string[] args)
        {
            //Forks.Length returns the total number of elements in th array
            for (int i = 0; i < Forks.Length; i++)
            {
                Forks[i] = new Semaphore(1, 1);
            }
            //Creating and initializing threads
            Thread ph1 = new Thread(() => { set(0); });
            Thread ph2 = new Thread(() => { set(1); });
            Thread ph3 = new Thread(() => { set(2); });
            Thread ph4 = new Thread(() => { set(3); });
            //ThreadState.Running
            ph1.Start();
            ph2.Start();
            ph3.Start();
            ph4.Start();
        }
        static void set(int ph_num)
        {
            do
            {
                Forks[ph_num].WaitOne();
                Forks[(ph_num + 1) % 4].WaitOne();
                Console.WriteLine("philosopher{0} is eating", ph_num);
                Forks[ph_num].Release();
                //Exits the semaphore
                Forks[(ph_num + 1) % 4].Release();
                Console.WriteLine("philosopher{0} is thinking", ph_num);
                //Suspends the currect thread
                Thread.Sleep(100);
            } while (true);
        }

    }
}