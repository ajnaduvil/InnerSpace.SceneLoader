using AVR.Utils.StateMachines;
using Innerspace.TestApp.SceneLoader;
using Innerspace.TestApp.States;
using Innerspace.TestApp.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Innerspace.TestApp
{
    /// <summary>
    /// Handles the mainscene loading. Additively loads the main scene speciefied in <see cref="sceneIndex"/> 
    /// Takes care of displaying progress bar and tooltips
    /// </summary>
    public class SceneLoadingHandler : MonoBehaviour
    {

        // Scene index to be additively loaded
        public int sceneIndex;
        /// <summary>
        /// Minimum delay required to load the main scene. If the scene is loaded before it waits till fading out to the next scene.
        /// </summary>
        public float minimumDelay = 15f;
        // Start is called before the first frame update


        [Header("References")]
        public HUDHandler hudHandler;

        /// <summary>
        /// Starts loading the scene specified in <see cref="sceneIndex"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartLoadingScene()
        {
            ///Fade screen
            ///Load scene
            ///Update progress while loading
            ///Start showing loading hud
            ///Show progresbar
            ///show hud
            ///Switch State to loaded
            SceneFader.Instance.FadeIn();
            var sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            sceneLoadingOperation.allowSceneActivation = false;
            var timer = StartCoroutine(UpdateProgressbar(minimumDelay));
            hudHandler.EnableHUD();
            yield return timer;
            sceneLoadingOperation.allowSceneActivation = true;
            yield return sceneLoadingOperation;           

            hudHandler.DisableHUD();
            SceneFader.Instance.FadeOut();
            StateController.Instance.SwitchState(MainSceneLoaded.Instance);
        }

        /// <summary>
        /// Updates the progressbar with  <paramref name="timeDuration"/>"/>
        /// </summary>
        /// <param name="timeDuration">Duration in seconds</param>
        /// <returns></returns>
        private IEnumerator UpdateProgressbar(float timeDuration)
        {
            var time = 0f;
            while (time < minimumDelay)
            {
                time += Time.deltaTime;
                hudHandler.progressbar.Progress = time / timeDuration;
                yield return null;
            }
        }
    }
}
