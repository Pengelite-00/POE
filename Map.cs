using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike_POE
{
    class Map
    {
        public int Mapwidth
        {
            get {return mapwidth;}
            set {mapwidth = value;}
        }

        public int Mapheight
        {
            get {return mapheight;}
            set {mapheight = value;}
        }

        public int Totalenemy
        {
            get {return totalenemy;}
            set {totalenemy = value; 
        }

        public Hero Player
        {
            get { return player; }
            set { player = value; }
        }

        public Map(int minmapwidth, int maxmapwidth, int minmapheight, int maxmapheight, int Totalenemy)
        {
            this.Mapwidth = rnd.Next(minmapwidth, maxmapwidth);
            this.Mapheight = rnd.Next(minmapheight, maxmapheight);
            this.Totalenemy = totalenemy;

            map = new Tile[Mapwidth, Mapheight];
            enemies = new Enemy[Totalenemy];


            Tile playerHero = Create(TileType.Hero);
            map[player.X, player.Y] = playerHero;


            UpdateVision();
        }

        public void UpdateVision()            //Method for vision
        {
            player.vision[0] = map[player.X - 1, player.Y];
            player.vision[1] = map[player.X, player.Y - 1];
            player.vision[2] = map[player.X + 1, player.Y];
            player.vision[3] = map[player.X, player.Y + 1];


            foreach (Enemy enm in enemies)
            {
                enm.vision[0] = map[enm.X - 1, enm.Y];
                enm.vision[1] = map[enm.X, enm.Y - 1];
                enm.vision[2] = map[enm.X + 1, enm.Y];
                enm.vision[3] = map[enm.X, enm.Y + 1];
            }

        }

        public void InitializeMap()                    //Method to fill map with empty tiles and obstacles
        {
            for (int x = 0; x < mapwidth; x++)
            {
                for (int y = 0; y < mapheight; y++)
                {
                    map[x, y] = new Emptytile(x, y);
                }
            }
            SetObstacles();
        }

        public item GetItemAtPosition(int x, int y)

        {
                                                        //Couldn't figure this one out 
        }

        public void UpdateMap()                     //Method to update map
        {
            InitializeMap();
            map[player.X, player.Y] = player;

            foreach (Enemy enm in enemies)
            {
                if (enm.IsDead() == false)
                {
                    map[enm.X, enm.Y] = enm;
                }
            }
        }


        
        public void Fillmap()                                //Method to populate map with empty tiles
        {
            for (int x = 0; x < mapwidth; x++)
            {
                for (int y = 0; y < mapheight; y++)
                {
                    map[x, y] = new Emptytile(x, y);
                }
            }
        }

        public void SetObstacles()                    //Method to place obstacles on map
        {
            for (int x = 0; x < mapwidth; x++)
            {
                for (int y = 0; y < mapheight; y++)
                {
                    if (x == 0 || y == 0 || x == mapwidth - 1 || y == mapheight - 1)
                    {
                        map[x, y] = new Obstacle(x, y);
                    }
                }
            }
        }

        public Tile[,] map;                               //Declaration of variables
        private Hero player;
        public Enemy[] enemies;
        public item[] item;
        private int mapwidth;
        private int mapheight;
        private int Totalenemy;
        private Random rnd = new Random();

        private Tile Create(TileType tiletype)                                       //Methods
        {
            int rndX = rnd.Next(0, Mapwidth);
            int rndY = rnd.Next(0, Mapheight);

            while (map[rndX, rndY] is Obstacle || map[rndX, rndY] is Character)
            {
                rndX = rnd.Next(0, Mapwidth);
                rndY = rnd.Next(0, Mapheight);
            }
            if (tiletype == TileType.Hero)
            {
                player = new Hero(rndX, rndY, 100);
                return player;
            }
            else if (tiletype == TileType.Enemy)
            {
                int rand = rnd.Next(1, 4);
                if (rand == 1)
                {
                    return new Goblin(rndX, rndY, 'G');
                }
                else if (rand == 2)
                {
                    return new Mage(rndX, rndY, 'M');
                }
                else
                {
                    return new Leader(rndX, rndY, player);
                }
            }

            else if (tiletype == TileType.Weapon)
            {
                int rand = rnd.Next(1, 5);
                if (rand == 1)
                {
                    return new MeleeWeapon(WeaponType.Dagger, "D", rndX, rndY);
                }

                else if (rand == 2)
                {
                    return new MeleeWeapon(WeaponType.LongSword, "7", rndX, rndY);
                }
                else if (rand == 3)
                {
                    return new RangedWeapon(WeaponType.Rifle, "R", rndX, rndY);
                }
                else if (rand == 4)
                {
                    return new RangedWeapon(WeaponType.Longbow, "B", rndX, rndY);
                }
                else

                {
                    return new Gold(rndX, rndY);
                }
            }
        }
    }
}



        
        

    

