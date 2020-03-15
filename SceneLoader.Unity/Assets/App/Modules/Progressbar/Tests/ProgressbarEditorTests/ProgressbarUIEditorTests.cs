using Innerspace.TestApp.UI;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace ProgressbarEditorTests
{
    public class ProgressbarEditorUITests
    {

        [Test]
        [Sequential]
        [Description("The progressbarUI fill image should change when progress is updated")]
        public void ProgressbarUI_ProgressChangeUIUpdateTest([Values(0f, 0.5f, 1f)] float expectedValue, [Values(0f, 0.5f, 1f)] float valueToTest)
        {
            // Arrange
            var prefabPath = "Assets/App/Modules/Progressbar/Prefabs/Progressbar.prefab";
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var progresbarInstance = GameObject.Instantiate(prefab);
            Assert.IsNotNull(progresbarInstance);// make sure the instance is not null
            var progressbar = progresbarInstance.GetComponent<Progressbar>();
            Assert.NotNull(progressbar);
            var progressbarUI = progresbarInstance.GetComponent<ProgressbarUI>();
            Assert.NotNull(progressbarUI);

            // Act
            progressbar.Progress = valueToTest;
            progressbarUI.Awake();
            progressbarUI.OnEnable();
            float receivedValue = progressbarUI.fillImage.fillAmount;

            // Assert
            Assert.AreEqual(expectedValue, receivedValue);

            // Clean Up
            GameObject.DestroyImmediate(progresbarInstance);
        }


    }
}
