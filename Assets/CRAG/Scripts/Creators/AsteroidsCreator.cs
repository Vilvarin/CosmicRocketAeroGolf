using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CRAG
{
    /// <summary>
    /// Фабрика астероидов. 
    /// Выпускает случайный префаб из списка. 
    /// Задает ему случайную скорость и направление.
    /// </summary>
    public class AsteroidsCreator : MonoBehaviour
    {
        ///<summary>Префабы для запуска.</summary>
        public List<GameObject> prefabs; 
        ///<summary>Время между запусками</summary>
        public float timeBetweenCreation = 30; 
        ///<summary>Количество астероидов, которые будут запущены</summary>
        public float count = 5; 

        void Start()
        {
            StartCoroutine("AddAsteroid");
        }

        IEnumerator AddAsteroid()
        {
            for (int i = 0; i < count; i++)
            {
                int RandPref = Random.Range(0, prefabs.Count - 1);

                Vector3 RandForce = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
                Vector3 RandTorque = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));

                GameObject instance = Instantiate(prefabs[RandPref], transform.position, Quaternion.identity) as GameObject;
                instance.GetComponent<Rigidbody>().AddForce(RandForce, ForceMode.Impulse);
                instance.GetComponent<Rigidbody>().AddTorque(RandTorque, ForceMode.Impulse);

                yield return new WaitForSeconds(timeBetweenCreation);
            }
        }
    }
}

