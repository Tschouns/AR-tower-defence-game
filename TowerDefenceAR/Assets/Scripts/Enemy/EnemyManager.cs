using Assets.Scripts.Helpers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(GameTimer))]
    public class EnemyManager : MonoBehaviour, IEnemyManager
    {
        private readonly IList<EnemyTank> enemies = new List<EnemyTank>();

        [SerializeField]
        private Transform ememySpawnPoint;

        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]
        private GameObject pointIndicator;

        private GameTimer spawmTimer;

        private void Awake()
        {
            Assert.IsNotNull(ememySpawnPoint, "The enemy spawn point is not set.");
            Assert.IsNotNull(enemyPrefab, "The enemy prefab is not set.");
            Assert.IsNotNull(pointIndicator, "The point indicator prefab was not found.");

            var enemyTank = enemyPrefab.GetComponent<EnemyTank>();
            Assert.IsNotNull(enemyTank, "The specified enemy prefab is not valid.");

            spawmTimer = GetComponent<GameTimer>();
            Assert.IsNotNull(spawmTimer, "The spawn timer component was not found.");
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
                var newEnemyTankObject = Instantiate(enemyPrefab, ememySpawnPoint.position, ememySpawnPoint.rotation);
                var newEnemyTank = newEnemyTankObject.GetComponent<EnemyTank>();
                Assert.IsNotNull(newEnemyTank);
                enemies.Add(newEnemyTank);

                // For testing purposes...
                var desination = RandomDestination();
                Instantiate(pointIndicator, desination, Quaternion.identity);

                var target = Instantiate(pointIndicator, RandomTarget(), Quaternion.identity);

                newEnemyTank.SetDestination(desination);
                newEnemyTank.SetAttackTarget(target.transform);

                spawmTimer.Reset();
            }
        }

        private Vector3 RandomDestination()
        {
            return new Vector3(
                Random.Range(-1f, 1f),
                0,
                Random.Range(-1f, 1f));
        }

        private Vector3 RandomTarget()
        {
            return new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(0, 0.5f),
                Random.Range(-1f, 1f));
        }
    }
}
