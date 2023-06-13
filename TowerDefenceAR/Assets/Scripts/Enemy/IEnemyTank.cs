using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemyTank
    {
        public float AttackRange { get; }

        public bool SetDestination(Vector3? destination);

        public void SetAttackTarget(Vector3? attackTargetOrNull);
    }
}
