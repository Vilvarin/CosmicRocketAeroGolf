using System;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace UnityStandardAssets.Cameras
{
    [ExecuteInEditMode]
    public class MyCam : PivotBasedCameraRig
    {
        [SerializeField]
        private float m_MoveSpeed = 10; // How fast the rig will move to keep up with target's position

        private float m_LastFlatAngle; // The relative angle of the target and the rig from the previous frame.
        private Vector3 m_RollUp = Vector3.up;// The roll of the camera around the z axis ( generally this will always just be up )


        protected override void FollowTarget(float deltaTime)
        {
            if (!(deltaTime > 0) || m_Target == null)
            {
                return;
            }

            var targetForward = m_Target.forward;
            var targetUp = m_Target.up;

            var currentFlatAngle = Mathf.Atan2(targetForward.x, targetForward.z) * Mathf.Rad2Deg;
            m_LastFlatAngle = currentFlatAngle;

            transform.position = Vector3.Lerp(transform.position, m_Target.position, deltaTime * m_MoveSpeed);

            var rollRotation = Quaternion.LookRotation(targetForward, m_RollUp);
        }
    }
}
