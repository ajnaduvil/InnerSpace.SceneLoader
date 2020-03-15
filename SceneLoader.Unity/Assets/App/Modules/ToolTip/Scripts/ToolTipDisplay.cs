using TMPro;
using UnityEngine;

namespace Innerspace.TestApp.ToolTip
{
    /// <summary>
    /// Class that represenets tooltip display ui
    /// </summary>
    public class ToolTipDisplay : MonoBehaviour
    {
        public TextMeshProUGUI headerText;
        public TextMeshProUGUI infoText;

        /// <summary>
        /// Updates the tooltip diplay
        /// </summary>
        /// <param name="data"></param>
        public void UpdateDisplay(ToolTipData data)
        {
            headerText.text = data.header;
            infoText.text = data.info;
        }

        /// <summary>
        /// Resets the display text
        /// </summary>
        public void ResetDisplay()
        {
            headerText.text = "";
            infoText.text = "";
        }
    }
}