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
        Player player = new Player(new Vector2(50, 50), new Vector2(10, 10), 1, 100);
        Platform[] platforms = { new Platform(new Vector2(0, 100), new Vector2(150, 100)), new Platform(new Vector2(180, 100), new Vector2(30, 30)),
                                new Platform(new Vector2(240, 100), new Vector2(30, 30)), new Platform(new Vector2(300, 100), new Vector2(30, 30)),
                                new Platform(new Vector2(360, 100), new Vector2(90, 100)), new Platform(new Vector2(480, 100), new Vector2(30, 30)),
                                new Platform(new Vector2(540, 100), new Vector2(30, 30)), new Platform(new Vector2(600, 100), new Vector2(100, 100)),
                                new Platform(new Vector2(700, 300), new Vector2(100, 100)), new Platform(new Vector2(500, 350), new Vector2(50, 50)),
                                new Platform(new Vector2(500, 400), new Vector2(100, 50)), new Platform(new Vector2(550, 500), new Vector2(250, 100)),
                                new Platform(new Vector2(490, 500), new Vector2(30, 30)), new Platform(new Vector2(430, 500), new Vector2(30, 30)),
                                new Platform(new Vector2(370, 500), new Vector2(30, 30)), new Platform(new Vector2(310, 500), new Vector2(30, 30)),
                                new Platform(new Vector2(250, 500), new Vector2(30, 30)), new Platform(new Vector2(190, 500), new Vector2(30, 30)),
                                new Platform(new Vector2(130, 500), new Vector2(30, 30)), new Platform(new Vector2(0, 500), new Vector2(100, 100))};
        HitBox[] HitBoxes = { new HitBox(new Vector2(150, 180), new Vector2(210, 20), true, Color.Red), new HitBox(new Vector2(450, 180), new Vector2(150, 20), true, Color.Red),
                            new HitBox(new Vector2(650, 380), new Vector2(50, 20), true, Color.Red), new HitBox(new Vector2(100, 580), new Vector2(450, 20), true, Color.Red),
                            new HitBox(new Vector2(20, 470), new Vector2(30, 30), false, Color.Yellow)};
        public static bool Win = false;
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
            if (Win == false)
            {
                Window.ClearBackground(Color.Black);
                player.Update(platforms, HitBoxes);
                for (int i = 0; i < platforms.Length; i++)
                {
                    platforms[i].Update();
                }
                for (int i = 0; i < HitBoxes.Length; i++)
                {
                    HitBoxes[i].Update();
                }
            }
            if (Win == true)
            {
                Window.ClearBackground(Color.Green);
            }
        }
    }

}