using TMPro;
using UnityEngine;

namespace Innerspace.TestApp.UI
{

    /// <summary>
    /// Class for customizing the loading cursor HUD
    /// </summary>
    public class LoadingCursorHUD : MonoBehaviour
    {
        [Header("References")]
        /// <summary>
        /// Renderer reference for cursorbackground
        /// </summary>
        public Renderer backgroundRenderer;
        /// <summary>
        /// Renderer reference for cursorbackground
        /// </summary>
        public Renderer foregroundRenderer;
        public TextMeshPro displayText;

        [Header("Customization")]
        public Color backgroundColor = Color.black;
        public Color foreGroundColor = Color.white;
        public string loadingText = "Loading..";

        //Makes sure in-Editor changes are applied
        private void OnValidate()
        {
            Init();
        }
        private void Init()
        {
#if UNITY_EDITOR
            if (backgroundRenderer)
                backgroundRenderer.sharedMaterial.color = backgroundColor;
            if (foregroundRenderer)
                foregroundRenderer.sharedMaterial.color = foreGroundColor;
#else
            if (backgroundRenderer)
                backgroundRenderer.material.color = backgroundColor;
            if (foregroundRenderer)
                foregroundRenderer.material.color = foreGroundColor;
#endif
            if (displayText)
            {
                displayText.text = loadingText;
            }

        }
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }
    }
}
