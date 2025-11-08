// Include the namespaces (code libraries) you need below.
using System;
using System.Drawing;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Player player = new Player(new Vector2(50, 50), new Vector2(10, 10), 2, 100);
        Platform[] platforms = { new Platform(new Vector2(0, 100), new Vector2(150, 100)) };

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.Black);
            player.Update(platforms);
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].Update();
            }
        }
    }

}