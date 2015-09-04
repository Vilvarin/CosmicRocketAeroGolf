using System;
using UnityEngine;
using CRAG;

namespace CRAG.InputSystem
{
    public interface ICommand
    {
        void Execute(GameActor actor);
    }
}

