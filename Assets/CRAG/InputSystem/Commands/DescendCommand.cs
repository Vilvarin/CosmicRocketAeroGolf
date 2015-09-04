using UnityEngine;
using System.Collections;

namespace CRAG.InputSystem
{
    public class DescendCommand : ICommand
    {
        public void Execute(GameActor actor)
        {
            actor.DescendFromOrbit();
        }
    }
}
