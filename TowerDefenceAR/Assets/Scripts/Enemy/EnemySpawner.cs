using Assets.Scripts.Battle;
using Assets.Scripts.Misc;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(GameTimer))]
    public class EnemySpawner : MonoBehaviour, IEnemySpawner
    {
        private readonly IList<EnemyTank> enemies = new List<EnemyTank>();

        [SerializeField]
        private Transform ememySpawnPoint;

        [SerializeField]
        private GameObject enemyPrefab;

        private GameTimer spawmTimer;
        private IEnemyUnitRegistry enemyUnitRegistry;
        private IUnitProvider unitProvider;

        private void Awake()
        {
            Assert.IsNotNull(ememySpawnPoint, "The enemy spawn point is not set.");
            Assert.IsNotNull(enemyPrefab, "The enemy prefab is not set.");

            var enemyTank = enemyPrefab.GetComponent<EnemyTank>();
            Assert.IsNotNull(enemyTank, "The specified enemy prefab is not valid: no tank component.");

            var enemyTankCommander = enemyPrefab.GetComponent<EnemyTankCommander>();
            Assert.IsNotNull(enemyTankCommander, "The specified enemy prefab is not valid: no tank commander component.");

            spawmTimer = GetComponent<GameTimer>();
            Assert.IsNotNull(spawmTimer, "The spawn timer component was not found.");

            var unitManager = FindObjectOfType<UnitManager>();
            Assert.IsNotNull(unitManager, "There appears to be no unit manager in the scene.");

            enemyUnitRegistry = unitManager;
            unitProvider = unitManager;
        }

        private void Start()
        {
            spawmTimer.IsActive = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (spawmTimer.IsDurationReached)
            {
                // Spawn a tank.
                var tankObject = Instantiate(enemyPrefab, ememySpawnPoint.position, ememySpawnPoint.rotation);
                var tank = tankObject.GetComponent<EnemyTank>();
                var tankCommander = tankObject.GetComponent<EnemyTankCommander>();
                Assert.IsNotNull(tank);
                Assert.IsNotNull(tankCommander);

                tankCommander.Initialize(unitProvider);

                enemies.Add(tank);
                enemyUnitRegistry.RegisterEnemyUnit(tank);

                // Assign an initial target.
                var potentialTargets = unitProvider.GetAlivePlayerUnits();
                if (potentialTargets.Any())
                {
                    var target = potentialTargets[Random.Range(0, potentialTargets.Count)];
                    tankCommander.AssignAttackTarget(target);
                }

                spawmTimer.Reset();
            }
        }
    }
}
