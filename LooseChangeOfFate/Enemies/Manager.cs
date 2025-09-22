using System;

namespace LooseChangeOfFate.Enemies
{
    public class Manager : Enemy
    {
        public Manager()
            : base("The Project Manager", 120, 12, 1000)
        {
        }

        public int Attack()
        {
            Console.WriteLine($"{Name} steals your ideas and disguise them as their own. (Yeah, what a douche...");
            return 0;
        }
    }
}
