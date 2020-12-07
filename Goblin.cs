using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
    class Goblin : Enemy
    {
        Movement Goblinmove;
        public Goblin (int x, int y, char Symbol) : base(x, y, 10, 1, 'G')
        {

        }

        public override Movement returnMove(Movement move = 0)
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 6);

            if (random == 1)
            {
                Goblinmove = Movement.Up;
            }
            else if (random == 2)
            {
                Goblinmove = Movement.Down;
            }
            else if (random == 3)
            {
                Goblinmove = Movement.Right;
            }
            else if (random == 4)
            {
                Goblinmove = Movement.Left;
            }
            else if (random == 5)
            {
                Goblinmove = Movement.Nomovement;
            }

            return Goblinmove;

        }
    }
}
