using System;
using System.Threading.Tasks;
using System.Threading;

namespace Task_Parallel_Library
{
    class Program
    {
        static void MethodForToken(object arg)
        {
            CancellationToken token = (CancellationToken)arg;
            token.ThrowIfCancellationRequested();

            for (int i = 0; i < 50; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("token ");
                    token.ThrowIfCancellationRequested();

                }
                Thread.Sleep(1000);
            }
            Console.WriteLine("Task is cancelled.");
        }

        static void MethodForAsync(object obj)
        {
            Console.WriteLine($"Method: MethodForAsync.");

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(25);
                Console.Write(obj as string);
            }
        }

        static void MethodForWait()
        {
            Thread.CurrentThread.IsBackground = true; // main thread doesn't wait for the other thread to be finished 

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.Write($"{i} ");
            }
        }

        static void MethodForTask()
        {
            int threadsNumber = Thread.CurrentThread.ManagedThreadId; // number of current thread  

            Console.WriteLine($"Thread's number is {threadsNumber}. Task's ID is {Task.CurrentId}");

            for (int i = 0; i < 10; i++)
            {
                Console.Write("1 ");
            }

            Console.WriteLine(" ");
            Console.WriteLine($"N{threadsNumber} thread is finished");
        }

        static void Main(string[] args)
        {
            int threadsNumber = Thread.CurrentThread.ManagedThreadId; // number of main thread  

            Console.WriteLine($"Thread's number is {threadsNumber}. Task's ID is null.");

            Task task3 = new Task(MethodForWait);
            task3.Start(); // task3 ends when the main thread ends (isBackground = true)


            Action action = new Action(MethodForTask);

            Task task = new Task(action);
            Console.WriteLine($"a) N{Thread.CurrentThread.ManagedThreadId} task is {task.Status}");

            task.Start(); // task starts asynchronously
            Console.WriteLine($"b) N{Thread.CurrentThread.ManagedThreadId} task is {task.Status}");

            //  OR
            // task.RunSynchronously(); // task starts synchronously

            for (int i = 0; i < 10; i++)
            {
                Console.Write("0 ");
            }
            Console.WriteLine($"c) N{Thread.CurrentThread.ManagedThreadId} task is {task.Status}");

            Console.WriteLine(" ");
            Console.WriteLine($"N{threadsNumber} thread is finished");  // main thread finished

            Console.WriteLine($"d) N{Thread.CurrentThread.ManagedThreadId} task is {task.Status}");


            // Creating another task by using TaskFactory class, lambda expression
            Task task5 = Task.Factory.StartNew(new Action(() =>
            {
                for (int i = 0; i < 15; i++)
                {
                    Thread.Sleep(25);
                    Console.WriteLine("TaskFactory");
                }
            }));

            Action<object> actionObj = MethodForAsync;
            Task task4 = new Task(actionObj, "+");
            task4.Start(); // Runing task4

            Thread.Sleep(2000);


            // Task cancellation by CancellationToken
            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;

            Task task123 = new Task(MethodForToken, token);
            task123.Start();

            Thread.Sleep(1000);

            try
            {
                cancellation.Cancel();
                task123.Wait();
            }
            catch (AggregateException e)
            {
                if (task123.IsCanceled)
                {
                    Console.WriteLine("Change");
                }
                Console.WriteLine(e.InnerException.Message);
            }


            Task.WaitAll(task4, task5); // main task thread waits for task3, task4 and task5 threads to be finished

            Console.WriteLine("Main task is finished.");
        }
    }
}
