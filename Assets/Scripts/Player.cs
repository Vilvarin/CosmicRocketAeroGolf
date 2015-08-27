using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 100);
        //Grap(firstCoupling);
    }

    /*void Update()
    {
        
    }

    void FindObjectForCoupling() 
    {
        
    }

    void Grap(GameObject obj)
    {
        coupling = true;

    }*/
}
