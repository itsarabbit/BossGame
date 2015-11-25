using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    public static class TimeManager
    {
        private static float _deltaTime, timeMultiply = 1.0f;
        public static float CurrentTime = 0;

        public static float DeltaTime
        {
            get { return _deltaTime*timeMultiply; }
        }

        public static float RealDelta
        {
            get { return _deltaTime; }
        }

        public static void Update(float deltaTime)
        {
            _deltaTime = deltaTime;
            CurrentTime += deltaTime;
        }
    }
}
