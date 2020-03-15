using System.Collections;
using System.Collections.Generic;
using Innerspace.TestApp.ToolTip;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace TooltipEditorTests
{
    public class TooltipDisplayEditorTests
    {

        [Test]
        [Description("To check if tooltip prefab can be successfully instantiated")]
        public void TooltipDisplayPrefab_InstantiationTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/Tooltip/Prefabs/TooltipDisplay.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // Act
            var progressBarInstance = GameObject.Instantiate(prefab);

            // Assert
            Assert.IsNotNull(progressBarInstance);

            // Clean Up
            GameObject.DestroyImmediate(progressBarInstance);
        }

        [Test]
        [Description("To check if tooltip prefab has the necessary references in place")]
        public void TooltipDisplayPrefab_SetupValidationTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/Tooltip/Prefabs/TooltipDisplay.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // Act
            var toolitpDisplay = prefab.GetComponent<ToolTipDisplay>();
            Assert.NotNull(toolitpDisplay);
            var headerText = toolitpDisplay.headerText;           
            var infoText = toolitpDisplay.infoText;

            // Assert
             Assert.NotNull(headerText);
            Assert.NotNull(infoText);

        }

    }
}
