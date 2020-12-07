﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
    
    abstract class Enemy : Character
    {
        
       protected Random generator = new Random();

        public Enemy(int x, int y, int HP, int Damage, char Symbol) : base(x, y,sym)
        {
            this.Hp = HP;
            this.DAMAGE = Damage;
            
        }

        public override string ToString()
        {
            return "(this.GetType().Name at [{x}, {y}] ({Damage} )";
        }
    }
}

