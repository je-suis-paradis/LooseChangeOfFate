using System;

namespace LooseChangeOfFate.Enemies
{
    public class Barbara : Enemy
    {
        private Random rng = new Random();

        public Barbara()
            : base("Barbara the Barbarian", 90, 15, 400)
        {
        }

        public override int Attack()
        {

            if (rng.Next(0, 5) == 0)
            {
                Console.WriteLine($"{Name} scoffs and snarls and scares you stiff!");
                return 0;
            }

            Console.WriteLine($"{Name} swings their axe and does {Damage} damage.");
            return Damage;
        }
    }
}
