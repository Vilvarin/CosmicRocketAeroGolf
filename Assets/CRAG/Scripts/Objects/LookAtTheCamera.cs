using UnityEngine;
using System.Collections;

public class LookAtTheCamera : MonoBehaviour
{
    public Transform cam;

    void Update()
    {
        transform.LookAt(cam);
        transform.Rotate(Vector3.up, 180f);
    }
}
