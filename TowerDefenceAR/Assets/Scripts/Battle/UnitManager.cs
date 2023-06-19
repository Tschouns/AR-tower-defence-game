using Assets.Scripts.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Battle
{
    /// <summary>
    /// Registers and keeps track of all the units on the battlefield.
    /// </summary>
    public class UnitManager : MonoBehaviour, IUnitProvider, IPlayerUnitRegistry, IEnemyUnitRegistry
    {
        private readonly List<IUnit> playerUnits = new List<IUnit>();
        private readonly List<IUnit> enemyUnits = new List<IUnit>();

        [SerializeField]
        private BuildingUnit[] knownBuildings;

        public IReadOnlyList<IUnit> GetAlivePlayerUnits()
        {
            return playerUnits;
        }

        public IReadOnlyList<IUnit> GetAliveEnemyTanks()
        {
            return enemyUnits;
        }

        public void RegisterPlayerUnit(IUnit unit)
        {
            playerUnits.Add(unit);
        }

        public void RegisterEnemyUnit(IUnit unit)
        {
            enemyUnits.Add(unit);
        }

        private void Awake()
        {
            if (knownBuildings != null)
            {
                Array.ForEach(knownBuildings, playerUnits.Add);
            }
        }

        private void Update()
        {
            RemoveDeadUnits(playerUnits);
            RemoveDeadUnits(enemyUnits);
        }

        private void RemoveDeadUnits(IList<IUnit> units)
        {
            foreach (var dead in units.Where(u => !u.IsAlive).ToList())
            {
                units.Remove(dead);
            }
        }
    }
}