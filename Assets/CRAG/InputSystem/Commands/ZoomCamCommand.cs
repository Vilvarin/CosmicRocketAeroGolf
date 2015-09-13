using UnityEngine;
using System.Collections;
using UnityStandardAssets.Cameras;

namespace CRAG.InputSystem
{
    public class ZoomCamCommand : ICommand<IsometricCamera>
    {
        /// <summary>Значение оси колесика мыши, передаваемое классом Input</summary>
        private float _scroll;
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="scroll">Значение оси колесика мыши, передаваемое классом Input</param>
        public ZoomCamCommand(float scroll)
        {
            this._scroll = scroll;
        }

        public void Execute(IsometricCamera actor)
        {
            actor.Zoom(_scroll);
        }
    }
}

