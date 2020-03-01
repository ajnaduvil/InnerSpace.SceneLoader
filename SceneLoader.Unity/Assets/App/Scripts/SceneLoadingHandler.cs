using AVR.Utils.StateMachines;
using Innerspace.TestApp.SceneLoader;
using Innerspace.TestApp.States;
using Innerspace.TestApp.ToolTip;
using Innerspace.TestApp.UI;
using System.Collections;
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
        public ToolTipDisplayHandler tooltipDisplayHandler;

        /// <summary>
        /// Starts loading the scene specified in <see cref="sceneIndex"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartLoadingScene()
        {           
            Debug.Log("Starting to load scene at index " + sceneIndex);
            yield return new WaitUntil(() => CameraCache.Instance.Main != null);
            SceneFader.Instance.FadeIn();
            var sceneLoadingOperation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            sceneLoadingOperation.allowSceneActivation = false;
            var timer = StartCoroutine(UpdateProgressbar(minimumDelay));
            hudHandler.EnableHUD();
            tooltipDisplayHandler.StartShowingTooltips();
            yield return timer;
            sceneLoadingOperation.allowSceneActivation = true;
            yield return sceneLoadingOperation;
            tooltipDisplayHandler.StopShowingTooltips();
            hudHandler.DisableHUD();
            SceneFader.Instance.FadeOut();
            StateController.Instance.SwitchState(MainSceneLoadedState.Instance);
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
        private void Start()
        {
            hudHandler.DisableHUD();
        }
    }
}
