using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Innerspace.TestApp.UI;

namespace ProgressbarEditorTests
{
    public class ProgressbarEditorTests
    {
        [Test]
        [Description("To check if progressbar prefab can be successfully instantiated")]
        public void ProgressbarPrefab_InstantiationTest()
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/Progressbar/Prefabs/Progressbar.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

            // Act
            var progressBarInstance = GameObject.Instantiate(prefab);

            // Assert
            Assert.IsNotNull(progressBarInstance);

            // Clean Up
            GameObject.DestroyImmediate(progressBarInstance);
        }


        [Test]
        [Sequential]
        [Description("To validate progresschange callback receives the changes in progress value")]

        public void ProgressbarInstance_ProgressChangeCallbackTest([Values(0f, 0.5f, 1f)] float expectedValue, [Values(0f, 0.5f, 1f)] float valueToTest)
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/Progressbar/Prefabs/Progressbar.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var progresbarInstance = GameObject.Instantiate(prefab);
            Assert.IsNotNull(progresbarInstance);// make sure the instance is not null
            var progressbar = progresbarInstance.GetComponent<Progressbar>();
            Assert.NotNull(progressbar);
            float receivedValue = -100f;
            progressbar.progressChanged += (progressValue) =>
            {
                receivedValue = progressValue;
            };

            // Act
            progressbar.Progress = valueToTest;

            // Assert
            Assert.AreEqual(expectedValue, receivedValue);

            // Clean Up
            GameObject.DestroyImmediate(progresbarInstance);
        }


        [Test]
        [Sequential]
        [Description("To make sure the progress value remains within 0-1 range")]
        public void ProgressbarInstance_ProgressChangeCallback_ValueShouldbe_Between_0_to_1_Test([Values(0f, 0f, 1f,1f)] float expectedValue, [Values(-1f, -5, 100f,1000f)] float valueToTest)
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/Progressbar/Prefabs/Progressbar.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var progresbarInstance = GameObject.Instantiate(prefab);
            Assert.IsNotNull(progresbarInstance);// make sure the instance is not null
            var progressbar = progresbarInstance.GetComponent<Progressbar>();
            Assert.NotNull(progressbar);
            float receivedValue = -100f;
            progressbar.progressChanged += (progressValue) =>
            {
                receivedValue = progressValue;
            };

            // Act
            progressbar.Progress = valueToTest;

            // Assert
            Assert.AreEqual(expectedValue, receivedValue);

            // Clean Up
            GameObject.DestroyImmediate(progresbarInstance);
        }

    }
}
