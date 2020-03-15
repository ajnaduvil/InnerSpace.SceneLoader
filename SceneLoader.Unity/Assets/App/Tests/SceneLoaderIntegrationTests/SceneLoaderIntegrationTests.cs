using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AVR.TestUtils;
using Innerspace.TestApp.ToolTip;
using Innerspace.TestApp;
using UnityEngine.SceneManagement;
using System.Linq;

namespace SceneLoaderIntegrationTests
{
    public class SceneLoaderIntegrationTests
    {
        public string entryScene = "Entry";

        // A Test behaves as an ordinary method
        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneUtils.LoadSceneAdditive(entryScene);
            yield return new WaitForSeconds(3);
        }

        [UnityTearDown]
        public IEnumerator TearDown()
        {
            yield return null;
            Application.Quit();
        }

        [UnityTest]
        [Description("Verify if the main scene is successfully loaded at runtime")]
        public IEnumerator SceneLoader_MainSceneLoadTest()
        {
            //Arrange
            var welcomeHandler = GameObject.FindObjectOfType<WelcomeScreenHandler>();
            welcomeHandler.OnLoadClick();

            //Act
            var sceneLoadingHandler = GameObject.FindObjectOfType<SceneLoadingHandler>();
            yield return new WaitForSeconds(sceneLoadingHandler.minimumDelay);
            yield return new WaitForSeconds(3);
            var activeSceneCount = SceneManager.sceneCount;

            //Assert
            for (int i = 0; i < activeSceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (scene.name.Equals("Demo_MainScene"))
               {
                    Assert.Pass();
                    yield break;
                }
            }
            Assert.Fail();
        }
    }
}
