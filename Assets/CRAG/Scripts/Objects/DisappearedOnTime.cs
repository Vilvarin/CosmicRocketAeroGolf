using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class DisappearedHalo : MonoBehaviour
    {
        public float timer = 1;

        void Update()
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

