using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
   public abstract class Weapon : item
    {
        protected int Damage;
        protected int Range;
        protected int Durability;
        protected int Cost;
        protected WeaponType Type;

        public Weapon(int x, int y) : base(x, y, ' ')
        {

        }



        public int damage
        {
            get { return Damage; }
            set { Damage = value; }
        }

        public int range
        {
            get { return Range; }
            set { Range = value; }
        }

        public int durability
        {
            get { return Durability; }
            set { Durability = value; }
        }

        public int cost
        {
            get { return Cost; }
            set { Cost = value; }

        }

        public WeaponType type
        {
            get { return Type;  }
            set { Type = value;  }
        }

       
    }
}

