using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class HitBox
    {
        public Vector2 pos;
        public Vector2 size;
        public bool bad;
        Color color;
        public HitBox(Vector2 pos, Vector2 size, bool bad, Color color)
        {
            this.pos = pos;
            this.size = size;
            this.bad = bad;
            this.color = color;
        }

        public void Update()
        {
            DrawHitBox();
        }
        public void DrawHitBox()
        {
            Draw.FillColor = color;
            Draw.Rectangle(pos, size);
        }
    }
}