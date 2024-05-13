using ZooTerritory;
public abstract class Animals
{
    private string type;
    private string name;
    private string gender;
    private string _status;
    private int saturationLevel;
    private int saturationThreshold;
    private int breadwinner;
    public string Type
    {
        get {return type ;}
        set {type = value;}
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    public int SaturationLevel
    {
        get { return saturationLevel; }
        set { saturationLevel = value; }
    }

    public int SaturationThreshold
    {
        get { return saturationThreshold;}
        set { saturationThreshold = value; }
    }

    public int Breadwinner
    {
        get { return breadwinner;}
        set { breadwinner = value; }
    }
    public abstract void sound();
    public abstract void status();
    
    public static void getVoice()
    {
        List<Animals> animals = Zoo.ReturnAnimals();
        if (animals.Count == 0)
        {
            Console.WriteLine("Животных нет в зоопарке");
        }
        else
        {
            Console.WriteLine("Выберите животное, голос которого вы хотите услышать");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {animals[i].Type} по кличке {animals[i].Name}");
            }

            Console.WriteLine("Введите номер животного, голос которого вы хотите услышать:");
            string? input = Console.ReadLine();
            while (input == "")
            {
                Console.WriteLine("Введите номер животного, голос которого вы хотите услышать:");
                input = Console.ReadLine();
            }

            int ind = int.Parse(input);
            animals[ind - 1].sound();
        }
    }
}