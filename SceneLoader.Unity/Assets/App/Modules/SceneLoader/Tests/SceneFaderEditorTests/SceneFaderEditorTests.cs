using System.Collections;
using System.Collections.Generic;
using Innerspace.TestApp.SceneLoader;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace SceneLoaderEditorTests
{
    public class SceneFaderEditorTests
    {
        [Test]
        [Description("To verify if the LoadingCursorHUD prefab can be successfully instantiated")]
        public void SceneFaderPrefab_InstantiationTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/SceneLoader/Prefabs/SceneFader.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // Act
            var scenefaderInstance = GameObject.Instantiate(prefab);

            // Assert
            Assert.IsNotNull(scenefaderInstance);

            // Clean Up
            GameObject.DestroyImmediate(scenefaderInstance);
        }

        [Test]
        [Description("To verify if the LoadingCursorHUD prefab references are correctly assigned")]
        public void SceneFaderPrefab_SetupValidationTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/SceneLoader/Prefabs/SceneFader.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            Assert.IsNotNull(prefab);

            // Act
            var sceneFader = prefab.GetComponent<SceneFader>();
            var faderAC = sceneFader.faderAC;
            var faderRenderer = sceneFader.faderRenderer;

            // Assert
            Assert.IsNotNull(faderAC);
            Assert.IsNotNull(faderRenderer);
        }

     
    }
}


