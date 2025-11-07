using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        Vector2 pos;
        Vector2 size;
        float speed;
        float jumpHeight;

        public Player(Vector2 pos, Vector2 size, float speed, float jumpHeight)
        {
            this.pos = pos;
            this.size = size;
            this.speed = speed;
            this.jumpHeight = jumpHeight;
        }


        public void Setup()
        {

        }
        public void Update()
        {

        }


    }
}