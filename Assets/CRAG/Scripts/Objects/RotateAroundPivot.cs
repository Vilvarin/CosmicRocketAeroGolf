using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для объектов вращающихся вокруг родителя
    /// </summary>
    public class RotateAroundPivot : MonoBehaviour
    {
        private Transform _parent;
        private Transform _transform;

        /// <summary>Скорость вращения</summary>
        public float speed;

        void Start()
        {
            _transform = GetComponent<Transform>();
            _parent = _transform.parent;
        }

        void Update()
        {
            _transform.position = Quaternion.Euler(0, speed * Time.deltaTime, 0) * (_transform.position - _parent.position) + _parent.position;
        }
    }
}
