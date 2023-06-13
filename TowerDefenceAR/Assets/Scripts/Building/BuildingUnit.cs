using Assets.Scripts.Battle;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingUnit : MonoBehaviour, IUnit
    {
        [SerializeField]
        private float heightY = 0.2f;

        [SerializeField]
        private float widthX = 0.1f;

        [SerializeField]
        private float depthZ = 0.1f;

        public int AttackPriority => 100;

        public Vector3 Position => transform.position;

        public Vector3 GetAttackPoint()
        {
            var xOffset = Random.Range(-(widthX / 2), (widthX / 2));
            var yOffset = Random.Range(0, heightY);
            var zOffset = Random.Range(-(depthZ / 2), (depthZ / 2));

            var relativeAttackPoint = new Vector3(
                (transform.right * xOffset).x,
                yOffset,
                (transform.forward * zOffset).z);

            return transform.position + relativeAttackPoint;
        }
    }
}