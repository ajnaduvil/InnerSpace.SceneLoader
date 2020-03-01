using AVR.Utils;
using UnityEngine;
using VRTK;

/// <summary>
/// Finds and stores the main camera reference from VRTK
/// </summary>
public class CameraCache : Singleton<CameraCache>
{
    [HideInInspector]
    public Camera Main;
    public LayerMask mainCameraMask;
    void Awake()
    {
        base.Awake();
        VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
    }
    protected virtual void OnEnable()
    {
        //  var activeCameraRig = GameObject.FindGameObjectWithTag("CameraRig");
        var headTransform = VRTK_DeviceFinder.HeadsetCamera();

        Main = headTransform.GetComponent<Camera>();
        Main.cullingMask = mainCameraMask;
    }
    protected virtual void OnDestroy()
    {
        base.OnDestroy();
        VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
    }
}
