using Assets.Scripts.Guns;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyTank : MonoBehaviour, IEnemyTank
    {
        [SerializeField]
        private GunTurret gunTurret;

        [SerializeField]
        private Gun gun;

        private NavMeshAgent navAgent;

        private Transform currentTargetOrNull;
        private Vector3 lastPosition;

        public bool SetDestination(Vector3? destination)
        {
            if (destination.HasValue)
            {
                return navAgent.SetDestination(destination.Value);
            }

            // Stop.
            return navAgent.SetDestination(transform.position);
        }

        public void SetAttackTarget(Transform attackTargetOrNull)
        {
            currentTargetOrNull = attackTargetOrNull;
        }

        // Update is called once per frame
        private void Awake()
        {
            Assert.IsNotNull(gunTurret, "The gun turret is not set.");
            Assert.IsNotNull(gun, "The gun is not set.");

            navAgent = GetComponent<NavMeshAgent>();
            Assert.IsNotNull(navAgent, "The nav agent component was not found.");
            lastPosition = transform.position;
        }

        private void Update()
        {
            CorrectMovementToMimicTankDriving();
            gunTurret.AimAt(currentTargetOrNull?.position);

            gun.Shoot();
        }

        private void CorrectMovementToMimicTankDriving()
        {
            // Correct movement to mimic realisting tank driving, i.e. prevent sideways movement.
            var move = transform.position - lastPosition;
            var correctedMove = Vector3.Project(move, transform.forward);
            transform.position = lastPosition + correctedMove;

            lastPosition = transform.position;
        }
    }
}
