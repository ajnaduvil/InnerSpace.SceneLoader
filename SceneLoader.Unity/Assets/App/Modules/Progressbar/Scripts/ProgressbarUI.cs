using Innerspace.TestApp.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Innerspace.TestApp.UI
{



    [RequireComponent(typeof(Progressbar))]
    public class ProgressbarUI : MonoBehaviour
    {
        [Header("References")]
        public Image fillImage;
        public Image backgroundImage;

        /// <summary>
        /// Updates the value of the progress ui when set.
        /// </summary>

        [Header("Customization")]
        public Color fillColor;
        public Color backgroudColor;

        private Progressbar progressbar;

        private void OnValidate()
        {
            if (fillImage)
            {
                fillImage.color = fillColor;
            }
            if (backgroundImage)
            {
                backgroundImage.color = backgroudColor;
            }
        }

        private void UpdateProgress(float progress)
        {
            progress = Mathf.Clamp(progress, 0, 1);
            fillImage.fillAmount = progress / 1;
        }

        #region Monobehaviour Methods
        void Awake()
        {
            progressbar = GetComponent<Progressbar>();
        }

        private void OnEnable()
        {
            progressbar.progressChanged += UpdateProgress;
            UpdateProgress(progressbar.Progress);
        }

        private void OnDisable()
        {
            progressbar.progressChanged += UpdateProgress;
        }
        #endregion
    }
}
