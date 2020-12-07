using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
    class Hero : Character
    {
        Movement Heromove;

            public Hero (int x, int y, int HP) : base(x, y ,'H')
        {        
            this.Hp = HP;
            this.Maxhp = MAXHP;
            Damage = 2;
            base.purse = 0;
        }

        public override Movement returnMove(Movement move)
        {
            if (move == Movement.Up)
            {
                Heromove = Movement.Up;
            }

            else if (move == Movement.Down)
            {
                Heromove = Movement.Down;
            }

            else if (move == Movement.Right)
            {
                Heromove = Movement.Right;
            }

            else if (move == Movement.Left)
            {
                Heromove = Movement.Left;
            }

            else if (move == Movement.Nomovement)
            {
                Heromove = Movement.Nomovement;
            }

            return Heromove;
        }

        internal movement returnMove(movement move)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Player Stats:\n HP: {HP}/{MAXHP}\n Damage: {Damage}\n [{X}, {Y}]";
        }
    }

    
}
