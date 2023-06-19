using UnityEngine;

namespace Assets.Scripts.Misc
{
    /// <summary>
    /// Makes the object self-destruct after a specified lifetime.
    /// </summary>
    public class SelfDestructTimed : MonoBehaviour
    {
        [SerializeField]
        private float selfDestructAfter = 5f;

        private float lifetime = 0;

        private void Update()
        {
            lifetime += Time.deltaTime;
            if (lifetime > selfDestructAfter)
            {
                Destroy(gameObject);
            }
        }
    }
}