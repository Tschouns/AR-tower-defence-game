using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Guns
{
    /// <summary>
    /// Implements the gun tower behaviour. See: <see cref="IGunTower"/>.
    /// </summary>
    public class GunTower : MonoBehaviour, IGunTower
    {
        [SerializeField]
        private Gun gun;

        private Vector3? aimPoint;

        public IGun Gun => gun;

        public void AimAt(Vector3? targetPoint)
        {
            aimPoint = targetPoint;
        }

        private void Awake()
        {
            Assert.IsNotNull(gun, "The gun is not set.");
        }

        private void Update()
        {
            // Cheap, crappy implementation...
            var targetElevation = CalcTargetElevationAngle();
            gun.transform.localRotation = Quaternion.Euler(targetElevation, 0, 0);
        }

        private float CalcTargetElevationAngle()
        {
            if (!aimPoint.HasValue)
            {
                return 0;
            }

            var targetVector = aimPoint.Value - gun.transform.position;
            var helperVector = new Vector3(targetVector.x, 0, targetVector.z);

            var targetElevationAngle = Vector3.Angle(helperVector, targetVector);
            if (targetVector.y > 0)
            {
                targetElevationAngle = -targetElevationAngle;
            }

            return targetElevationAngle;
        }
    }
}
