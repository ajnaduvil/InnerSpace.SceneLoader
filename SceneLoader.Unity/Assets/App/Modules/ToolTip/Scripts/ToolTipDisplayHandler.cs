using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Innerspace.TestApp.ToolTip
{
    public class ToolTipDisplayHandler : MonoBehaviour
    {
        /// <summary>
        /// Default <see cref="ToolTipDataContainer"/> reference. The in the build, a config file called 
        /// "ToolTipConfig.json" will be created at <see cref="toolTipConfigPath"/>from this object if there is no config file available.
        /// If "ToolTipConfig.json is avaiable at <see cref="toolTipConfigPath"/> then the config will be loaded t
        /// </summary>
        public ToolTipDataContainer toolTipData;
        public ToolTipDisplay toolTipDisplay;
        /// <summary>
        /// Delay to change random tooltip in seconds
        /// </summary>
        public float randomTooltipDelay = 5f;

        private string toolTipConfigPath;
        private Coroutine showTooltipsCoroutineRef = null;

        private void Start()
        {
            toolTipConfigPath = Application.dataPath;
            //Load config only in build
#if !UNITY_EDITOR
            toolTipData.LoadOrCreateConfig(toolTipConfigPath);
#endif
        }
        /// <summary>
        /// Starts showing random tooltips at an interval 
        /// </summary>
        public void StartShowingTooltips()
        {
            if (showTooltipsCoroutineRef != null)
            {
                StopShowingTooltips();
            }
            showTooltipsCoroutineRef = StartCoroutine(ShowTooltipsCoroutine());

        }
        /// <summary>
        /// Stops showing tooltips
        /// </summary>
        public void StopShowingTooltips()
        {
            if (showTooltipsCoroutineRef != null)
            {
                StopCoroutine(showTooltipsCoroutineRef);
                showTooltipsCoroutineRef = null;
            }
            toolTipDisplay.gameObject.SetActive(false);
        }
        private IEnumerator ShowTooltipsCoroutine()
        {
            int totalTooltipsCount = toolTipData.toolTips.Length;

            while (totalTooltipsCount > 0)
            {
                int randomIndex = Random.Range(0, totalTooltipsCount);
                toolTipDisplay.UpdateDisplay(toolTipData.toolTips[randomIndex]);
                yield return new WaitForSeconds(randomTooltipDelay);
            }

            Debug.Log("Could not find any tooltips");
        }
    }
}
