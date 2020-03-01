using AVR.Utils;
using UnityEngine.SceneManagement;

namespace Innerspace.TestApp.SceneLoader
{
    public class SceneLoader : Singleton<SceneLoader>
    {
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