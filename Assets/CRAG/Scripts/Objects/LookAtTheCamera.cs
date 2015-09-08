using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для разворота объекта к камере.
    /// </summary>
    public class LookAtTheCamera : MonoBehaviour
    {
        /// <summary>Камера в которую будем смотреть</summary>
        public Transform cam;

        void Update()
        {
            transform.LookAt(cam);
            transform.Rotate(Vector3.up, 180f);
        }
    }
}

