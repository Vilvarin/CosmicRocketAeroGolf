using UnityEngine;
using System;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Команда "Выйти на орбиту".
    /// </summary>
    public class EnterCommand : ICommand<GameActor>
    {
        public void Execute(GameActor actor)
        {
            actor.EnterOrbit();
        }
    }
}

