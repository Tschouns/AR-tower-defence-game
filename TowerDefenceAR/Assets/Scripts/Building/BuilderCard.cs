using UnityEngine;
using UnityEngine.Assertions;
using Vuforia;

namespace Assets.Scripts.Building
{
    [RequireComponent(typeof(ImageTargetBehaviour))]
    public class BuilderCard : DefaultObserverEventHandler, IBuilderCard
    {
        [SerializeField]
        private float timeToBuild = 5.0f;

        [SerializeField]
        private GameObject objectToBuildPrefab;

        [SerializeField]
        private GameObject groundIndicatorPrefab;

        private GameObject groundIndicator;

        private bool isTracking = false;
        private float? trackingSince = null;

        private Vector3 buildingPosition;
        private Quaternion buildingRotation;

        public bool HasBuilt { get; private set; } = false;

        protected override void OnTrackingFound()
        {
            base.OnTrackingFound();
            Debug.Log("Now tracking...", this);

            isTracking = true;
            trackingSince = Time.time;
        }

        protected override void OnTrackingLost()
        {
            base.OnTrackingLost();
            Debug.Log("Lost tracking...", this);

            isTracking = false;
            trackingSince = null;
        }

        private void Awake()
        {
            Assert.IsNotNull(objectToBuildPrefab, "A prefab must be assigned as \"Object To Build\".");
            Assert.IsNotNull(groundIndicatorPrefab, "A prefab must be assigned as \"Ground Indicator\".");

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

            if (isTracking &&
                Time.time - trackingSince > timeToBuild)
            {
                Instantiate(objectToBuildPrefab, buildingPosition, buildingRotation);
                HasBuilt = true;
                groundIndicator.SetActive(false);

                return;
            }

            DisplayGroundIndicator();
        }

        private void DisplayGroundIndicator()
        {
            if (!isTracking)
            {
                groundIndicator.SetActive(false);
                return;
            }

            // Try project the card's position onto the ground.
            var referencePoint = transform.position + Vector3.up;

            if (Physics.Raycast(referencePoint, Vector3.down, out var hit, 10))
            {
                if (hit.collider.GetComponentInParent<Ground>() != null)
                {
                    buildingPosition = hit.point;
                    buildingRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);

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
    }
}