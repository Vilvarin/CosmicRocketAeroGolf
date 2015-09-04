using System;
using UnityEngine;
using CRAG.InputSystem;

namespace CRAG
{
    class GameActor : MonoBehaviour
    {
        public Camera cam;
        public GameObject click;
        public SearchCollider searchSphere;
        public float forceMagnitude;

        private Transform _transform;
        private Rigidbody _rigidbody;

        void Start()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Impulse()
        {
            Vector3 forceDirection = CalculateForceDirection();
            _rigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }

        public void EnterOrbit()
        {
            Collider detected = searchSphere.GetDetectedCollider();
            _transform.parent = detected.transform;

            Vector3 radius = _transform.parent.position - _transform.position;
            Vector3 tangent = new Vector3(-radius.z, 0, radius.x);
            _rigidbody.velocity = Vector3.Project(_rigidbody.velocity, tangent);
        }

        public void DescendFromOrbit()
        {
            _transform.parent = null;
        }
        
        private Vector3 CalculateForceDirection()
        {
            Vector3 forceDirection = Vector3.zero;
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Raycasting")))
            {
                forceDirection = _transform.position - hit.point;
                forceDirection.Normalize();
            }

            Instantiate(click, hit.point, Quaternion.identity);

            return forceDirection;
        }
    }
}
