using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Innerspace.TestApp
{
    public class SkyboxChanger : MonoBehaviour
    {
        // Start is called before the first frame update
        public Material skyboxMaterial;

        public void SetSkybox()
        {
            RenderSettings.skybox = skyboxMaterial;
        }
    }
}

