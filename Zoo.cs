using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;
using ZooTerritory;

public class Zoo
{
    private static List<Worker> workers = new List<Worker>();
    private static List<Animals> animals = new List<Animals>();
    private static List<Visitor> visitors = new List<Visitor>();

    public static List<Worker> ReturnWorkers()
    {
        return workers;
    }

    public static List<Animals> ReturnAnimals()
    {
        return animals;
    }

    public void Add(int ind)
    {
        switch (ind)
        {
            case 1:
                AddVisitor();
                break;
            case 2:
                AddWorker();
                break;
            case 3:
                AddAnimal();
                break;
        }
    }

    public void Edit(int ind)
    {
        switch (ind)
        {
            case 1:
                EditVisitor();
                break;
            case 2:
                EditWorker();
                break;
            case 3:
                EditAnimal();
                break;
        }
    }

    public void Delete(int ind)
    {
        switch (ind)
        {
            case 1:
                DeleteVisitor();
                break;
            case 2:
                DeleteWorker();
                break;
            case 3:
                DeleteAnimal();
                break;
        }
    }

    public void Status(int ind)
    {
        switch (ind)
        {
            case 1:
                ZooStatus();
                break;
            case 2:
                VisitorStatus();
                break;
            case 3:
                WorkerStatus();
                break;
            case 4:
                AnimalStatus();
                break;
        }
    }

    private static void ZooStatus()
    {
        Console.WriteLine($"В зоопарке {workers.Count} работник(ов)");
        Console.WriteLine($"В зоопарке {animals.Count} животное(ых)");
        Console.WriteLine($"В зоопарке {visitors.Count} посетитель(ей)");
    }

    private static void AnimalStatus()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("Животных сейчас нет в зоопарке :(");
        }
        else
        {
            Console.WriteLine("Статус какого животного вы хотите проверить?");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine("Животные, которые сейчас в зоопарке:");
                Console.WriteLine($"{i + 1}. {animals[i].Type} по кличке {animals[i].Name}");
            }

            Console.WriteLine("Введите номер животного:");
            int ind = int.Parse(Console.ReadLine());
            animals[ind - 1].status();
        }
    }

    private static void WorkerStatus()
    {
        if (workers.Count == 0)
        {
            Console.WriteLine("Работников сейчас нет в зоопарке :(");
        }
        else
        {
            Console.WriteLine("Статус какого работника вы хотите проверить?");
            Console.WriteLine("В зоопарке сейчас работают:");
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. Имя:{workers[i].Name}, Пол:{workers[i].Gender}, Должность:{workers[i].rank}");
            }

            Console.WriteLine("Введите номер работника:");
            int ind = int.Parse(Console.ReadLine());
            workers[ind - 1].status();
        }
    }

    private static void VisitorStatus()
    {
        if (visitors.Count == 0)
        {
            Console.WriteLine("Посетителей сейчас нет в зоопарке :(");
        }
        else
        {
            Console.WriteLine("Статус какого посетителя вы хотите проверить?");
            Console.WriteLine("Посетители с данными номерами биллетов сейчас в зоопарке:");
            for (int i = 0; i < visitors.Count; i++)
            {
                Console.WriteLine($"{i + 1}.");
            }

            Console.WriteLine("Введите номер биллета посетителя:");
            int ind = int.Parse(Console.ReadLine());

            visitors[ind - 1].status();
        }
    }

    private static void AddWorker()
    {
        Console.WriteLine("Введите имя, пол и должность работника");
        string[] data = Console.ReadLine().Split();
        string Name = data[0];
        string Gender = data[1];
        string rank = data[2];
        Worker worker = new Worker() { Name = Name, Gender = Gender, rank = rank };
        workers.Add(worker);
    }

    private static void EditWorker()
    {
        if (workers.Count == 0)
        {
            Console.WriteLine("Работников сейчас нет в зоопарке :( Добавить работника?");
            Console.WriteLine("1. ДА");
            Console.WriteLine("2. НЕТ");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    AddWorker();
                    break;
                case 2:
                    Director.Main();
                    break;
            }
        }

        Console.WriteLine("Выберите работника, которого хотите отредактировать");
        for (int i = 0; i < workers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Пол:{workers[i].Gender}, Имя:{workers[i].Name}, Должность:{workers[i].rank}");
        }

        int ind = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите новое имя, если имя не изменилось, просто напишите его заново:");
        string? name = Console.ReadLine();
        while (name == null)
        {
            Console.WriteLine("Вам нужно ввести новое имя или написать старое заново:");
            name = Console.ReadLine();
        }

        workers[ind - 1].Name = name;

        Console.WriteLine("Введите новый пол, если пол не изменился, просто напишите его заново:");
        string? gender = Console.ReadLine();
        while (gender == null)
        {
            Console.WriteLine("Вам нужно ввести новый пол или написать старый заново:");
            gender = Console.ReadLine();
        }

        workers[ind - 1].Gender = gender;

        Console.WriteLine("Введите новую должность, если должность не изменилась, просто напишите её заново:");
        string? rank = Console.ReadLine();
        while (rank == null)
        {
            Console.WriteLine("Вам нужно ввести новый пол или написать старый заново:");
            rank = Console.ReadLine();
        }

        workers[ind - 1].rank = rank;
    }

    private static void DeleteWorker()
    {
        if (workers.Count == 0)
        {
            Console.WriteLine("Работников сейчас нет в зоопарке :( Добавить работника?");
            Console.WriteLine("1. ДА");
            Console.WriteLine("2. НЕТ");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    AddWorker();
                    break;
                case 2:
                    return;
            }
        }

        Console.WriteLine("Выберите работника, которого вы хотите удалить");
        for (int i = 0; i < workers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Пол:{workers[i].Gender}, Имя:{workers[i].Name}, Должность:{workers[i].rank}");
        }

        Console.WriteLine("Введите номер работника, которого вы хотите удалить:");
        int ind = int.Parse(Console.ReadLine());
        Console.WriteLine("Вы уверены, что хотите удалить работника?");
        Console.WriteLine("1. Да" + "\n" + "2. Нет");
        int submit = int.Parse(Console.ReadLine());
        List<int> abandonedAnimals = workers[ind - 1].animalsInd;
        if (submit == 1)
        {
            workers.Remove(workers[ind - 1]);
        }

        if (workers.Count == 0)
        {
            Console.WriteLine("Добавьте рабочих, которые будут следить за животными!");
            AddWorker();
        }

        foreach (Animals animal in animals)
        {
            if (animal.Breadwinner >= ind - 1)
            {
                animal.Breadwinner -= 1;
            }
        }

        while (abandonedAnimals.Count > 0)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (abandonedAnimals.Count == 0)
                {
                    break;
                }

                workers[i].animalsInd.Add(abandonedAnimals[abandonedAnimals.Count - 1]);
                animals[abandonedAnimals[abandonedAnimals.Count - 1]].Breadwinner = i;
                abandonedAnimals.Remove(abandonedAnimals[abandonedAnimals.Count - 1]);
            }
        }
    }

    private static void AddAnimal()
    {
        Console.WriteLine("Выберите животное, которое хотите добавить:");
        Console.WriteLine("1. Волк");
        Console.WriteLine("2. Капибара");
        Console.WriteLine("3. Сервал");
        string? input = Console.ReadLine();
        if (input == "")
        {
            AddAnimal();
        }

        int ind = int.Parse(input);
        int gender;
        string wrGender;
        switch (ind)
        {
            case 1:
                Wolf wolf = new Wolf();
                Console.WriteLine("Выберите пол животного");
                Console.WriteLine("1. Мужчской");
                Console.WriteLine("2. Женский");

                gender = int.Parse(Console.ReadLine());
                switch (gender)
                {
                    case 1:
                        wrGender = "Мальчик";
                        wolf.Gender = wrGender;
                        break;
                    case 2:
                        wrGender = "Девочка";
                        wolf.Gender = wrGender;
                        break;
                }

                Console.WriteLine("Введите имя животного");
                wolf.Name = Console.ReadLine();
                animals.Add(wolf);
                break;
            case 2:
                Capybara capybara = new Capybara();
                Console.WriteLine("Выберите пол животного");
                Console.WriteLine("1. Мужчской");
                Console.WriteLine("2. Женский");

                gender = int.Parse(Console.ReadLine());
                switch (gender)
                {
                    case 1:
                        wrGender = "Мальчик";
                        capybara.Gender = wrGender;
                        break;
                    case 2:
                        wrGender = "Девочка";
                        capybara.Gender = wrGender;
                        break;
                }

                Console.WriteLine("Введите имя животного");
                capybara.Name = Console.ReadLine();
                animals.Add(capybara);
                break;
            case 3:
                Tiger tiger = new Tiger();
                Console.WriteLine("Выберите пол животного");
                Console.WriteLine("1. Мужской");
                Console.WriteLine("2. Женский");

                gender = int.Parse(Console.ReadLine());
                switch (gender)
                {
                    case 1:
                        wrGender = "Мальчик";
                        tiger.Gender = wrGender;
                        break;
                    case 2:
                        wrGender = "Девочка";
                        tiger.Gender = wrGender;
                        break;
                }

                Console.WriteLine("Введите имя животного");
                tiger.Name = Console.ReadLine();
                animals.Add(tiger);
                break;
        }

        Console.WriteLine("Животное теперь живет в зоопарке");
        Console.WriteLine(
            "За каким рабочим закрепить животное? Введите 0, чтобы добавить нового рабочего, который будет ухаживать за животным.");
        for (int i = 0; i < workers.Count(); i++)
        {
            Console.WriteLine(
                $"{i + 1}. Имя рабочего:{workers[i].Name}, должность:{workers[i].rank}, пол:{workers[i].Gender}");
        }

        string? breadwinner = Console.ReadLine();
        while (breadwinner == "")
        {
            Console.WriteLine(
                "Введите номер рабочего, за которым нужно закрепить животное или введите 0, чтобы добавить нового рабочего, который будет ухаживать за животным.");
            breadwinner = Console.ReadLine();
        }

        int breadwinnerInd = int.Parse(breadwinner);
        if (breadwinnerInd == 0)
        {
            AddWorker();
            breadwinnerInd = workers.Count;
        }

        workers[breadwinnerInd - 1].animalsInd.Add(animals.Count - 1);
        animals[animals.Count - 1].Breadwinner = breadwinnerInd - 1;
    }

    private static void EditAnimal()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("Животных сейчас нет в зоопарке :( Добавить животное?");
            Console.WriteLine("1. ДА");
            Console.WriteLine("2. НЕТ");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    AddAnimal();
                    break;
                case 2:
                    Director.Main();
                    break;
            }
        }

        Console.WriteLine(
            "Выберите животное, которого хотите отредактировать или введите 0, чтобы добавить новое животное");
        for (int i = 0; i < animals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. Вид животного: {animals[i].Type}, Имя животного: {animals[i].Name}, Пол животного: {animals[i].Gender}," +
                $" Рабочий, ухаживающий за животным: {workers[animals[i].Breadwinner].Name}, {workers[animals[i].Breadwinner].rank}");
        }

        string? input = Console.ReadLine();
        while (input == "")
        {
            Console.WriteLine(
                "Выберите животное, которого хотите отредактировать или введите 0, чтобы добавить новое животное");
            input = Console.ReadLine();
        }

        int ind = int.Parse(input);

        if (ind == 0)
        {
            AddAnimal();
            ind = animals.Count;
        }

        Console.WriteLine("Введите новое имя, если имя не изменилось, просто нажмите enter:");
        string? name = Console.ReadLine();
        if (name != "")
        {
            animals[ind - 1].Name = name;
        }

        Console.WriteLine("Введите новый пол, если пол не изменился, просто нажмите enter:");
        string? gender = Console.ReadLine();
        if (gender != "")
        {
            animals[ind - 1].Gender = gender;
        }

        Console.WriteLine(
            "Введите номер рабочего, который будет следить за животным, если этим занимается прежний рабочий, нажмите enter");
        for (int i = 0; i < workers.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. Имя рабочего: {workers[i].Name}, Пол рабочего: {workers[i].Gender}, Должность рабочего: {workers[i].rank} ");
        }

        string? breadwinner = Console.ReadLine();
        if (breadwinner != "")
        {
            workers[animals[ind - 1].Breadwinner].animalsInd.Remove(ind - 1);
            animals[ind - 1].Breadwinner = int.Parse(breadwinner) - 1;
        }
    }

    private static void DeleteAnimal()
    {
        if (animals.Count == 0)
        {
            Console.WriteLine("Животных в зоопарке нет :(");
            return;
        }

        Console.WriteLine("Выберите животное, которое вы хотите удалить");
        for (int i = 0; i < animals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {animals[i].Type} по кличке {animals[i].Name}");
        }

        Console.WriteLine("Введите номер животного, которого вы хотите удалить:");
        string? input = Console.ReadLine();
        if (input == "")
        {
            AddAnimal();
        }

        int ind = int.Parse(input);
        Console.WriteLine("Вы уверены, что хотите удалить это животное?");
        Console.WriteLine("1. Да" + "\n" + "2. Нет");
        int submit = int.Parse(Console.ReadLine());
        if (submit == 1)
        {
            workers[animals[ind - 1].Breadwinner].animalsInd.Remove(ind - 1);
            animals.Remove(animals[ind - 1]);
        }
    }

    private static void AddVisitor()
    {
        Console.WriteLine("Введите имя и пол посетителя");
        string[] data = Console.ReadLine().Split();
        string Name = data[0];
        string Gender = data[1];
        Visitor visitor = new Visitor() { Name = Name, Gender = Gender };
        visitors.Add(visitor);
    }

    private static void EditVisitor()
    {
        if (visitors.Count == 0)
        {
            Console.WriteLine("Посетителей сейчас нет в зоопарке :( Добавить посетителя?");
            Console.WriteLine("1. ДА");
            Console.WriteLine("2. НЕТ");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    AddVisitor();
                    break;
                case 2:
                    Director.Main();
                    break;
            }
        }

        Console.WriteLine("Выберите посетителя, которого хотите отредактировать");
        for (int i = 0; i < visitors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Пол:{visitors[i].Gender}, Имя:{visitors[i].Name}");
        }

        int ind = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите новое имя, если имя не изменилось, просто напишите его заново:");
        string? name = Console.ReadLine();
        while (name == null)
        {
            Console.WriteLine("Вам нужно ввести новое имя или написать старое заново:");
            name = Console.ReadLine();
        }

        visitors[ind - 1].Name = name;

        Console.WriteLine("Введите новый пол, если пол не изменился, просто напишите его заново:");
        string? gender = Console.ReadLine();
        while (gender == null)
        {
            Console.WriteLine("Вам нужно ввести новый пол или написать старый заново:");
            gender = Console.ReadLine();
        }

        visitors[ind - 1].Gender = gender;
    }

    private static void DeleteVisitor()
    {
        if (visitors.Count == 0)
        {
            Console.WriteLine("Посетителей сейчас нет в зоопарке :( Добавить посетителя?");
            Console.WriteLine("1. ДА");
            Console.WriteLine("2. НЕТ");
            int ans = int.Parse(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    AddVisitor();
                    break;
                case 2:
                    Director.Main();
                    break;
            }
        }

        Console.WriteLine("Выберите посетителя, которого вы хотите удалить");
        for (int i = 0; i < visitors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Пол:{visitors[i].Gender}, Имя:{visitors[i].Name}");
        }

        Console.WriteLine("Введите номер посетителя, которого вы хотите удалить:");
        int ind = int.Parse(Console.ReadLine());
        Console.WriteLine("Вы уверены, что хотите удалить посетителя?");
        Console.WriteLine("1. Да" + "\n" + "2. Нет");
        int submit = int.Parse(Console.ReadLine());
        if (submit == 1)
        {
            visitors.Remove(visitors[ind - 1]);
        }
    }
}