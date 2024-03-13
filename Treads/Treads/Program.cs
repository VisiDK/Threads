namespace Treads
{
    class Program

    {

        private char _sharedChar;

        private const int SIMULATE_WORK = 100;

        private static object _lock = new object();

        static void Main(string[] args)

        {

            Program p = new Program();

            p.Run();

        }

        public void Run()

        {

            Thread tA = new Thread(WriteA);

            Thread tB = new Thread(WriteB);

            tA.Name = "Thread A";

            tB.Name = "Thread B";

            tA.Start();

            tB.Start();

            tA.Join();

            tB.Join();

            Console.Write("\nPress a key ....");

            Console.ReadKey();

        }

        private void WriteA()

        {

            for (int i = 0; i < 10; i++)

            {
                lock ( _lock ) {
                    _sharedChar = 'A';

                    Thread.Sleep(SIMULATE_WORK);

                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");

                    Thread.Yield();
                }

            }

        }

        private void WriteB()

        {

            for (int i = 0; i < 10; i++)

            {
                lock (_lock)
                {

                    _sharedChar = 'B';

                    Thread.Sleep(SIMULATE_WORK);

                    Console.WriteLine($"{Thread.CurrentThread.Name} : {_sharedChar}");

                    Thread.Yield();

                }

            }

        }

    }
}
