using System;
using System.Collections.Generic;
using System.Text;

namespace Battleships
{
    interface IGame
    {
        /// <summary>
        /// Transitions to a new scene
        /// </summary>
        /// <param name="scene">The new scene</param>
        void TransitionTo(Scene scene);
        void Exit();
    }
}