using System;

namespace LooseChangeOfFate.Characters
{
    public class Warrior : Character
    {
        public Warrior(string name) 
            : base(name, "Warrior", 110, 8)
        {
        }
        public override void Heal()
        {
            int healAmount = 3;
            CurrentHP = Math.Min(MaxHP, CurrentHP + healAmount);
            Console.WriteLine($"{Name} takes a rest and regains {healAmount} HP.");
        }
    }
}
