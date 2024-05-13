using Microsoft.Win32.SafeHandles;
using ZooTerritory;
public class Worker : People
{
    private string Rank;
    public string rank
    {
        get {return Rank;}
        set{Rank = value;}
    }

    public List<int> animalsInd = new List<int>();

    public override void status()
    {
        Console.WriteLine($"Имя работника:{Name}, пол работника:{Gender}, должность:{rank}");
    }
    public void Feeding()
    {
        List<Animals> animals = Zoo.ReturnAnimals();
        foreach (int i  in animalsInd)
        {
            if (animals[i].SaturationLevel < animals[i].SaturationThreshold)
            {
                Console.WriteLine($"Рабочий {Name} покормил {animals[i].Type} по кличке {animals[i].Name}");
                animals[i].SaturationLevel = 100;
                animals[i].Status = "Satisfied";
                break;
            }
        }
    }
}