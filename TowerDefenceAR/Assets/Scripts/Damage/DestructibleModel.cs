using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Damage
{
    /// <summary>
    /// Replaces a "healthy" model by "destroyed" model when the object dies / gets destroyed.
    /// </summary>
    [RequireComponent(typeof(Health))]
    public class DestructibleModel : MonoBehaviour
    {
        [SerializeField]
        private Health health;

        [SerializeField]
        private GameObject healthyModel;

        [SerializeField]
        private GameObject destroyedModel;


        private void Awake()
        {
            Assert.IsNotNull(health, "The health component is not set.");
            Assert.IsNotNull(healthyModel, "The \"healthy\" model is not set.");
            Assert.IsNotNull(destroyedModel, "The \"destroyed\" model is not set.");

            healthyModel.SetActive(true);
            destroyedModel.SetActive(false);

            health.OnDied += Destroy;
        }

        private void Destroy()
        {
            healthyModel.SetActive(false);
            destroyedModel.SetActive(true);
        }
    }
}
