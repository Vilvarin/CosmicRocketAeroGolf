using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для вращения объекта вокруг оси
    /// </summary>
    public class Spin : MonoBehaviour
    {
        /// <summary>Скорость вращения</summary>
        public float speed;

        void Update()
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}
