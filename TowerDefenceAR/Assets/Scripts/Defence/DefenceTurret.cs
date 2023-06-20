using Assets.Scripts.Battle;
using Assets.Scripts.Building;
using Assets.Scripts.Damage;
using Assets.Scripts.Guns;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Defence
{
    [RequireComponent(typeof(Health))]
    [RequireComponent(typeof(GunTurret))]
    [RequireComponent(typeof(BuildingUnit))]
    public class DefenceTurret : MonoBehaviour, IUnit, IDefenceTurretCommander
    {
        private IHealth health;
        private IGunTurret gunTurret;
        private IUnit buildingUnit;
        private IUnit attackTargetUnit;

        public float AttackRange => buildingUnit.AttackRange;
        public bool IsAlive => health.IsAlive;
        public Vector3 Position => buildingUnit.Position;


        public Vector3 GetAttackPoint() => buildingUnit.GetAttackPoint();

        public void AssignAttackTarget(IUnit targetUnit)
        {
            attackTargetUnit = targetUnit;
        }

        private void Awake()
        {
            health = GetComponent<Health>();
            gunTurret = GetComponent<GunTurret>();
            buildingUnit = GetComponent<BuildingUnit>();

            Assert.IsNotNull(health, "The health component was not found.");
            Assert.IsNotNull(gunTurret, "The gun turret component was not found.");
            Assert.IsNotNull(buildingUnit, "The building unit component was not found.");
        }

        private void Update()
        {
            if (!health.IsAlive)
            {
                return;
            }

            gunTurret.AimAt(attackTargetUnit?.GetAttackPoint());

            if (attackTargetUnit != null &&
                (attackTargetUnit.Position - Position).magnitude < AttackRange * 1.1f)
            {
                gunTurret.Gun.Shoot();
            }
        }
    }
}