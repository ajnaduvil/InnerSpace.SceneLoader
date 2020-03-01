using Innerspace.TestApp.ToolTip;
using UnityEngine;

namespace Innerspace.TestApp.UI
{
    /// <summary>
    /// Handles the HUD
    /// </summary>
    public class HUDHandler : MonoBehaviour
    {
        public Progressbar progressbar;
        public LoadingCursorHUD loadingCursor;
        public ToolTipDisplay tooltipDisplay;
        internal void DisableHUD()
        {
            progressbar.gameObject.SetActive(false);
            loadingCursor.gameObject.SetActive(false);
            tooltipDisplay.DisableDisplay();
        }
        internal void EnableHUD()
        {
            progressbar.gameObject.SetActive(true);
            loadingCursor.gameObject.SetActive(true);
            tooltipDisplay.EnableDisplay();
        }
    }
}