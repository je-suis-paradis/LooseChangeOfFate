using System;
using LooseChangeOfFate.Characters;
using LooseChangeOfFate.Enemies;

namespace LooseChangeOfFate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, adventurer!\n");
            Console.WriteLine("What is your @handle?");

            string playerName = Console.ReadLine();

            Character player = classChoice(playerName);

            Console.WriteLine($"\n{playerName} the {player.ClassName}... It has a certain ring to it.");
            Console.WriteLine($"\nBefore you venture out on your own, please accept this useless pile of loose change.");
            Console.WriteLine("\nIt's not much, but these coins will decide your fate. Press any key to flip one...");
            Console.ReadKey();

            bool gameRunning = true;
            int lossCount = 0;

            while (gameRunning)
            {
                bool coinToss = Logic.CoinFlip();

                if (coinToss)
                {
                    Console.WriteLine("\nYou see something on the ground and pick it up -- EUREKA, it's loot!");
                    Logic.Looting(player);
                }
                else
                {
                    Enemy enemy = Logic.RandomizeEnemy();
                    bool survived = Logic.Battle(player, enemy);

                    if (!survived)
                    {
                        lossCount++;
                        if (lossCount >= 3)
                        {
                            Console.WriteLine($"\nThree strikes -- you're out! You died three times. Game Over.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nYou lost, but get another shot. \nAlso, you lose any cash money you've accumulated up to this point.");
                            player.CashMoney = 0;
                            player.CurrentHP = player.MaxHP;
                        }
                    }
                }

                if (player.CashMoney >= 1000)
                {
                    Manager finalBoss = new Manager();
                    bool won = Logic.Battle(player, finalBoss);
                    if (won)
                    {
                        Console.WriteLine("\nYou did it! You conquered a formidable enemy!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nYou hear that? Tiny violins play for you. Because you died. \nThe Project Manager crushed you. That's a Game Over.");
                        break;
                    }
                }
                Console.WriteLine("You are ready to move on. Flip the coin again?(y/n)");
                string cont = Console.ReadLine().ToLower();
                if (cont != "y")
                {
                    gameRunning = false;
                }
                else
                {
                    Console.WriteLine($"But, {playerName}!? Why? We had high hopes for you. \nCome back anytime you want!");
                }
            }

            Console.WriteLine("\n~|~|~ THE || END ~|~|~ ");
            Console.WriteLine("\nThis has been a console adventure by Paradiset.");
            Console.WriteLine("\nIdeas, concept, and code by p-nut."); 
            Console.WriteLine("\nWhen I faced problems I couldn't handle, the Chat Gippity guy helped out.");

            static Character classChoice(string name)
            {
                Console.WriteLine("Choose preferred class. 1 - 4.");
                Console.WriteLine("1. The Warrior: a noble battle artist with a sharp sword.");
                Console.WriteLine("2. The Caster: armed with a tiny stick, abras, and cadabras.");
                Console.WriteLine("3. The Brute: lethal, but also stupid. Did we mention studpid?");
                Console.WriteLine("4. The Shinobi no mono: the not-so silent assassin.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        return new Warrior(name);
                        break;
                    case "2":
                        return new Caster(name);
                        break;
                    case "3":
                        return new Brute(name);
                        break;
                    case "4":
                        return new Shinobi();
                        break;
                    default:
                        Console.WriteLine("Invalid option. That does it, you are a Warrior, like it or not!");
                        return new Warrior(name);
                }
            }
        }
    }
}

