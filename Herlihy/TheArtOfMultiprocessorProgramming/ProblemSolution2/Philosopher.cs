namespace ProblemSolution2;

public class Philosopher
{
    public readonly int Id;
    private readonly Random NumberGenerator;
    private readonly Chopstick RightChopstick;
    private readonly Chopstick LeftChopstick;
    private volatile bool _rightFlag;
    private volatile bool _leftFlag;
    public bool RightFlag => _rightFlag;
    public bool LeftFlag => _leftFlag;
    public Philosopher RightNeighbor { get; private set; }
    public Philosopher LeftNeighbor { get; private set; } 
    public Philosopher(int id, Chopstick leftChopstick, 
        Chopstick rightChopstick, Random numberGenerator)
    {
        Id = id;
        RightChopstick = rightChopstick;
        LeftChopstick = leftChopstick;
        NumberGenerator = numberGenerator;
    }
    
    public void Think(Philosopher rightNeighbor, Philosopher leftNeighbor)
    {
        RightNeighbor =  rightNeighbor;
        LeftNeighbor =  leftNeighbor;
        
        var thread = new Thread(() =>
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                // thinking...
            
                // getting hungry
                if (NumberGenerator.Next(2) == 0)
                {
                    _rightFlag = true;

                    if (RightNeighbor.LeftFlag)
                    {
                        Console.WriteLine(
                            $"P{Id} waits for P{RightNeighbor.Id}");
                        
                        _rightFlag = false;
                        while (RightNeighbor.LeftFlag)
                            ;
                        _rightFlag = true;
                    }
                    
                    _leftFlag = true;
                    
                    if (!LeftNeighbor.RightFlag)
                    {
                        Thread.Sleep(10);
                        RightChopstick.IsHeld = true;
                        LeftChopstick.IsHeld = true;
                        Console.WriteLine($"P{Id} is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine($"P{Id} is eating 2");
                        Console.WriteLine($"P{Id} is eating 3");
                        RightChopstick.IsHeld = false;
                        LeftChopstick.IsHeld = false;
                        _rightFlag = false;
                        _leftFlag = false;
                    }
                    else
                    {
                        _rightFlag = false;
                        _leftFlag = false;
                    }
                }
            }
        });
        
        thread.Start();
    }
}