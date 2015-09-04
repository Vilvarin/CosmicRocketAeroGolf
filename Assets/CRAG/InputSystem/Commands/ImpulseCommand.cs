using System;
using UnityEngine;

namespace CRAG.InputSystem
{
    public class ImpulseCommand : ICommand
    {
        public void Execute(GameActor actor)
        {
            actor.Impulse();
        }
    }
}

