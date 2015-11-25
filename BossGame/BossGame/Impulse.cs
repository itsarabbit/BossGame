using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    class Impulse
    {
        const float forceTime = 1.0f;
        AnimatedValue forceAmount;
        Vector2 forceDirection;

        public Impulse(Vector2 direction, float amount)
        {
            direction = Vector2.Normalize(direction);
            forceAmount = new AnimatedValue(forceTime, amount, AnimationType.Direct);
            forceAmount.Value = 0;
            forceDirection = direction;
        }

        /// <param name="direction">In radians</param>
        public Impulse(float direction, float amount)
        {
            forceAmount = new AnimatedValue(amount, AnimationType.Direct);
            forceAmount.Value = 0;
            forceDirection = new Vector2((float)Math.Cos(direction), (float)Math.Sin(direction));
        }

        public bool Update(ref Vector2 position)
        {
            position += (forceAmount.Value * forceDirection * TimeManager.DeltaTime) / forceTime;
            if (forceAmount.FinishedAnimation == true)
                return false;
            return true;
        }
    }
}
