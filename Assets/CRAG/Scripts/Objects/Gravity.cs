using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class Gravity : MonoBehaviour
    {
        public float gravityTime;

        private Transform _transform;

        void Start()
        {
            _transform = GetComponent<Transform>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.name == "Player")
            {
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                StartCoroutine("DragIn", other.transform);
            }
        }

        IEnumerator DragIn(Transform other)
        {
            Vector3 pos = other.position;
            float t = 0;

            while (t < gravityTime)
            {
                other.position = Vector3.Lerp(pos, _transform.position, t / gravityTime);
                t += Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject.GetComponent<Rigidbody>());

            if (other.name == "Player")
                GameManager.instance.Win();
        }
    }
}

