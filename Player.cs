using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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
        float Gravity = 200f;
        float Velocity = 0f;
        bool isOnFloor = false;
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
        public void Update(Platform[] platforms)
        {
            DrawPlayer();
            SimulateGravity();
            Collision(platforms);
            Movement();
        }
        public void DrawPlayer()
        {
            Draw.FillColor = Color.Green;
            Draw.Rectangle(pos.X, pos.Y, size.X, size.Y);
        }
        public void SimulateGravity()
        {
            //apply gravity
            Velocity += Gravity * Time.DeltaTime;
            //move player
            pos.Y += Velocity * Time.DeltaTime;
        }
        public void Collision(Platform[] platforms)
        {
            float playerTop = pos.Y;
            float playerBottom = pos.Y + size.Y;
            float playerLeft = pos.X;
            float playerRight = pos.X + size.X;

            // --- Screen boundaries ---
            if (playerTop <= 0)
            {
                pos.Y = 0;
                Velocity = 0f;
            }

            if (playerBottom >= 600)
            {
                pos.Y = 600 - size.Y;
                Velocity = 0f;
                isOnFloor = true;
            }

            if (playerLeft <= 0)
                pos.X = 0;

            if (playerRight >= 800)
                pos.X = 800 - size.X;

            //Platform collision
            for (int i = 0; i < platforms.Length; i++)
            {
                Platform platfrom = platforms[i];

                float platformTop = platfrom.pos.Y;
                float platformBottom = platfrom.pos.Y + platfrom.size.Y;
                float platformLeft = platfrom.pos.X;
                float platformRight = platfrom.pos.X + platfrom.size.X;

                //are they inside of eachother
                bool isColliding = playerRight > platformLeft && playerLeft < platformRight && playerBottom > platformTop && playerTop < platformBottom;

                if (isColliding)
                {
                    //top of platform to bottom of player (hardest one to figure out, first one done)
                    if (playerBottom >= platformTop && playerTop < platformTop && Velocity > 0)
                    {
                        pos.Y = platformTop - size.Y;
                        Velocity = 0;
                        isOnFloor = true;
                    }
                    //bottom of platform to top of player
                    else if (playerTop <= platformBottom && playerBottom > platformBottom && Velocity < 0)
                    {
                        pos.Y = platformBottom;
                        Velocity = 0;
                    }
                    //left of platform to right of player
                    else if (playerRight >= platformLeft && playerLeft < platformLeft)
                    {
                        pos.X = platformLeft - size.X;
                    }
                    //right of platform to left of player
                    else if (playerLeft <= platformRight && playerRight > platformRight)
                    {
                        pos.X = platformRight;
                    }
                }
            }
            //hit box collision

        }
        public void Movement()
        {
            //player movement
            if (Input.IsKeyboardKeyPressed(KeyboardInput.W) && isOnFloor)
            {
                Velocity -= jumpHeight;
                isOnFloor = false;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                pos.X -= speed;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                pos.X += speed;
            }
        }
    }
}
