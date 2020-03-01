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

        public void EnableDisplay()
        {
            ///TODO: Method to be removed
        }
        public void DisableDisplay()
        {
            ///TODO: Method to be removed
        }
        /// <summary>
        /// Updates the tooltip diplay
        /// </summary>
        /// <param name="data"></param>
        public void UpdateDisplay(ToolTipData data)
        {
            headerText.text = data.header;
            infoText.text = data.info;
        }
    }
}