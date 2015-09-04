using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class DisappearedOnCollision : MonoBehaviour
    {
        public string tag = "Finish";

        void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.tag == tag)
                Destroy(gameObject);
        }        
    }
}

