
class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();

        // Subscribe to events
        sw.OnStarted += HandleStopwatchEvent;
        sw.OnReset += HandleStopwatchEvent;
        sw.OnStopped += HandleStopwatchEvent;

        Console.WriteLine(
@"Stopwatch Controls:
  S - Start
  T - Stop
  R - Reset
  Q - Quit"
        );

        bool isRunning = true;
        while (isRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.S:
                        sw.Start();
                        break;
                    case ConsoleKey.T:
                        sw.Stop();
                        break;
                    case ConsoleKey.R:
                        sw.Reset();
                        break;
                    case ConsoleKey.Q:
                        isRunning = false;
                        Console.WriteLine("Program stopped!");
                        break;
                    default:
                        Console.WriteLine($"Invalid Input ({key.ToString()})! Please try again.");
                        break;
                }
            }
            sw.Tick();
        }
    }

    static void HandleStopwatchEvent(string message)
    {
        Console.WriteLine($"{message}");
    }
}