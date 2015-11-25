using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    abstract public class State
    {
        public List<Entity> entityList = new List<Entity>();
        public abstract void Draw();
        public abstract void Update();
    }
}
