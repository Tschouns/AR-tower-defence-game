using Assets.Scripts.Battle;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Building
{
    [RequireComponent(typeof(BuilderCard))]
    public class BuildingUnitManagerNotifier : MonoBehaviour
    {
        private IPlayerUnitRegistry unitRegistery;

        private void Awake()
        {
            unitRegistery = FindObjectOfType<UnitManager>();
            if (unitRegistery == null)
            {
                Debug.LogWarning("There appears to be no unit manager in the scene.");
                return;
            }

            var builderCard = gameObject.GetComponent<BuilderCard>();
            Assert.IsNotNull(builderCard);

            builderCard.OnBuilt += RegisterBuildingUnit;
        }

        private void RegisterBuildingUnit(GameObject building)
        {
            Assert.IsNotNull(building);

            var unitComponent = building.GetComponent<IUnit>();
            if (unitComponent != null)
            {
                unitRegistery.RegisterPlayerUnit(unitComponent);
            }
        }
    }
}
