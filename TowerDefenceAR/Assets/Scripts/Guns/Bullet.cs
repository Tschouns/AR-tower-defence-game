using Assets.Scripts.Misc;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Guns
{
    [RequireComponent(typeof(GameTimer))]
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField]
        private float velocity = 3.0f;

        [SerializeField]
        private float energy = 10f;

        [SerializeField]
        private GameObject explosionPrefab;

        private ITimer timer;

        public bool IsActive => gameObject.activeSelf;

        public float Energy => energy;

        public Vector3 Direction => transform.forward;

        public GameObject ExplosionPrefab => explosionPrefab;

        public void Activate()
        {
            gameObject.SetActive(true);
            timer.IsActive = true;
        }

        private void Awake()
        {
            Assert.IsNotNull(explosionPrefab, "The explosion prefab is not set.");

            timer = GetComponent<ITimer>();
            Assert.IsNotNull("The game timer component is missing.");
        }

        private void Start()
        {
            timer.IsActive = true;
        }

        private void Update()
        {
            if (timer.IsDurationReached)
            {
                DestroyBullet();
                return;
            }

            var travelingDistance = velocity * Time.deltaTime;

            // Detect hits.
            var hits = Physics.RaycastAll(transform.position, transform.forward, travelingDistance);
            foreach (var hit in hits)
            {
                var target = hit.collider.GetComponentInParent<HitTarget>();
                if (target != null)
                {
                    target.Hit(this, hit.point);

                    DestroyBullet();
                    return;
                }
            }

            var move = transform.forward * travelingDistance;
            transform.position = transform.position + move;
        }

        private void DestroyBullet()
        {
            // Prepare for reuse.
            timer.IsActive = false;
            timer.Reset();

            // "Destroy" bullet.
            gameObject.SetActive(false);
        }
    }
}
