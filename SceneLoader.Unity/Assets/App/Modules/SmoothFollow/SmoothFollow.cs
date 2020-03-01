using UnityEngine;

namespace Innerspace.TestApp
{
    /// <summary>
    /// Smoothly follow the target object always maintaining a <see cref="distance"/>
    /// </summary>
    public class SmoothFollow : MonoBehaviour
    {
        /// <summary>
        /// The target object to follow
        /// </summary>
        public Transform targetToFollow;
        /// <summary>
        /// The distance to be maintained
        /// </summary>
        public float distance;
        /// <summary>
        /// Smoothness of the follow movement. The object will be locked in front if the value is zero
        /// </summary>
        public float smoothness;
        /// <summary>
        /// Whether to lookat the target transform
        /// </summary>
        public bool lookAt;
        /// <summary>
        /// Snaps to the locaiton if the distance is within the threshold
        /// </summary>
        public float snapThreshold = 0.005f;

        private bool isSetup = false;
        // Start is called before the first frame update
        void Start()
        {
            Setup();
        }

        public void Setup()
        {
            transform.position = targetToFollow.transform.position + targetToFollow.transform.forward * distance;
            isSetup = true;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            //if (!isSetup) return;
            var targetPosition = targetToFollow.position + targetToFollow.forward * distance;
            var position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / smoothness);

            transform.position = targetToFollow.position - (targetToFollow.position - position).normalized * distance;
            if (Mathf.Abs(Vector3.Distance(targetPosition, transform.position)) < snapThreshold)
            {
                transform.position = targetPosition;
            }
            if (lookAt)
            {
                transform.LookAt(targetToFollow);
            }
        }
    }
}
