using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
    class Gold : item
    {
        private Random rand = new Random();

        private int totalGold;
        public Gold(int x, int y, char Symbol) : base (x, y, '$')
        {
            totalGold = rand.Next(1, 5);
        }

        public int totalgold
        {
            get { return totalGold;  }
            set { totalgold = value;  }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
