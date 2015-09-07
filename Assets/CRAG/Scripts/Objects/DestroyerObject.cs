using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт, для объекта, уничтожающего любой другой объект при встрече.
    /// </summary>
    public class DestroyerObject : MonoBehaviour
    {
        /// <summary>Отметка для неуничтожаемых объектов</summary>
        public string ignoredTag = "UnDestroy";

        void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
                GameManager.instance.GameOver();
            else if (!other.tag.Contains(ignoredTag))
                Destroy(other.gameObject);
        }
    }
}

