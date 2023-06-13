using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemyTank
    {
        public bool SetDestination(Vector3? destination);

        public void SetAttackTarget(Transform attackTargetOrNull);
    }
}
