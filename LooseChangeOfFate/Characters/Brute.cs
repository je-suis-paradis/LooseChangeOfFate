using System;

namespace LooseChangeOfFate.Characters
{
    public class Brute : Character
    {
        private Random rng = new Random();

        public Brute(string name)
            : base(name, "Brute", 130, 15)
        {
        }

        public override int Attack()
        {
            if (rng.Next(0, 5) == 0)
            {
                Console.WriteLine($"Oh, no! {Name} stumbles and takes all the damage!");
                CurrentHP -= Damage;
                return 0;
            }
            else
            {
                int heavyDamage = (int)(Damage * 1.5);
                Console.WriteLine($"{Name} hits like a ton of bricks and deals a whopping {heavyDamage} damage!");
                return heavyDamage;
            }
        }
    }

}
