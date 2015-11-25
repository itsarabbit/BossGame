using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    class PhysicsObject : Entity
    {
        public Vector2 Velocity;
        private Impulse impulse;
        public PhysicsObject(Vector2 Position)
            :base(Position)
        {

        }

        public void Push(Impulse impulse)
        {
            //impulse = 
        }

        public override void Update()
        {
            impulse.Update(ref Position);
            Position += Velocity;
        }

        public override void Draw()
        {
            DrawManager.SpriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, 32f, SpriteEffects.None, 0f);
        }
    }
}
