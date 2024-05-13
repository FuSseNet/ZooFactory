class Capybara : Animals
{
    public Capybara()
    {
        Status = "Satisfied";
        SaturationLevel = 100;
        SaturationThreshold = 10;
        Type = "Капибара";
    }
    
    public override void sound()
    {
        Console.WriteLine("Squeak");
    }
    
    public override void status()
    {
        Console.WriteLine($"Статус:{Status},  значение сытости:{SaturationLevel}");
    }
}