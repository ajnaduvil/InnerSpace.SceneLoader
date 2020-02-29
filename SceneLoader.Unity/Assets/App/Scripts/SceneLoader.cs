using AVR.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Innerspace.TestApp.SceneLoader
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        #region Scene Loader Methods
        public void StartLoadingScene(string sceneName,LoadSceneMode sceneMode)
        {
           
            var sceneloadOperation = SceneManager.LoadSceneAsync(sceneName,sceneMode);
            sceneloadOperation.completed += (loadOperation) =>
            {

            };

        }

        #endregion
    }
}