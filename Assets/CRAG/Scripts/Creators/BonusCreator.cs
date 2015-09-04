using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class BonusCreator : MonoBehaviour
    {
        public GameObject coin;
        public float radius;
        public int count;

        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();

            for (int i = 0; i < count; i++)
            {
                Transform instance = Instantiate(coin).GetComponent<Transform>();
                instance.parent = _transform;

                instance.localPosition = new Vector3(radius, 0, 0);
                float angle = 360f / count;
                Quaternion q = Quaternion.Euler(0, (float)i * angle, 0);
                instance.localPosition = q * instance.localPosition;
            }
        }
    }
}

