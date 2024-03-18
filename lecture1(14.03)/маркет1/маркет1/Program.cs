
        Console.WriteLine("Введите название товара:");
        string product = Console.ReadLine();

        Console.WriteLine("Введите количество товара:");
        int count = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите ваше имя:");
        string name = Console.ReadLine();

        Console.WriteLine("Введите адрес доставки:");
        string address = Console.ReadLine();

        Console.WriteLine($"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (Да/Нет)");
        string confirmation = Console.ReadLine();

        if (confirmation.ToLower() == "да")
        {
            Console.WriteLine($"{name}! Ваш заказ {product} в количестве {count} оформлен!");
            DateTime deliveryDate = DateTime.Today.AddDays(3);
            Console.WriteLine($"Ожидайте доставку по адресу {address} к {deliveryDate.ToString("dd/MM/yyyy")}");
        }
        else
        {
            Console.WriteLine("Пожалуйста, повторите ввод данных.");
        }