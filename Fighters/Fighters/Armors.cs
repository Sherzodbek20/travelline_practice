using System;

public static class Armors
{
    public static string GetArmorName(int choice)
    {
        switch (choice)
        {
            case 0:
                return "Без брони";
            case 1:
                return "Простая одежда";
            case 2:
                return "Кожаная броня";
            default:
                return "Без брони";
        }
    }
}
