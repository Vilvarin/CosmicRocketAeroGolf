using UnityEngine;
using System.Collections;

public class RotateAroundSun : MonoBehaviour {

    public float speed;    

	void FixedUpdate () {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
	}
}
