using Assets.Scripts.Misc;
using System;
using UnityEngine;
using UnityEngine.Assertions;
using Vuforia;

namespace Assets.Scripts.Building
{
    [RequireComponent(typeof(ImageTargetBehaviour))]
    [RequireComponent(typeof(GameTimer))]
    public class BuilderCard : DefaultObserverEventHandler, IBuilderCard
    {
        [SerializeField]
        private GameObject objectToBuildPrefab;

        [SerializeField]
        private GameObject groundIndicatorPrefab;

        [SerializeField]
        private float yRotationOffsetDegrees = 180;

        private GameTimer timer;
        private GameObject groundIndicator;

        private Vector3 buildingPosition;
        private Quaternion buildingRotation;

        public event Action<GameObject> OnBuilt;

        public bool HasBuilt { get; private set; } = false;

        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();
            Debug.Log("Now tracking...", this);

            timer.IsActive = true;
        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();
            Debug.Log("Lost tracking...", this);

            timer.IsActive = false;
            timer.Reset();
        }

        private void Awake()
        {
            Assert.IsNotNull(objectToBuildPrefab, "A prefab must be assigned as \"Object To Build\".");
            Assert.IsNotNull(groundIndicatorPrefab, "A prefab must be assigned as \"Ground Indicator\".");

            timer = GetComponent<GameTimer>();
            Assert.IsNotNull(timer, "The game timer component was not found.");

            groundIndicator = Instantiate(groundIndicatorPrefab, transform);
            groundIndicator.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            if (HasBuilt)
            {
                return;
            }

            if (timer.IsDurationReached)
            {
                BuildBuilding();

                return;
            }

            DisplayGroundIndicator();
        }

        private void DisplayGroundIndicator()
        {
            if (!timer.IsActive)
            {
                groundIndicator.SetActive(false);
                return;
            }

            // Try project the card's position onto the ground.
            var referencePoint = transform.position + Vector3.up;

            var hits = Physics.RaycastAll(referencePoint, Vector3.down, 10);
            foreach (var hit in hits)
            {
                if (hit.collider.GetComponentInParent<Ground>() != null)
                {
                    var yRotation = transform.rotation.eulerAngles.y + yRotationOffsetDegrees;

                    buildingPosition = hit.point;
                    buildingRotation = Quaternion.Euler(0, yRotation, 0);

                    // Display at potential building position / rotation.
                    groundIndicator.SetActive(true);
                    groundIndicator.transform.position = buildingPosition;
                    groundIndicator.transform.rotation = buildingRotation;

                    return;
                }
            }

            // No hit? Deactivate.
            groundIndicator.SetActive(false);
        }

        private void BuildBuilding()
        {
            var building = Instantiate(objectToBuildPrefab, buildingPosition, buildingRotation);
            groundIndicator.SetActive(false);
            HasBuilt = true;
            OnBuilt?.Invoke(building);
        }
    }
}