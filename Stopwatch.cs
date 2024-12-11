public delegate void StopwatchEventHandler(string message);

public class Stopwatch
{
    private bool isRunning;
    private int timeElapsed;
    public int TimeElapsed
    {
        get { return timeElapsed; }
    }

    // Events
    public event StopwatchEventHandler? OnStarted;
    public event StopwatchEventHandler? OnStopped;
    public event StopwatchEventHandler? OnReset;

    public Stopwatch()
    {
        timeElapsed = 0;
        isRunning = false;
    }

    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            OnStopped?.Invoke("\nStopwatch Stopped!");
        }
    }

    public void Reset()
    {
        OnReset?.Invoke($"\nStopwatch Reset at {timeElapsed} second(s)");
        timeElapsed = 0;
    }

    public void Tick()
    {
        if (isRunning)
        {
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write($"  Time: {timeElapsed} second(s)");
            timeElapsed++;
        }
    }

}