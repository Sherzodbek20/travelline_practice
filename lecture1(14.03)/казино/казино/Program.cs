int balance = 10000;

    while (balance > 0)
        {
            Console.WriteLine($"Ваш текущий баланс: {balance}");

            int bet;
            Console.Write("Сделайте вашу ставку: ");
            if (!int.TryParse(Console.ReadLine(), out bet))
            {
                Console.WriteLine("Пожалуйста, введите целое число");
                continue;
            }

            if (bet > balance)
            {
                Console.WriteLine("У вас недостаточно средств для такой ставки");
                continue;
            }

            Random random = new Random();
            int randomNum = random.Next(1, 21);

            if (randomNum >= 18)
            {
                int multiplicator = randomNum % 17;
                int winAmount = bet * (1 + (multiplicator * randomNum % 17));
                balance += winAmount;
                Console.WriteLine($"Выпало число {randomNum}. Вы выиграли {winAmount} у.е.");
            }
            else
            {
                balance -= bet;
                Console.WriteLine($"Выпало число {randomNum}. Вы проиграли вашу ставку.");
            }
        }
        Console.WriteLine("Игра окончена. Ваш баланс опустился до 0.");
