using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] priceRatings = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int entryPoint = int.Parse(Console.ReadLine());
        string itemType = Console.ReadLine();

        int leftDamage = CalculateDamage(priceRatings, entryPoint, itemType, "Left");
        int rightDamage = CalculateDamage(priceRatings, entryPoint, itemType, "Right");

        if (leftDamage >= rightDamage)
        {
            Console.WriteLine($"Left - {leftDamage}");
        }
        else
        {
            Console.WriteLine($"Right - {rightDamage}");
        }
    }

    static int CalculateDamage(int[] priceRatings, int entryPoint, string itemType, string direction)
    {
        int damage = 0;

        if (direction == "Left")
        {
            for (int i = entryPoint - 1; i >= 0; i--)
            {
                if (itemType == "cheap" && priceRatings[i] < priceRatings[entryPoint])
                {
                    damage += priceRatings[i];
                }
                else if (itemType == "expensive" && priceRatings[i] >= priceRatings[entryPoint])
                {
                    damage += priceRatings[i];
                }
            }
        }
        else if (direction == "Right")
        {
            for (int i = entryPoint + 1; i < priceRatings.Length; i++)
            {
                if (itemType == "cheap" && priceRatings[i] < priceRatings[entryPoint])
                {
                    damage += priceRatings[i];
                }
                else if (itemType == "expensive" && priceRatings[i] >= priceRatings[entryPoint])
                {
                    damage += priceRatings[i];
                }
            }
        }

        return damage;
    }
}
