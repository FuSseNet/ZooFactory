using System.Timers;
using ZooTerritory;
using Timer = System.Timers.Timer;

namespace ZooTerritory;

public class Starvation
{
    public static Timer timer;

    public static void main()
    {
        SetTimer();
    }
    
    public static void SetTimer()
    {
        timer = new Timer(1000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    public static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        List<Animals> animals = Zoo.ReturnAnimals();
        List<Worker> workers = Zoo.ReturnWorkers();
        if (animals.Count > 0)
        {
            foreach (Animals animal in animals)
            {
                if (animal.SaturationLevel < animal.SaturationThreshold)
                {
                    if (workers.Count == 0)
                    {
                        Console.WriteLine($"Животное {animal.Type} по кличке {animal.Name} уже проголодалось, скорее добавьте рабочего, который будет следить за {animal.Name}");
                    }
                }
                else
                {
                    animal.SaturationLevel -= 1;
                    if (animal.SaturationLevel <= animal.SaturationThreshold)
                    {
                        animal.Status = "Hungry";
                    }
                }
            }

            foreach (Worker worker in workers)
            {
                worker.Feeding();
            }
        }
    }
}