using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    public abstract class Entity
    {
        public Vector2 Position;
        public Texture2D Texture;

        public Entity(Vector2 Position)
        {
            this.Position = Position;
            Texture = DrawManager.Content.Load<Texture2D>("Pixel.png");
        }

        public virtual void Draw()
        {
            DrawManager.SpriteBatch.Draw(Texture, Position, Color.White);
        }

        public abstract void Update();
    }
}
