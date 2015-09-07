using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для объектов самоуничтожающихся при встрече с отмеченным объектом.
    /// </summary>
    public class DisappearedOnCollision : MonoBehaviour
    {
        /// <summary>Отметка для объектов при встрече с которыми следует уничтожиться</summary>
        public string ColliderTag = "Finish";

        void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == ColliderTag)
                Destroy(gameObject);
        }        
    }
}

