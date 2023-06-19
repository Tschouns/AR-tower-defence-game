using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Guns
{
    internal class Gun : MonoBehaviour, IGun
    {
        private IList<Bullet> bullets = new List<Bullet>();

        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform bulletSpawnPoint;

        [SerializeField]
        private ParticleSystem muzzleFlashEffect;

        [SerializeField]
        private float coolDownTime = 3.0f;

        public bool IsReady { get; private set; } = true;

        public void Shoot()
        {
            if (!IsReady)
            {
                return;
            }

            var bullet = PrepareBullet();
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.transform.rotation = transform.rotation;

            muzzleFlashEffect.Play();

            // Cooldown.
            IsReady = false;
            StartCoroutine(ResetGun());
        }

        private void Awake()
        {
            Assert.IsNotNull(bulletPrefab, "The bullet prefab is not set.");
            Assert.IsNotNull(bulletSpawnPoint, "The bullet spawn point is not set.");
            Assert.IsNotNull(muzzleFlashEffect, "The muzzle flash effect is not set.");

            var bulletComponent = bulletPrefab.GetComponent<Bullet>();
            Assert.IsNotNull(bulletComponent, "The bullet prefab is missing a bullet component.");
        }

        private IEnumerator ResetGun()
        {
            yield return new WaitForSeconds(coolDownTime);
            IsReady = true;
            yield return null;
        }

        private Bullet PrepareBullet()
        {
            var bulletOfNull = bullets.FirstOrDefault(b => !b.IsActive);
            if (bulletOfNull != null)
            {
                bulletOfNull.Activate();

                return bulletOfNull;
            }

            var newBulletObject = Instantiate(bulletPrefab);
            var newBullet = newBulletObject.GetComponent<Bullet>();
            newBullet.Activate();
            bullets.Add(newBullet);

            return newBullet;
        }
    }
}
