using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        public static List<Enemy> Enemies;
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Wizard Cat");
            Enemies = new List<Enemy>();
            Actor root = new Actor();
            game.Root = root;

            //## Set up game here ##//
            //adds the player and enemies to the game
            Player player = new Player(640,380);
            Enemy enemy = new Enemy(300, 600);
            Enemy enemy1 = new Enemy(400, 500);
            Enemy enemy2 = new Enemy(500, 300);
            Enemy enemy3 = new Enemy(900, 400);

            //adds the enemies to a list
            Enemies.Add(enemy);
            Enemies.Add(enemy1);
            Enemies.Add(enemy2);
            Enemies.Add(enemy3);

            //have the added entities show on screen
            root.AddChild(player);
            foreach (Enemy e in Enemies)
            {
                root.AddChild(e);
            }

            game.Run();
        }
    }
}
