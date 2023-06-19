using Assets.Scripts.Defence;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Building
{
    [RequireComponent(typeof(BuilderCard))]
    public class DefenceManagerNotifier : MonoBehaviour
    {
        private IDefenceTurretRegistry defenceTurretRegistry;

        private void Awake()
        {
            defenceTurretRegistry = FindObjectOfType<DefenceManager>();
            if (defenceTurretRegistry == null)
            {
                Debug.LogWarning("There appears to be no defence manager in the scene.");
                return;
            }

            var builderCard = gameObject.GetComponent<BuilderCard>();
            Assert.IsNotNull(builderCard);

            builderCard.OnBuilt += RegisterBuildingUnit;
        }

        private void RegisterBuildingUnit(GameObject building)
        {
            Assert.IsNotNull(building);

            var defenceTurretComponent = building.GetComponent<DefenceTurret>();
            if (defenceTurretComponent != null)
            {
                defenceTurretRegistry.RegisterDefenceTurret(defenceTurretComponent);
            }
        }
    }
}