using System;

public class Character
{
    public string Name { get; private set; }
    private string weapon;
    private string armor;
    private Random random = new Random();

    public int Health { get; private set; } = 100;

    public Character(string name, string weapon, string armor)
    {
        this.Name = name;
        this.weapon = weapon;
        this.armor = armor;
    }

    public int Attack()
    {
        double damageModifier = random.NextDouble() * 0.3 - 0.2;

        return (int)(10 * (1 + damageModifier));
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{this.Name} получает {damage} урона.");
        if (Health <= 0)
        {
            Console.WriteLine($"{this.Name} погибает...");
        }
    }

    public bool IsAlive()
    {
        return Health > 0;
    }
}