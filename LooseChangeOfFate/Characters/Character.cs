using System;

namespace LooseChangeOfFate.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public string ClassName { get; protected set; }
        public int MaxHP { get; protected set; }
        public int CurrentHP { get; set; }
        public int Damage { get; protected set; }
        public int CashMoney { get; set; }

        public Character(string name, string className, int maxHP, int damage)
        {
            Name = name;
            ClassName = className;
            MaxHP = maxHP;
            CurrentHP = maxHP;
            Damage = damage;
            CashMoney = 0;
        }

        public virtual int Attack()
        {
            Console.WriteLine($"{Name} attacks and deals {Damage} damage!");
            return Damage;
        }

        public virtual void Heal()
        {
            Console.WriteLine($"{Name} takes nap, but regains no HP.");
        }

        public void PrintStatus()
        {
            Console.WriteLine($"{Name} the {ClassName}:");
            Console.WriteLine($"HP: {CurrentHP}/{MaxHP}");
            Console.WriteLine($"Current amount of cash money: {CashMoney}");
            Console.WriteLine();
        }
    }
}
