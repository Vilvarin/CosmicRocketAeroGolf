using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsCreator : MonoBehaviour
{
    public List<GameObject> prefabs;
    public float timeBetweenCreation;

    void Start()
    {
        StartCoroutine("AddAsteroid");
    }

    IEnumerator AddAsteroid()
    {
        for (int i = 0; i < 5; i++)
        {
            int RandPref = Random.Range(0, prefabs.Count - 1);

            Vector3 RandForce = new Vector3(Random.RandomRange(-20f, 20f), 0, Random.RandomRange(-20f, 20f));
            Vector3 RandTorque = new Vector3(Random.RandomRange(-2f, 2f), Random.RandomRange(-2f, 2f), Random.RandomRange(-2f, 2f));

            GameObject instance = Instantiate(prefabs[RandPref], transform.position, Quaternion.identity) as GameObject;
            instance.GetComponent<Rigidbody>().AddForce(RandForce, ForceMode.Impulse);
            instance.GetComponent<Rigidbody>().AddTorque(RandTorque, ForceMode.Impulse);

            yield return new WaitForSeconds(timeBetweenCreation);
        }
    }
}
