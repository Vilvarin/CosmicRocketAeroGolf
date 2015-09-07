using System;
using UnityEngine;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Задать импульс шайбе.
    /// </summary>
    public class ImpulseCommand : ICommand<GameActor>
    {
        public void Execute(GameActor actor)
        {
            actor.Impulse();
        }
    }
}

