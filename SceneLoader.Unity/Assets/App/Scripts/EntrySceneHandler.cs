using Innerspace.TestApp.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
namespace Innerspace.TestApp
{
    public class EntrySceneHandler : MonoBehaviour
    {
        public int sceneIndexToLoad;

        /// <summary>
        /// Makes sure the main camera reference is resolved and loads init scene
        /// </summary>
        /// <returns></returns>
        public IEnumerator Start()
        {
            yield return new WaitUntil(() => CameraCache.Main != null);
            yield return SceneManager.LoadSceneAsync(sceneIndexToLoad, LoadSceneMode.Additive);
        }
    }
}
