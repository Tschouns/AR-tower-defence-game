using Assets.Scripts.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Defence
{
    [RequireComponent(typeof(UnitManager))]
    public class DefenceManager : MonoBehaviour, IDefenceTurretRegistry
    {
        private readonly List<DefenceTurret> defenceTurrets = new List<DefenceTurret>();
        private IUnitProvider unitProvider;

        [SerializeField]
        private DefenceTurret[] knownDefenceTurrets;

        public void RegisterDefenceTurret(DefenceTurret defenceTurret)
        {
            Assert.IsNotNull(defenceTurret);
            defenceTurrets.Add(defenceTurret);
        }

        private void Awake()
        {
            unitProvider = GetComponent<UnitManager>();
            Assert.IsNotNull(unitProvider);

            if (knownDefenceTurrets != null)
            {
                Array.ForEach(knownDefenceTurrets, defenceTurrets.Add);
            }
        }

        private void Update()
        {
            var enemies = unitProvider.GetAliveEnemyTanks();

            foreach (var turret in defenceTurrets)
            {
                var closestEnemyInRange = enemies
                    .Where(e => IsInAttackRangeOf(e, turret))
                    .OrderBy(e => (e.Position - turret.Position).sqrMagnitude)
                    .FirstOrDefault();

                turret.AssignAttackTarget(closestEnemyInRange);
            }
        }

        private static bool IsInAttackRangeOf(IUnit target, IUnit attacker)
        {
            return (target.Position - attacker.Position).sqrMagnitude < (attacker.AttackRange * attacker.AttackRange);
        }
    }
}
