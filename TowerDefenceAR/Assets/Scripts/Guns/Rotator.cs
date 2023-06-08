using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// TODO: remove?
    /// </summary>
    public class Rotator
    {
        private readonly Transform baseTransform;
        private readonly Transform rotatedTransform;
        private readonly Func<Transform, Vector3> getRotationAxis;
        private readonly Func<float, float> checkLocalTargetAngle;
        private readonly Func<float> getRotationVelocity;

        public Rotator(
            Transform baseTransform,
            Transform rotatedTransform,
            Func<Transform, Vector3> getRotationAxis,
            Func<float, float> checkLocalTargetAngle,
            Func<float> getRotationVelocity)
        {
            Assert.IsNotNull(baseTransform);
            Assert.IsNotNull(rotatedTransform);
            Assert.IsNotNull(getRotationAxis);
            Assert.IsNotNull(checkLocalTargetAngle);
            Assert.IsNotNull(getRotationVelocity);

            this.baseTransform = baseTransform;
            this.rotatedTransform = rotatedTransform;
            this.getRotationAxis = getRotationAxis;
            this.checkLocalTargetAngle = checkLocalTargetAngle;
            this.getRotationVelocity = getRotationVelocity;
        }

        public void Update(float deltaTime, Vector3? aimPoint)
        {
            var rotationAxis = getRotationAxis(rotatedTransform);
            var localTargetAngle = CalcLocalTargetRotationAngle(aimPoint, rotationAxis);
            localTargetAngle = checkLocalTargetAngle(localTargetAngle);
            var currentLocalTowerAngle = Vector3.SignedAngle(baseTransform.forward, rotatedTransform.forward, rotationAxis);

            // Calc. offsets in both directions.
            var offsetA = localTargetAngle - currentLocalTowerAngle;
            var offsetB = currentLocalTowerAngle - localTargetAngle;

            // Select the direction which is closer, i.e. where the angle is smaller.
            var offset = Math.Abs(offsetA) < Math.Abs(offsetB) ? offsetA : offsetB;

            // Calc rotation step -- clamp abs. rotation step size by abs. offset.
            var upperBound = Math.Abs(offset);
            var lowerBound = -upperBound;
            var rotationStep = Mathf.Clamp(getRotationVelocity() * deltaTime, lowerBound, upperBound);

            // Check / flip sign.
            if (rotationStep * offset >= 0)
            {
                rotationStep = -rotationStep;
            }

            rotatedTransform.Rotate(rotationAxis, rotationStep);
        }

        private float CalcLocalTargetRotationAngle(Vector3? aimPoint, Vector3 rotationAxis)
        {
            if (!aimPoint.HasValue)
            {
                return 0;
            }

            var targetVector = aimPoint.Value - rotatedTransform.position;
            var targetAngle = Vector3.SignedAngle(baseTransform.forward, targetVector, rotationAxis);

            return targetAngle;
        }
    }
}
