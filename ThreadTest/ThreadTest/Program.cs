using System.Threading.Tasks.Dataflow;

namespace ThreadTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Hello world";


            // Normal Thread with method
            Thread NormalThread = new(new ParameterizedThreadStart(Go));
            NormalThread.Start("Hello world -");
            NormalThread.Join();

            // Lambda Thread
            Thread lambdaThread = new(new ParameterizedThreadStart((text) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{(string?)text} - This is a lambda Thread");
                }
            }));
            lambdaThread.Start(text);
            lambdaThread.Join();

            // Lambda 2 thread 
            Thread lambdaThread2 = new(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("This is a lambda Thread 2");
                }
            });
            lambdaThread2.Start();
            lambdaThread2.Join();

            // Lambda 3 (Linq) thread in one line
            Thread lambdaThread3 = new(() => Enumerable.Range(0, 5).ToList().ForEach(i => Console.WriteLine("This is a lambda Thread 3")));
            lambdaThread3.Start();
            lambdaThread3.Join();

            // AnonymousThread
            Thread AnonymousThread = new (delegate (object? text)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{(string?)text} - This is a Anonymous Thread");
                }
            });
            AnonymousThread.Start(text);
            AnonymousThread.Join();
        }

        // Go method
        static void Go(object message)
        {
            string test = (string)message;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{test} from the parameterized thread");
            }
        }   
    }
}
