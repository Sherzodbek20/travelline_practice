using System;

namespace BattleGame
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Приложение: Введите команду (для выхода введите 'exit')");
                Console.WriteLine("Добавить нового бойца на арену - 1");
                Console.WriteLine("Начать битву - 2");
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    break;
                }

                switch (command)
                {
                    case "1":
                        Fighters.AddFighter();
                        break;
                    case "2":
                        Fighters.StartBattle();
                        break;
                    default:
                        Console.WriteLine("Некорректная команда. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
