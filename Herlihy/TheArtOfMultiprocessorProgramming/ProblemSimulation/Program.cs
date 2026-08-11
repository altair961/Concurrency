namespace Ex1DiningPhilosophers;

class Program
{
    static void Main(string[] args)
    {
        // shared by pholosopher1 and pholosopher2 
        var chopstick1 = new Chopstick();
        
        // shared by pholosopher2 and pholosopher3
        var chopstick2 = new Chopstick();
        
        // shared by pholosopher3 and pholosopher4
        var chopstick3 = new Chopstick();
        
        // shared by pholosopher4 and pholosopher5
        var chopstick4 = new Chopstick();
        
        // shared by pholosopher5 and pholosopher1
        var chopstick5 = new  Chopstick();
        
        var philosopher1 = new Thread(() =>
        {
            var random = new Random();

            for (int i = 0; i < 1_000_000; i++)
            {
                if (random.Next(2) == 0)
                {
                    if (!chopstick5.IsHeld && !chopstick1.IsHeld)
                    {
                        Thread.Sleep(10);
                        chopstick5.IsHeld = true;
                        chopstick1.IsHeld = true;
                        Console.WriteLine("P1 is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine("P1 is eating 2");
                        Console.WriteLine("P1 is eating 3");
                        chopstick5.IsHeld = false;
                        chopstick1.IsHeld = false;
                    }
                }
            }
        });
        
        var philosopher2 = new Thread(() =>
        {
            var random = new Random();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (random.Next(2) == 0)
                {
                    if (!chopstick1.IsHeld && !chopstick2.IsHeld)
                    {
                        Thread.Sleep(10);
                        chopstick1.IsHeld = true;
                        chopstick2.IsHeld = true;
                        Console.WriteLine("P2 is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine("P2 is eating 2");
                        Console.WriteLine("P2 is eating 3");
                        chopstick1.IsHeld = false;
                        chopstick2.IsHeld = false;
                    }
                }
            }
        });

        var philosopher3 = new Thread(() =>
        {
            var random = new Random();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (random.Next(2) == 0)
                {
                    if (!chopstick2.IsHeld && !chopstick3.IsHeld)
                    {
                        Thread.Sleep(10);
                        chopstick2.IsHeld = true;
                        chopstick3.IsHeld = true;
                        Console.WriteLine("P3 is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine("P3 is eating 2");
                        Console.WriteLine("P3 is eating 3");
                        chopstick2.IsHeld = false;
                        chopstick3.IsHeld = false;
                    }
                }
            }
        });

        var philosopher4 = new Thread(() =>
        {
            var random = new Random();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (random.Next(2) == 0)
                {
                    if (!chopstick3.IsHeld && !chopstick4.IsHeld)
                    {
                        Thread.Sleep(10);
                        chopstick3.IsHeld = true;
                        chopstick4.IsHeld = true;
                        Console.WriteLine("P4 is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine("P4 is eating 2");
                        Console.WriteLine("P4 is eating 3");
                        chopstick3.IsHeld = false;
                        chopstick4.IsHeld = false;
                    }
                }
            }
        });

        var philosopher5 = new Thread(() =>
        {
            Thread.Sleep(10);
            var random = new Random();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (random.Next(2) == 0)
                {
                    if (!chopstick4.IsHeld && !chopstick5.IsHeld)
                    {
                        chopstick4.IsHeld = true;
                        chopstick5.IsHeld = true;
                        Console.WriteLine("P5 is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine("P5 is eating 2");
                        Console.WriteLine("P5 is eating 3");
                        chopstick4.IsHeld = false;
                        chopstick5.IsHeld = false;
                    }
                }
            }
        });
        
        philosopher1.Start();
        philosopher2.Start();
        philosopher3.Start();
        philosopher4.Start();
        philosopher5.Start();
        
        philosopher1.Join();
        philosopher2.Join();
        philosopher3.Join();
        philosopher4.Join();
        philosopher5.Join();
    }
}