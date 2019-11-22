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
            Game game = new Game(1280, 760, "Graphical Test Application");

            Actor root = new Actor();
            game.Root = root;

            //## Set up game here ##//
            Player player = new Player(640,380);
            Enemy enemy = new Enemy(300, 100);

            root.AddChild(enemy);
            root.AddChild(player);

            game.Run();
        }
    }
}
