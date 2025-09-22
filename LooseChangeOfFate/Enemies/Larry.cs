using System;

namespace LooseChangeOfFate.Enemies
{
    public class Larry : Enemy
    {
        private Random rng = new Random();

        public Larry()
            : base("Larry the Librarian", 75, 10, 300)
        {
        }

        public override int Attack()
        {
            if (rng.Next(0, 4) == 0)
            {
                Console.WriteLine($"{Name} activates Cardigan Shield, and may take less damage next round.");
            }
            Console.WriteLine($"{Name} unleashes a barrage of library cards that deals {Damage} damage.");
            return Damage;
        }
    }
}
