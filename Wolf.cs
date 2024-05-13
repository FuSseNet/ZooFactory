class Wolf : Animals
{
    public Wolf()
    {
        Status = "Satisfied";
        SaturationLevel = 100;
        SaturationThreshold = 25;
        Type = "Волк";

    }

    public override void sound()
    {
        Console.WriteLine("Auuuuuf");
    }
    
    public override void status()
    {
        Console.WriteLine($"Статус:{Status},  значение сытости:{SaturationLevel}");
    }
}