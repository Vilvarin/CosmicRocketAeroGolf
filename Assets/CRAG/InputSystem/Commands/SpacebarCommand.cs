using UnityEngine;
using System.Collections;

namespace CRAG.InputSystem
{
    /// <summary>
    /// Скрыть модальное окно
    /// </summary>
    public class ClosePanelCommand : ICommand
    {
        public void Execute()
        {
            UIManager.instance.ClosePanel();
        }
    }
}

