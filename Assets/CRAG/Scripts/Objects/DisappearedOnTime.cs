using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для объектов уничтожающихся по истечении времени.
    /// </summary>
    public class DisappearedOnTime : MonoBehaviour
    {
        /// <summary>Таймер, по истечении которого объект будет уничтожен</summary> 
        public float timer = 1;

        void Update()
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }

            timer -= Time.deltaTime;
        }
    }
}

