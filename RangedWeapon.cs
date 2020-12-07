using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
    class RangedWeapon : Weapon
    {

        public RangedWeapon(WeaponType type, string v, int x, int y) : base(x, y)
        {

            if (type == WeaponType.Rifle)
            {
                base.Damage = 4;
                base.range = 2;
                base.Durability = 4;
                base.Cost = 6;
            }

            if (type == WeaponType.Longbow)
            {
                base.Damage = 5;
                base.range = 3;
                base.Durability = 3;
                base.Cost = 7;
            }
        }

        public RangedWeapon(WeaponType Rifle, string z)
        {
            this.Rifle = Rifle;
            this.z = z;
        }

        public WeaponType weaponType;
        private WeaponType Rifle;
        private string z;

        public override string ToString()
        {
            return "Ranged weapon at " + X + Y + "Deals: " + Damage;
        }

    }

        
    }

