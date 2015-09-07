using UnityEngine;
using System.Collections;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Начать уровень сначала.
    /// </summary>
    public class RestartCommand : ICommand
    {
        public void Execute()
        {
            GameManager.instance.Restart();
        }
    }
}

