using System;
using System.Collections.Generic;

class Translator
{
    private Dictionary<string, string> translations = new Dictionary<string, string>();

    public void ДобавитьПеревод(string слово, string перевод)
    {
        translations[слово] = перевод;
        Console.WriteLine($"Перевод добавлен: {слово} - {перевод}");
    }

    public void УдалитьПеревод(string слово)
    {
        if (translations.ContainsKey(слово))
        {
            translations.Remove(слово);
            Console.WriteLine($"Перевод для '{слово}' успешно удален");
        }
        else
        {
            Console.WriteLine($"Перевод для '{слово}' не найден");
        }
    }

    public void ИзменитьПеревод(string слово, string новыйПеревод)
    {
        if (translations.ContainsKey(слово))
        {
            translations[слово] = новыйПеревод;
            Console.WriteLine($"Перевод для '{слово}' изменен на '{новыйПеревод}'");
        }
        else
        {
            Console.WriteLine($"Перевод для '{слово}' не найден");
        }
    }

    public void Перевести(string слово)
    {
        if (translations.ContainsKey(слово))
        {
            Console.WriteLine($"Перевод слова '{слово}' - '{translations[слово]}'");
        }
        else
        {
            Console.WriteLine($"Перевод для слова '{слово}' не найден");
        }
    }
    public void ОбратныйПеревод(string перевод)
    {
        var слово = translations.FirstOrDefault(x => x.Value == перевод).Key;
        if (!string.IsNullOrEmpty(слово))
        {
            Console.WriteLine($"Обратный перевод слова '{перевод}' - '{слово}'");
        }
        else
        {
            Console.WriteLine($"Обратный перевод для перевода '{перевод}' не найден");
        }
    }

    public void ВсеПереводы()
    {
        foreach (var pair in translations)
        {
            Console.WriteLine($"Слово: {pair.Key}, Перевод: {pair.Value}");
        }
    }

}

class Program
{
    static void Main()
    {
        Translator translator = new Translator();

        string[] lines = File.ReadAllLines("commands.txt");

        foreach (var line in lines)
        {
            string[] parts = line.Split(' ');
            string command = parts[0];

            switch (command)
            {
                case "add":
                    string слово = parts[1];
                    string перевод = parts[2];
                    translator.ДобавитьПеревод(слово, перевод);
                    break;

                case "remove":
                    string словоДляУдаления = parts[1];
                    translator.УдалитьПеревод(словоДляУдаления);
                    break;

                case "change":
                    string словоДляИзменения = parts[1];
                    string новыйПеревод = parts[2];
                    translator.ИзменитьПеревод(словоДляИзменения, новыйПеревод);
                    break;

                case "translate":
                    string словоДляПеревода = parts[1];
                    translator.Перевести(словоДляПеревода);
                    break;

                case "reverse":
                    string переводДляОбратногоПеревода = parts[1];
                    translator.ОбратныйПеревод(переводДляОбратногоПеревода);
                    break;

                case "all":
                    translator.ВсеПереводы();
                    break;

                default:
                    Console.WriteLine("Некорректная команда: " + command);
                    break;
            }
        }
    }
}