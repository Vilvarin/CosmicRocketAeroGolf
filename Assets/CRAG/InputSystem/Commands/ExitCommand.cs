using UnityEngine;
using System.Collections;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Выйти из приложения.
    /// </summary>
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Application.Quit();
        }
    }
}
