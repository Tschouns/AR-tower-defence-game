using Assets.Scripts.Building;
using System;
using System.Collections.Generic;
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

        public IReadOnlyList<IUnit> GetPlayerUnits()
        {
            return playerUnits;
        }

        public IReadOnlyList<IUnit> GetEnemyTanks()
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
    }
}