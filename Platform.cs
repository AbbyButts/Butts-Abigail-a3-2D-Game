using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Platform
    {
        public Vector2 pos;
        public Vector2 size;

        public Platform(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }

        public void Update()
        {
            DrawPlatform();
        }
        public void DrawPlatform()
        {
            Draw.FillColor = Color.Blue;
            Draw.Rectangle(pos, size);
        }
    }
}