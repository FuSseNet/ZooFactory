namespace ZooTerritory;

public class Director
{
    private static bool work = true;
    public static void Main()
    {
        Zoo zoo = new Zoo();
        Starvation.main();
        while (work)
        {
            Console.WriteLine("Выберите команду из списка команд");
            Console.WriteLine(
                "1. Запросить статус" + "\n"+
                "2. Добавить обитателей в зоопарк" +"\n"+
                "3. Редактировать обитателей зоопарка"+"\n"+
                "4. Удалить обитателей зоопарка"+"\n"+
                "5. Попросить животное подать голос"+"\n"+
                "6. Остановить работу зоопарка"
            );
            int ind = int.Parse(Console.ReadLine());
            string? input;
            switch (ind)
            {
                case 1:
                    Console.WriteLine("Какие данные вас интересуют?");
                    Console.WriteLine("1. Статус зоопарка");
                    Console.WriteLine("2. Статус посетителя");
                    Console.WriteLine("3. Статус работника");
                    Console.WriteLine("4. Статус животного");
                    
                    input = Console.ReadLine();
                    while (input == "")
                    {
                        Console.WriteLine("Чей статус вы хотите узнать? Выберите номер команды");
                        input = Console.ReadLine();
                    }
                    int indStatus = int.Parse(input);
                    zoo.Status(indStatus);
                    break;
                case 2:
                    Console.WriteLine("Кого вы хотите добавить?");
                    Console.WriteLine("1. Добавить посетителя");
                    Console.WriteLine("2. Добавить работника");
                    Console.WriteLine("3. Добавить животного");
        
                    input = Console.ReadLine();
                    while (input == "")
                    {
                        Console.WriteLine("Кого именно вы хотите добавить? Выберите номер команды");
                        input = Console.ReadLine();
                    }

                    int indAdd = int.Parse(input);
                    zoo.Add(indAdd);
                    break;
                case 3:
                    Console.WriteLine("Кого вы хотите отредактировать?");
                    Console.WriteLine("1. Редактировать посетителя");
                    Console.WriteLine("2. Редактировать работника");
                    Console.WriteLine("3. Редактировать животного");
        
                    input = Console.ReadLine();
                    while (input == "")
                    {
                        Console.WriteLine("Кого именно вы хотите отредактировать? Введите номер команды");
                        input = Console.ReadLine();
                    }

                    int indEdit = int.Parse(input);
                    zoo.Edit(indEdit);
                    break;
                case 4:
                    Console.WriteLine("Кого вы хотите удалить?");
                    Console.WriteLine("1. Удалить посетителя");
                    Console.WriteLine("2. Удалить работника");
                    Console.WriteLine("3. Удалить животного");
        
                    input = Console.ReadLine();
                    while (input == "")
                    {
                        Console.WriteLine("Кого именно вы хотите удалить? Введите номер команды");
                    }
                    int indDelete = int.Parse(input);
                    zoo.Delete(indDelete);
                    break;
                case 5:
                    Animals.getVoice();
                    break;
                case 6:
                    work = false;
                    break;
            }
        }
        Console.WriteLine("Работа зоопарка остановлена");
    }
}