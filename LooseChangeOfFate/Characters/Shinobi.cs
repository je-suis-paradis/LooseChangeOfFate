using System;

namespace LooseChangeOfFate.Characters
{
    public class Shinobi : Character
    {
        public Shinobi()
            : base("Shinobi Pneu Monia", "Ninja", 95, 12)
        {
        }

        public override int Attack()
        {
            Console.WriteLine($"The shinobi coughs up nasty phlegm from deep within and does {Damage} damage.");
            return Damage;
        }
    }
}
