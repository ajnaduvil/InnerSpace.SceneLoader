using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Innerspace.TestApp.SceneLoader
{
    /// <summary>
    /// Takes care of the fading of the fader plane.
    /// </summary>
    public class SceneFader : MonoBehaviour
    {
        #region Properties and Fields
        public float fadeInDuration = 1;
        public float fadeOutDuration = 1;
        public Color fadeToColor = Color.black;

        [Header("References")]
        public Camera targetCamera;
        public Animator faderAC;
        public Renderer faderRenderer;
        #endregion

        void Start()
        {
            Assert.IsNotNull(targetCamera);
            Assert.IsNotNull(faderAC);
            //Reset the render plane position to zero
            faderRenderer.transform.localPosition = Vector3.zero;
            //Make sure the position of the fader is closest to the target camera's near clipping plane
            transform.position = targetCamera.transform.position + new Vector3(0, 0, targetCamera.nearClipPlane + 0.05f);
            faderRenderer.material.color = fadeToColor;
        }

        #region Fader Methods
        /// <summary>
        /// Starts fading in
        /// </summary>
        public void FadeIn()
        {
            StartCoroutine(FadeInCoroutine(() =>
            {
                Debug.Log("FadeIn Complete");
            }));
        }
        /// <summary>
        /// Starts fading out the 
        /// </summary>
        public void FadeOut()
        {
            StartCoroutine(FadeOutCoroutine(() =>
            {
                Debug.Log("FadeOut Complete");
            }));
        }
        #endregion

        #region Private Methods
        private IEnumerator FadeInCoroutine(Action fadeInComplete)
        {
            faderAC.speed = 1 / fadeInDuration;
            faderAC.SetBool("isFadeIn", true);
            yield return new WaitForSeconds(fadeInDuration);
            fadeInComplete?.Invoke();
        }

        private IEnumerator FadeOutCoroutine(Action fadeOutComplete)
        {
            faderAC.speed = 1 / fadeOutDuration;
            faderAC.SetBool("isFadeIn", false);
            yield return new WaitForSeconds(fadeOutDuration);
            fadeOutComplete?.Invoke();
        }
        #endregion
    }
}
