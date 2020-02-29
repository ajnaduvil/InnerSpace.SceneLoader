using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Innerspace.TestApp.UI
{

    /// <summary>
    /// Progressbar image that indicates the progress update
    /// </summary>
    public class Progressbar : MonoBehaviour
    {

        [Range(0, 1)]
        [SerializeField]
        private float progress;

        /// <summary>
        /// Event that gets invoked when a progressbar value changes
        /// </summary>
        public Action<float> progressChanged;


        /// <summary>
        /// The current progress value between 0 and 1. Also, updates the UI when set;
        /// </summary>
        public float Progress
        {
            get
            {
                return progress;
            }
            set
            {
                // Clamps the value within 0-1
                progress = Mathf.Clamp(value, 0, 1);
                progressChanged?.Invoke(progress);
            }
        }


        private void OnValidate()
        {
            progressChanged?.Invoke(progress);
        }
    }
}
