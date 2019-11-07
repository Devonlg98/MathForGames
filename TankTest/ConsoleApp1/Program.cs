using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib.Raylib;
using Raylib;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Game game = new Game();
            MyShape shape = new MyShape();
            InitWindow(640, 480, "Tanks for Everything!");
            game.Init();
            while (!WindowShouldClose())
            {
                game.Update();
                game.Draw();
            }
            game.Shutdown();
            CloseWindow();
        }
    }
}
