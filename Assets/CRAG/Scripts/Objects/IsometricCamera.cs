using System;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace UnityStandardAssets.Cameras
{
    [ExecuteInEditMode]
    public class IsometricCamera : PivotBasedCameraRig
    {
        [SerializeField]
        private float m_MoveSpeed = 10; // How fast the rig will move to keep up with target's position

        protected override void FollowTarget(float deltaTime)
        {
            if (!(deltaTime > 0) || m_Target == null)
                return;

            transform.position = Vector3.Lerp(transform.position, m_Target.position, deltaTime * m_MoveSpeed);
        }
    }
}
