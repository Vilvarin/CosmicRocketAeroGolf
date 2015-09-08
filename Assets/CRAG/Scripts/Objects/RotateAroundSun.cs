using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для объектов, вращающихся вокруг нулевой точки мировых координат
    /// </summary>
    public class RotateAroundSun : MonoBehaviour
    {
        /// <summary>Скорость вращения</summary>
        public float speed;

        void FixedUpdate()
        {
            transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        }
    }
}
