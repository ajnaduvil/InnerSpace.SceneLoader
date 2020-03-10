using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[assembly: InternalsVisibleTo("ProgressbarEditorTests")]
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

        internal void OnValidate()
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
        internal void Awake()
        {
            progressbar = GetComponent<Progressbar>();
        }

        internal void OnEnable()
        {
            progressbar.progressChanged += UpdateProgress;
            UpdateProgress(progressbar.Progress);
        }

        internal void OnDisable()
        {
            progressbar.progressChanged -= UpdateProgress;
        }
        #endregion
    }
}
