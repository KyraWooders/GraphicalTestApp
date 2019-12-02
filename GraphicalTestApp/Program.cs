using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Game game = new Game(1280, 760, "Wizard Cat");

            Actor root = new Actor();
            game.Root = root;

            //## Set up game here ##//
            Player player = new Player(640,380);
            Enemy enemy = new Enemy(300, 600);
            Enemy enemy1 = new Enemy(400, 500);
            Enemy enemy2 = new Enemy(500, 300);
            Enemy enemy3 = new Enemy(900, 400);
            
            


            root.AddChild(player);
            root.AddChild(enemy);
            root.AddChild(enemy1);
            root.AddChild(enemy2);
            root.AddChild(enemy3);

            game.Run();
        }
    }
}
