public class Fighters
{
    private static List<Character> fighters = new List<Character>();

    public static void AddFighter()
    {
        Console.WriteLine("Приложение: Введите имя персонажа");
        string name = Console.ReadLine();

        Console.WriteLine("Приложение: Выберите оружие из списка ниже:");
        Console.WriteLine("0 - Без оружия");
        Console.WriteLine("1 - Меч");
        int weaponChoice = GetInput(0, 1);

        string weapon = weaponChoice == 0 ? "Без оружия" : "Меч";

        Console.WriteLine("Приложение: Выберите броню из списка:");
        Console.WriteLine("0 - Без брони");
        Console.WriteLine("1 - Простая одежда");
        Console.WriteLine("2 - Кожаная броня");
        int armorChoice = GetInput(0, 2);

        string armor = Armors.GetArmorName(armorChoice);

        fighters.Add(new Character(name, weapon, armor));
        Console.WriteLine("Приложение: Боец добавлен");
    }

    public static void StartBattle()
    {
        if (fighters.Count < 2)
        {
            Console.WriteLine("Недостаточное количество бойцов для битвы.");
            return;
        }

        Console.WriteLine("Приложение: Битва началась!");
        int round = 1;

        while (fighters.Count > 1)
        {
            Console.WriteLine($"Приложение: Раунд {round}");

            for (int i = 0; i < fighters.Count; i++)
            {
                var attacker = fighters[i];
                var target = fighters.Find(f => f != attacker);

                int damageDealt = attacker.Attack();
                target.TakeDamage(damageDealt);

                Console.WriteLine($"{attacker.Name} наносит {damageDealt} урона персонажу {target.Name}.");

                if (!target.IsAlive())
                {
                    Console.WriteLine($"{target.Name} погиб...");
                    fighters.RemoveAt(fighters.IndexOf(target));
                    i--;
                }
            }

            round++;
        }

        Console.WriteLine($"Приложение: Победитель - {fighters[0].Name}");
    }

    private static int GetInput(int minValue, int maxValue)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < minValue || choice > maxValue)
        {
            Console.WriteLine("Неверный ввод. Пожалуйста, введите корректное значение.");
        }
        return choice;
    }
}
