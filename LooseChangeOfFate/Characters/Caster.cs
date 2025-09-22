using System;


namespace LooseChangeOfFate.Characters
{
    public class Caster : Character
    {
        public int MaxMana { get; private set; }
        public int Mana { get; private set; }

        public Caster(string name)
                : base(name, "Caster", 90, 10)
        {
            MaxMana = 30;
            Mana = MaxMana;
        }

        public int Attack()
        {
            if (Mana >= 5)
            {
                Mana -= 5;
                Console.WriteLine($"{Name} opens uncorks a bottle that good 'ol abracadabra, for {Damage + 5} damage.");
                return Damage + 5;
            }
            else
            {
                Console.WriteLine($"{Name} is out of mana throws a rock instead.");
                return + 2;
            }
        }

        public void RegeneratMana()
        {
            int regen = 3;
            Mana = Math.Min(MaxMana, Mana + regen);
            Console.WriteLine($"After a short break, {Name} regains {regen} mana.");
        }

        public void PrintStatus()
        {
            PrintStatus();
            Console.WriteLine($"Mana: {Mana}/{MaxMana}");
            Console.WriteLine();
        }
    }
}
