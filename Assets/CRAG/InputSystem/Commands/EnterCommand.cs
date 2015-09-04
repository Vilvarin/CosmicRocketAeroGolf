using UnityEngine;
using System;

namespace CRAG.InputSystem
{
    public class EnterCommand : ICommand
    {
        public void Execute(GameActor actor)
        {
            actor.EnterOrbit();
        }
    }
}

