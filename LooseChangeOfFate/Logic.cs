using System;
using LooseChangeOfFate.Characters;
using LooseChangeOfFate.Enemies;

namespace LooseChangeOfFate
{
    public static class Logic
    {
        private static Random rng = new Random();

        public static Enemy RandomizeEnemy()
        {
            int roll = rng.Next(0, 3);
            switch (roll)
            {
                case 0: return new Snake();
                case 1: return new Barbara();
                case 2: return new Larry();
                default: return new Snake();
            }
        }

        public static bool CoinFlip()
        {
            int roll = rng.Next(0, 2);
            return roll == 0;
        }

        public static void Looting(Character player)
        {
            string[] loot = { "cash money", "pocket lint", "a newspapers from four days ago." };
            int roll = rng.Next(loot.Length);

            if (roll == 0)
            {
                int cashMoney = 200;
                player.CashMoney += cashMoney;
                Console.WriteLine($"You found a thick wad of {loot[roll]}! +{cashMoney} cash money.");
            }
            else
            {
                Console.WriteLine($"You found {loot[roll]}. Not very useful.");
            }
        }

        public static bool Battle(Character player, Enemy enemy)
        {
            Console.WriteLine($"\n{player.Name} vs. {enemy.Name}! Get ready.");

            bool playerTurn = rng.Next(0, 2) == 0;

            while (player.CurrentHP > 0 && enemy.CurrentHP > 0)
            {
                if (playerTurn)
                {
                    Console.WriteLine($"You're up kiddo!. What's your plan?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Heal");
                    Console.WriteLine("3. Flee (coward)");

                    string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        int damage = player.Attack();
                        enemy.CurrentHP -= damage;
                        Console.WriteLine($"{enemy.Name} takes damage, {enemy.CurrentHP}/{enemy.MaxHP} HP left.");
                    }
                    else if (choice == "2")
                    {
                        player.Heal();
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine($"{player.Name} flees the battle and lives to see another day, only now as a coward.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Don't waste such a great opportunity");
                    }
                }
                else
                {
                    int damage = enemy.Attack();

                    if (enemy is Manager)
                    {
                        Console.WriteLine($"{enemy.Name} absorbs, and claims your attack");
                        damage = player.Damage;
                    }
                    player.CurrentHP -= damage;
                    Console.WriteLine($"{player.Name}, currently at {player.CurrentHP}/{player.MaxHP} HP");
                }
                
                playerTurn = !playerTurn;

            }

            if (player.CurrentHP <= 0)
            {
                Console.WriteLine($"\n{player.Name} died. {enemy.Name} did it");
                return false;
            }
            else
            {
                Console.WriteLine($"{player.Name} won!");
                player.CashMoney += enemy.CashMoneyReward;
                player.CurrentHP = player.MaxHP;
                Console.WriteLine($"{player.Name} celebrates in a non-alcoholic fashion, regains all HP, \nand adds {enemy.CashMoneyReward} cash money to the bank account.");
                return true;
            }
        }
    }
}
