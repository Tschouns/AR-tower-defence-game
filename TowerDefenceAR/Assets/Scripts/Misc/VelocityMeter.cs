using System;
using UnityEngine;

namespace Assets.Scripts.Misc
{
    public class VelocityMeter : MonoBehaviour, ILinearVelocityMeter, IAngularVelocityMeter
    {
        private Vector3 lastPosition;
        private Quaternion lastRotation;

        private float currentLinearVelocity = 0;
        private float currentAngularVelocity = 0;

        public float CurrentLinearVelocity => currentLinearVelocity;
        public float CurrentAngularVelocity => currentAngularVelocity;

        private void Start()
        {
            lastPosition = transform.position;
        }

        // Update is called once per frame
        private void Update()
        {
            var deltaTimeSafe = Time.deltaTime + 0.00000001f;

            // Calc. for the current frame.
            var deltaDistance = transform.position - lastPosition;
            currentLinearVelocity = deltaDistance.magnitude / deltaTimeSafe;

            var deltaEurerAngles = transform.rotation.eulerAngles - lastRotation.eulerAngles;
            currentAngularVelocity =
                 (Math.Abs(deltaEurerAngles.x)
                + Math.Abs(deltaEurerAngles.y)
                + Math.Abs(deltaEurerAngles.z))
                / deltaTimeSafe;

            lastPosition = transform.position;
            lastRotation = transform.rotation;
        }
    }
}