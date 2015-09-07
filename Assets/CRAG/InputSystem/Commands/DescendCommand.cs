using UnityEngine;
using System.Collections;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Команда "сойти с орбиты".
    /// </summary>
    public class DescendCommand : ICommand<GameActor>
    {
        public void Execute(GameActor actor)
        {
            actor.DescendFromOrbit();
        }
    }
}
