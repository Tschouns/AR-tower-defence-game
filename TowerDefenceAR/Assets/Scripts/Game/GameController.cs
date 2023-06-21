using Assets.Scripts.Building;
using Assets.Scripts.Game;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game
{
    public class GameController : MonoBehaviour, IGame
    {
        [SerializeField]
        private BuilderCard towerBuilderCard;

        [SerializeField]
        private BuilderCard enemySpawnPointBuilderCard;

        [SerializeField]
        private BuilderCard[] defenceBuilderCards;

        [SerializeField]
        private BuilderCard[] obstacleBuilderCards;

        public bool IsTowerBuilt => towerBuilderCard.HasBuilt;

        public bool IsEnemySpawnPointBuilt => enemySpawnPointBuilderCard.HasBuilt;

        public int DefencesBuilt => defenceBuilderCards.Count(c => c.HasBuilt);

        public int ObstaclesBuilt => obstacleBuilderCards.Count(c => c.HasBuilt);

        public bool HasDefencesLeftToBuild => defenceBuilderCards.Any(c => !c.HasBuilt);

        public bool HasObstaclesLeftToBuild => obstacleBuilderCards.Any(c => !c.HasBuilt);

        private void Awake()
        {
            Assert.IsNotNull(towerBuilderCard);
            Assert.IsNotNull(enemySpawnPointBuilderCard);
            Assert.IsNotNull(defenceBuilderCards);
            Assert.IsNotNull(obstacleBuilderCards);
            Assert.IsTrue(defenceBuilderCards.Any());
            Assert.IsTrue(obstacleBuilderCards.Any());
        }

        private void Update()
        {
            UpdateBuilderCardStatus();
        }

        private void UpdateBuilderCardStatus()
        {
            towerBuilderCard.gameObject.SetActive(!IsTowerBuilt);
            enemySpawnPointBuilderCard.gameObject.SetActive(IsTowerBuilt && !IsEnemySpawnPointBuilt);
            UpdateBuilderCardSequence(defenceBuilderCards);
            UpdateBuilderCardSequence(obstacleBuilderCards);
        }

        /// <summary>
        /// Sets the first card which hasn't built its building active; all the others are inactive.
        /// </summary>
        private void UpdateBuilderCardSequence(BuilderCard[] cardSequence)
        {
            var foundActive = false;

            foreach (var card in cardSequence)
            {
                card.gameObject.SetActive(
                    IsTowerBuilt &&
                    IsEnemySpawnPointBuilt &&
                    !card.HasBuilt &&
                    !foundActive);

                if (card.gameObject.activeSelf)
                {
                    foundActive = true;
                }
            }
        }
    }
}
