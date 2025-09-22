
using System.Threading.Tasks;

namespace LooseChangeOfFate.Enemies
{
    public class Snake : Enemy
    {
        private Random rng = new Random();
        public Snake()
            : base("Snake the Rat", 60, 8, 200)
        {
        }

        public override int Attack()
        {
            Console.WriteLine($"{Name}'s swift attack lands perfectly and inflicts {Damage} damage.");
            if (rng.Next(0, 5) == 0)
            {
                Console.WriteLine($"What just happened!? You haven't got the faintest idea, so {Name} attacks once more.");
                return Damage * 2;
            }
            return Damage;
        }
    }
}
