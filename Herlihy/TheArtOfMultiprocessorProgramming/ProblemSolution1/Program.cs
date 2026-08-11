namespace ProblemSolution;
// safety property:
//      mutual exclusion property: no two philosophers hold the same chopstick
// liveness properties:
//      deadlock freedom: Assume that we have a deadlock. It means that P1 waits for C1 which is taken by P2. P2 waits for C2 which is taken by P3. P3 waits for C3 which is taken by P4. P4 waits for C4 which is taken by P5. P5 waits for C5 which is taken by P1. That implies: P1 holds C5 and waits for C1. But according to the source code when P1 has C5 it tries to get C1 only if it is not taken by P2. Contradiction.
//      starvation freedom: not guaranteed because we use random numbers generator to decide who eats next. Theoretically one philosopher might never win even though the probabillity is low we don't GUARANTEE that a particular philosopher never starves
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

        var p1TakesC1 = false;
        var p2TakesC1 = false;
        var p2TakesC2 = false;
        var p3TakesC2 = false;
        var p3TakesC3 = false;
        var p4TakesC3 = false;
        var p4TakesC4 = false;
        var p5TakesC4 = false;
        var p5TakesC5 = false;
        var p1TakesC5 = false;
        
        var philosopher1 = new Thread(() =>
        {
            var random = new Random();

            for (int i = 0; i < 1_000_000; i++)
            {
                if (random.Next(2) == 0)
                {
                    p1TakesC5 = true;
                    if (p5TakesC5)
                    {
                        p1TakesC5 = false;
                        while (p5TakesC5)
                            ;
                        p1TakesC5 = true;
                    }

                    p1TakesC1 = true;
                    if (!p2TakesC1)
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
                        p1TakesC1 = false;
                        p1TakesC5 = false;
                    } else {
                        p1TakesC1 = false;
                        p1TakesC5 = false;
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
                    p2TakesC1 = true;
                    
                    if (p1TakesC1)
                    {
                        p2TakesC1 = false;
                        while (p1TakesC1)
                            ;
                        p2TakesC1 = true;
                    }

                    p2TakesC2 = true;
                    if (!p3TakesC2)
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
                        p2TakesC1 = false;
                        p2TakesC2 = false;
                    } else {
                        p2TakesC1 = false;
                        p2TakesC2 = false;
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
                    p3TakesC2 = true;
                    if (p2TakesC2)
                    {
                        p3TakesC2 = false;
                        while (p2TakesC2)
                            ;
                        p3TakesC2 = true;
                    }

                    p3TakesC3 = true;
                    if (!p4TakesC3)
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
                        p3TakesC2 = false;
                        p3TakesC3 = false;
                    } else {
                        p3TakesC2 = false;
                        p3TakesC3 = false;
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
                    p4TakesC3 = true;
                    if (p3TakesC3)
                    {
                        p4TakesC3 = false;
                        while (p3TakesC3)
                            ;
                        p4TakesC3 = true;
                    }

                    p4TakesC4 = true;
                    
                    if (!p5TakesC4)
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
                        p4TakesC3 = false;
                        p4TakesC4 = false;
                    } else {
                        p4TakesC3 = false;
                        p4TakesC4 = false;
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
                    p5TakesC4 = true;

                    if (p4TakesC4)
                    {
                        p5TakesC4 = false;
                        while (p4TakesC4)
                            ;
                        p5TakesC4 = true;
                    }

                    p5TakesC5 = true;

                    if (!p1TakesC5)
                    {
                        chopstick4.IsHeld = true;
                        chopstick5.IsHeld = true;
                        Console.WriteLine("P5 is eating 1");
                        Thread.Sleep(100);
                        Console.WriteLine("P5 is eating 2");
                        Console.WriteLine("P5 is eating 3");
                        chopstick4.IsHeld = false;
                        chopstick5.IsHeld = false;
                        p5TakesC4 = false;
                        p5TakesC5 = false;
                    } else {
                        p5TakesC4 = false;
                        p5TakesC5 = false;
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