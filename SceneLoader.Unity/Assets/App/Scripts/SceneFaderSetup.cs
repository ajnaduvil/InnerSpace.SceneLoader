using Innerspace.TestApp.SceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

namespace Innerspace.TestApp
{

    /// <summary>
    /// Sets up scene fader. acquires active camera rig from vrtk and sets up scene fader
    /// </summary>
    [RequireComponent(typeof(SceneFader))]
    public class SceneFaderSetup : MonoBehaviour
    {
        [SerializeField]
        private SceneFader fader;
     
        void Awake()
        {
            VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
        }
        protected virtual void OnEnable()
        {
            //  var activeCameraRig = GameObject.FindGameObjectWithTag("CameraRig");
            var headTransform = VRTK_DeviceFinder.HeadsetCamera();
            var camera = headTransform.GetComponent<Camera>();
            fader.targetCamera = camera;
            fader.Setup();
        }
        protected virtual void OnDestroy()
        {
            VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
        }
    }
}
