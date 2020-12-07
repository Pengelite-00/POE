using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{

    public enum TileType
    {
        Hero,
        Enemy,
        Gold,
        Weapon,
    }

    public enum movement
    {
        Up,
        Down,
        Left,
        Right,
        NoMovement 
    }
    public enum WeaponType
    {
        Rifle,
        Dagger,
        Longbow,
        LongSword
    }

    class GameEngine
    {
        private Map m = new Map(10, 20, 10, 20, 5);
        public Map M
        {
            get { return m; }
            set { M = value; }
        }

        public bool PlayerMove(movement move)
        {
            if (m.Player.returnMove(move) == movement.NoMovement)
            {
                return false;
            }
            else
            {
                item Playeritem = m.GetItemAtPosition(m.Player.X, M.Player.Y);
                if (Playeritem != null)
                {
                    m.Player.itempickup(Playeritem);
                }
                return true;
            }
        }
        public override string ToString()
        {
            string map = "";
            for (int i = 0; i <  m.Mapwidth; i++)
            {
                for (int j = 0; j < m.Mapheight; j++)
                {
                    map += m.map[i, j].SYMBOL + "";
                }
                map += "\n";
            }
            return map;
        }

        public void UpdateEnemies()                              
        {
            movement move;
            m.UpdateVision();
            foreach (Enemy enm in m.enemies)
            {
                m.UpdateVision();
                move = (movement)enm.returnMove();
                if (enm is Goblin)
                {
                    if (enm.CheckRange(m.Player))
                    {
                        enm.Attack(m.Player);
                    }
                }
                else if (enm is Mage)
                {
                    if (enm.CheckRange(m.Player))
                    {
                        enm.Attack(m.Player);
                    }
                    for (int i = 0; i < m.enemies.Length; i++)
                    {
                        if (m.enemies[i].X != enm.X && m.enemies[i].Y != enm.Y)
                        {
                            if (enm.CheckRange(m.enemies[i]))
                            {
                                enm.Attack(m.enemies[i]);
                            }
                        }

                    }
                }
                else if (enm is Leader)
                {
                    if (enm.CheckRange(m.Player))
                    {
                        enm.Attack(m.Player);
                    }
                }
                m.UpdateMap();
            }
        }
            public void EnemyAttack()
            {
                m.UpdateMap();
                foreach (Enemy enm in m.enemies)
                {
                if ( enm is Goblin)
                {
                    if (enm.CheckRange(m.Player))
                    {
                        enm.Attack(m.Player);
                    }
                    for (int y = 0; y < m.enemies.Length; y++)
                    {
                        if (m.enemies[y].X != enm.X && m.enemies[y].Y !=enm.Y)
                        {
                            if (enm.CheckRange(m.enemies[y]))
                            {
                                enm.Attack(m.enemies[y]);
                            }
                        }
                    }
                }
                
            }
        }
    }
    
}
