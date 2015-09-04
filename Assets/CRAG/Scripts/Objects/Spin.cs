using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class Spin : MonoBehaviour
    {
        public float speed;

        void Update()
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}
