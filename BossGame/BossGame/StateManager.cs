using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossGame
{
    public static class StateManager
    {
        private static Stack<State> stateStack = new Stack<State>();

        public static State CurrentState
        {
            get { return stateStack.Peek(); }
        }

        public static void PushState(State state)
        {
            stateStack.Push(state);
        }

        public static void PopState()
        {
            stateStack.Pop();
        }

        public static void ChangeState(State state)
        {
            stateStack.Pop();
            stateStack.Push(state);
        }

        public static void Update()
        {
            CurrentState.Update();
        }

        public static void Draw()
        {
            DrawManager.SpriteBatch.Begin();
            CurrentState.Draw();
            DrawManager.SpriteBatch.End();
        }
    }
}
