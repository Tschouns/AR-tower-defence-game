using Assets.Scripts.Battle;
using Assets.Scripts.Damage;
using Assets.Scripts.Guns;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Health))]
    public class EnemyTank : MonoBehaviour, IEnemyTank, IUnit
    {
        [SerializeField]
        private GunTurret gunTurret;

        [SerializeField]
        private Gun gun;

        [SerializeField]
        private float attackRange = 0.4f;

        private IHealth health;
        private NavMeshAgent navAgent;

        private Vector3? currentTargetOrNull;
        private Vector3 lastPosition;

        public bool IsAlive => health.IsAlive;
        public float AttackRange => attackRange;

        public Vector3 Position => transform.position;

        public Vector3 GetAttackPoint()
        {
            return transform.position + transform.up * 0.05f;
        }

        public bool SetDestination(Vector3? destination)
        {
            if (destination.HasValue)
            {
                return navAgent.SetDestination(destination.Value);
            }

            // Stop.
            return navAgent.SetDestination(transform.position);
        }

        public void SetAttackTarget(Vector3? attackTargetOrNull)
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

            health = GetComponent<Health>();
            Assert.IsNotNull(health, "The health component was not found.");

            health.OnDied += () => navAgent.isStopped = true;

            lastPosition = transform.position;
        }

        private void Update()
        {
            if (!health.IsAlive)
            {
                return;
            }

            CorrectMovementToMimicTankDriving();
            gunTurret.AimAt(currentTargetOrNull);

            if (currentTargetOrNull.HasValue &&
                (currentTargetOrNull.Value - Position).magnitude < attackRange * 1.1f)
            {
                gun.Shoot();
            }
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
