using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Implements the gun turret behaviour. See: <see cref="IGunTurret"/>.
    /// </summary>
    public class GunTurret : MonoBehaviour, IGunTurret
    {
        [SerializeField]
        private GunTower gunTower;

        [SerializeField]
        private float rotationVelocity = 100f;

        private Vector3? aimPoint;

        public IGun Gun => gunTower.Gun;

        public void AimAt(Vector3? targetPoint)
        {
            aimPoint = targetPoint;
            gunTower.AimAt(targetPoint);
        }

        private void Awake()
        {
            Assert.IsNotNull(gunTower, "The gun tower is not set.");
        }

        private void Update()
        {
            var localTargetAngle = CalcLocalTargetRotationAngle();
            var currentLocalTowerAngle = Vector3.SignedAngle(transform.forward, gunTower.transform.forward, transform.up);

            // Calc. offsets in both directions.
            var offsetA = localTargetAngle - currentLocalTowerAngle;
            var offsetB = currentLocalTowerAngle - localTargetAngle;

            // Select the direction which is closer, i.e. where the angle is smaller.
            var offset = Math.Abs(offsetA) < Math.Abs(offsetB) ? offsetA : offsetB;

            // Calc rotation step -- clamp abs. rotation step size by abs. offset.
            var upperBound = Math.Abs(offset);
            var lowerBound = -upperBound;
            var rotationStep = Mathf.Clamp(rotationVelocity * Time.deltaTime, lowerBound, upperBound);

            // Check / flip sign.
            if (rotationStep * offset >= 0)
            {
                rotationStep = -rotationStep;
            }

            gunTower.transform.Rotate(gunTower.transform.up, rotationStep);
        }

        private float CalcLocalTargetRotationAngle()
        {
            if (!aimPoint.HasValue)
            {
                return 0;
            }

            var targetVector = aimPoint.Value - transform.position;
            var targetAngle = Vector3.SignedAngle(transform.forward, targetVector, transform.up);

            return targetAngle;
        }
    }
}