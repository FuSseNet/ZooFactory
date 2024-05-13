using ZooTerritory;
public class Visitor : People
{
    public override void status()
    {
        Console.WriteLine($"Имя посетителя:{Name}, пол посетителя:{Gender}");
    }
}