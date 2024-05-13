class Tiger : Animals
{
    public Tiger()
    {
        Status = "Satisfied";
        SaturationLevel = 100;
        SaturationThreshold = 15;
        Type = "Сервал";

    }
    public override void sound()
    {
        Console.WriteLine("Grrrrr");
    }

    public override void status()
    {
        Console.WriteLine($"Статус:{Status},  значение сытости:{SaturationLevel}");
    }
}