using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    class BattleState : State
    {
        public BattleState()
            :base()
        {
            entityList.Add(new PhysicsObject(new Vector2(0.5f, 0.5f)));
            //((PhysicsObject)entityList[0]).Push(new Impulse(new Vector2(1.0f, 0.0f), 800f, 2.0f));
            ((PhysicsObject)entityList[0]).Push(new Impulse(800f, 1.0f));
            ((PhysicsObject)entityList[0]).Push(new Impulse(-400f, 2.0f));

        }

        public override void Update()
        {
            for(int i = 0; i < entityList.Count; i++)
            {
                entityList[i].Update();
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < entityList.Count; i++)
            {
                entityList[i].Draw();
            }
        }
    }
}
