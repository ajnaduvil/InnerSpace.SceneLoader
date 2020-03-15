using System.Collections;
using UnityEngine;
using Innerspace.TestApp.Utils;
namespace Innerspace.TestApp
{
    /// <summary>
    /// Sets up the HUD Camera under the active main camera
    /// </summary>
    public class HUDCamera : MonoBehaviour
    {
        IEnumerator Start()
        {
            yield return SetupHUDCamera();
        }

        IEnumerator SetupHUDCamera()
        {
            yield return new WaitUntil(() => CameraCache.Main != null);
            transform.parent = CameraCache.Main.transform.parent;
        }
    }
}
