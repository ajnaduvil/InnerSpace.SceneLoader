using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            yield return new WaitUntil(() => CameraCache.Instance.Main != null);
            transform.parent = CameraCache.Instance.Main.transform.parent;
           // transform.localPosition = Vector3.zero;
        }
    }
}
