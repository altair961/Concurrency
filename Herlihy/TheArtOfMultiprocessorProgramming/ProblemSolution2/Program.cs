namespace ProblemSolution2;
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
        var chopstick1 = new Chopstick(1);
        
        // shared by pholosopher2 and pholosopher3
        var chopstick2 = new Chopstick(2);
        
        // shared by pholosopher3 and pholosopher4
        var chopstick3 = new Chopstick(3);
        
        // shared by pholosopher4 and pholosopher5
        var chopstick4 = new Chopstick(4);
        
        // shared by pholosopher5 and pholosopher1
        var chopstick5 = new  Chopstick(5);

        var numberGenerator = new Random();

        var philosopher1 = new Philosopher(1, chopstick1, chopstick5, numberGenerator);
        var philosopher2 = new Philosopher(2, chopstick2, chopstick1, numberGenerator);
        var philosopher3 = new Philosopher(3, chopstick3, chopstick2, numberGenerator);
        var philosopher4 = new Philosopher(4, chopstick4, chopstick3, numberGenerator);
        var philosopher5 = new Philosopher(5, chopstick5, chopstick4, numberGenerator);
        
        philosopher1.Think(philosopher5, philosopher2);
        philosopher2.Think(philosopher1, philosopher3);
        philosopher3.Think(philosopher2, philosopher4);
        philosopher4.Think(philosopher3, philosopher5);
        philosopher5.Think(philosopher4, philosopher1);
    }
}