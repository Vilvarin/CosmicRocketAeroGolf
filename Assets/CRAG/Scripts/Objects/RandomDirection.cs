using UnityEngine;
using System.Collections;

namespace CRAG
{
    /// <summary>
    /// Скрипт для рандомно перемещающегося NavMeshAgent
    /// </summary>
    public class RandomDirection : MonoBehaviour
    {
        /// <summary>Объект, отмечающий границу возможного перемещения</summary>
        public Transform limit;

        private NavMeshAgent _agent;
        private float _radius;
        private Transform _transform;

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _radius = Mathf.Abs(limit.position.x);
            _transform = transform;
            StartCoroutine("Move");
        }

        IEnumerator Move()
        {
            while (true)
            {
                Vector3 point = new Vector3(Random.Range(0, _radius), 0, 0);
                Quaternion angle = Quaternion.Euler(0, Random.Range(0, 360 - Mathf.Epsilon), 0);
                point = angle * point;
                
                _agent.SetDestination(point);

                while (_agent.remainingDistance != 0)
                {
                    yield return null;
                }

                yield return null;
            }
        }
    }
}

