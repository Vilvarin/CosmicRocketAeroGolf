using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class DestroyerObject : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (!other.tag.Contains("UnDestroy"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}

