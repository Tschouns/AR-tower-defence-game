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
            var enemies = unitProvider.GetEnemyTanks();

            if (enemies.Any())
            {
                for (var i = 0; i < defenceTurrets.Count; i++)
                {
                    defenceTurrets[i].AssignAttackTarget(enemies[i % enemies.Count]);
                }
            }
            else
            {
                defenceTurrets.ForEach(t => t.AssignAttackTarget(null));
            }
        }
    }
}
