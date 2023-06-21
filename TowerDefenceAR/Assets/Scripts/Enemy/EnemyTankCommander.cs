using Assets.Scripts.Battle;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(EnemyTank))]
    public class EnemyTankCommander : MonoBehaviour, IEnemyTankCommander
    {
        [SerializeField]
        private GameObject destinationIndicator;

        private IEnemyTank tank;
        private IUnitProvider unitProvider;
        private IUnit attackTargetUnit;
        private bool needNewDestination = false;

        public void Initialize(IUnitProvider unitProvider)
        {
            this.unitProvider = unitProvider;
        }

        public void AssignAttackTarget(IUnit targetUnit)
        {
            attackTargetUnit = targetUnit;
        }

        private void Awake()
        {
            tank = GetComponent<EnemyTank>();
            Assert.IsNotNull(tank, "The tank component was not found.");

            needNewDestination = true;
        }

        private void Start()
        {
            Assert.IsNotNull(unitProvider);
        }

        private void Update()
        {
            if (attackTargetUnit == null ||
                !attackTargetUnit.IsAlive)
            {
                SelectNewAttackTarget();
            }

            if (attackTargetUnit != null && needNewDestination)
            {
                // Determine destination.
                var distanceFactor = Random.Range(0.5f, 1.0f);
                var referencePoint = (transform.position - attackTargetUnit.Position).normalized * tank.AttackRange * distanceFactor;
                var angleOfAttack = Random.Range(Mathf.Deg2Rad * -120f, Mathf.Deg2Rad * 120f);
                var destination = attackTargetUnit.Position + (Quaternion.AngleAxis(angleOfAttack, Vector3.up) * referencePoint);

                tank.SetDestination(destination);

                if (destinationIndicator != null)
                {
                    destinationIndicator.SetActive(true);
                    destinationIndicator.transform.SetParent(transform.parent);
                    destinationIndicator.transform.position = destination;
                }

                // Determine attack point.
                tank.SetAttackTarget(attackTargetUnit.GetAttackPoint());

                // Set time to change position.
                var timeToRelocate = Random.Range(3f, 15f);
                StartCoroutine(ChangePositionAfter(timeToRelocate));
            }
        }

        private void SelectNewAttackTarget()
        {
            var units = unitProvider.GetAlivePlayerUnits();
            if (!units.Any())
            {
                return;
            }

            attackTargetUnit = units[Random.Range(0, units.Count)];
            needNewDestination = true;
        }

        private IEnumerator ChangePositionAfter(float seconds)
        {
            needNewDestination = false;
            yield return new WaitForSeconds(seconds);
            needNewDestination = true;
            yield return null;
        }
    }
}
