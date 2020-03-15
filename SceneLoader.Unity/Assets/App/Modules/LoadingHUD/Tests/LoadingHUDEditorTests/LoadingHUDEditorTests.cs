using System.Collections;
using System.Collections.Generic;
using System.IO;
using Innerspace.TestApp.UI;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace LoadingHUDEditorTests
{
    public class LoadingHUDEditorTests
    {
        [Test]
        [Description("To verify if the LoadingCursorHUD prefab can be successfully instantiated")]
        public void LoadingCursorPrefab_InstantiationTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/LoadingHUD/Prefabs/LoadingCursorHUD.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // Act
            var cursorInstance = GameObject.Instantiate(prefab);

            // Assert
            Assert.IsNotNull(cursorInstance);

            // Clean Up
            GameObject.DestroyImmediate(cursorInstance);
        }

        [Test]
        [Description("Loading text value change should update the display text")]
        public void LoadingCursorInstance_LoadingTextChangeTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/LoadingHUD/Prefabs/LoadingCursorHUD.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var textToChange = "Loading..";
            var cursorInstance = GameObject.Instantiate(prefab);
            Assert.IsNotNull(cursorInstance);// make sure the instance is not null
            var loadingHUD = cursorInstance.GetComponent<LoadingCursorHUD>();
            Assert.NotNull(loadingHUD);

            // Act
            loadingHUD.loadingText = textToChange;
            loadingHUD.OnValidate();

            // Assert
            Assert.AreEqual(textToChange, loadingHUD.displayText.text);

            // Clean Up
            GameObject.DestroyImmediate(cursorInstance);
        }

        [Test]
        [Description("Background color change should update background mesh's material")]
        public void LoadingCursorInstance_LoadingBackgroundColorChangeTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/LoadingHUD/Prefabs/LoadingCursorHUD.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var cursorInstance = GameObject.Instantiate(prefab);
            Assert.IsNotNull(cursorInstance);// make sure the instance is not null
            var loadingHUD = cursorInstance.GetComponent<LoadingCursorHUD>();
            Assert.NotNull(loadingHUD);
            var originalBackgroundColor = loadingHUD.backgroundRenderer.sharedMaterial.color;
            var colorToChange = Color.green;

            // Act          
            loadingHUD.backgroundColor = colorToChange;
            loadingHUD.OnValidate();

            // Assert
            Assert.AreEqual(colorToChange, loadingHUD.backgroundRenderer.sharedMaterial.color);

            // Clean Up
            loadingHUD.backgroundRenderer.sharedMaterial.color = originalBackgroundColor;
            GameObject.DestroyImmediate(cursorInstance);
        }

        [Test]
        [Description("Foreground color change should update foreground mesh's material")]
        public void LoadingCursorInstance_LoadingForeGroundColorChangeTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/LoadingHUD/Prefabs/LoadingCursorHUD.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var cursorInstance = GameObject.Instantiate(prefab);
            Assert.IsNotNull(cursorInstance);// make sure the instance is not null
            var loadingHUD = cursorInstance.GetComponent<LoadingCursorHUD>();
            Assert.NotNull(loadingHUD);
            var originalBackgroundColor = loadingHUD.foregroundRenderer.sharedMaterial.color;
            var colorToChange = Color.green;

            // Act          
            loadingHUD.foreGroundColor = colorToChange;
            loadingHUD.OnValidate();

            // Assert
            Assert.AreEqual(colorToChange, loadingHUD.foregroundRenderer.sharedMaterial.color);

            // Clean Up
            loadingHUD.foregroundRenderer.sharedMaterial.color = originalBackgroundColor;
            GameObject.DestroyImmediate(cursorInstance);
        }
    }
}
