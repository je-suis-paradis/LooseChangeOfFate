using System;

namespace LooseChangeOfFate.Enemies
{
    public abstract class Enemy
    {
        public string Name { get; protected set; }
        public int MaxHP { get; protected set; }
        public int CurrentHP { get; set; }
        public int Damage { get; protected set; }
        public int CashMoneyReward { get; protected set; }
        
        public Enemy(string name, int maxHP, int damage, int cashMoneyReward)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = maxHP;
            Damage = damage;
            CashMoneyReward = cashMoneyReward;
        }

        public virtual int Attack()
        {
            Console.WriteLine($"{Name} takes a swing at you and does {Damage} damage.");
            return Damage;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"{Name}, HP {CurrentHP}/{MaxHP}");
        }
        
    }
}
