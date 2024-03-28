using System;
using System.Collections.Generic;
using System.IO;

class Переводчик
{
    private Dictionary<string, string> переводы = new Dictionary<string, string>();

    public void ЗагрузитьПереводыИзФайла(string путьКФайлу)
    {
        if (File.Exists(путьКФайлу))
        {
            string[] строки = File.ReadAllLines(путьКФайлу);
            foreach (string строка in строки)
            {
                string[] части = строка.Split(':');
                if (части.Length == 2)
                {
                    переводы[части[0].Trim()] = части[1].Trim();
                    переводы[части[1].Trim()] = части[0].Trim();
                }
            }
        }
    }

    public void ДобавитьПеревод(string слово, string перевод)
    {
        переводы[слово] = перевод;
        переводы[перевод] = слово;
    }

    public void УдалитьПеревод(string слово)
    {
        if (переводы.ContainsKey(слово))
        {
            string перевод = переводы[слово];
            переводы.Remove(слово);
            переводы.Remove(перевод);
        }
    }

    public void ИзменитьПеревод(string слово, string новыйПеревод)
    {
        if (переводы.ContainsKey(слово))
        {
            string старыйПеревод = переводы[слово];
            переводы[слово] = новыйПеревод;
            переводы[новыйПеревод] = слово;
            переводы.Remove(старыйПеревод);
        }
    }

    public string Перевести(string слово)
    {
        if (переводы.ContainsKey(слово))
        {
            return переводы[слово];
        }
        else
        {
            return "Перевод не найден";
        }
    }

    public void СохранитьПереводыВФайл(string путьКФайлу)
    {
        List<string> строки = new List<string>();
        foreach (var пара in переводы)
        {
            строки.Add(пара.Key + " : " + пара.Value);
        }
        File.WriteAllLines(путьКФайлу, строки);
    }
}

class Программа
{
    static void Main()
    {
Переводчик переводчик = new Переводчик();
        переводчик.ЗагрузитьПереводыИзФайла("переводы.txt");

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. ДобавитьПеревод");
            Console.WriteLine("2. УдалитьПеревод");
            Console.WriteLine("3. ИзменитьПеревод");
            Console.WriteLine("4. Перевести");
            Console.WriteLine("5. Выход");

            Console.Write("Введите ваш выбор: ");
            int выбор = int.Parse(Console.ReadLine());

            switch (выбор)
            {
                case 1:
                    Console.Write("Введите слово: ");
                    string слово = Console.ReadLine();
                    Console.Write("Введите перевод: ");
                    string перевод = Console.ReadLine();
                    переводчик.ДобавитьПеревод(слово, перевод);
                    break;
                case 2:
                    Console.Write("Введите слово для удаления: ");
                    string словоДляУдаления = Console.ReadLine();
                    переводчик.УдалитьПеревод(словоДляУдаления);
                    break;
                case 3:
                    Console.Write("Введите слово для изменения перевода: ");
                    string словоДляИзменения = Console.ReadLine();
                    Console.Write("Введите новый перевод: ");
                    string новыйПеревод = Console.ReadLine();
                    переводчик.ИзменитьПеревод(словоДляИзменения, новыйПеревод);
                    break;
                case 4:
                    Console.Write("Введите слово для перевода: ");
                    string словоДляПеревода = Console.ReadLine();
                    string переведенноеСлово = переводчик.Перевести(словоДляПеревода);
                    Console.WriteLine($"Перевод: {переведенноеСлово}");
                    break;
               case 5:
                    переводчик.СохранитьПереводыВФайл("переводы.txt");
                    return;
                default:
                    Console.WriteLine("Недопустимый выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}
