using System;
using UnityEngine;

namespace Innerspace.TestApp.UI
{
    /// <summary>
    /// Handles the HUD
    /// </summary>
    public class HUDHandler:MonoBehaviour
    {
        public Progressbar progressbar;
        public LoadingCursorHUD loadingCursor;

        internal void DisableHUD()
        {
            progressbar.gameObject.SetActive(true);
            loadingCursor.gameObject.SetActive(true);

        }

        internal void EnableHUD()
        {
            progressbar.gameObject.SetActive(false);
            loadingCursor.gameObject.SetActive(false);
        }
    }
}