using UnityEngine;
using System.Collections;

namespace CRAG
{
    public class CometCreator : MonoBehaviour
    {
        public GameObject comet;

        public float XFactor;
        public float ZFactor;

        void Start()
        {
            StartCoroutine("Wait");
        }

        IEnumerator Wait()
        {
            while (true)
            {
                yield return new WaitForSeconds(20);
                LaunchComet();
            }
        }

        void LaunchComet()
        {
            GameObject instance = Instantiate(comet, transform.position, Quaternion.identity) as GameObject;

            Rigidbody instComet = instance.GetComponent<Rigidbody>();
            instComet.velocity = new Vector3(ZFactor, 0, 2 * XFactor * XFactor);
            ConstantForce force = instance.GetComponent<ConstantForce>();
            force.force = new Vector3(0, 0, -XFactor);
        }
    }
}

