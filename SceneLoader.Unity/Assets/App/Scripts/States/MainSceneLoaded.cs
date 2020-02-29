using AVR.Utils.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Innerspace.TestApp.States
{
    public class MainSceneLoaded : MonoBehaviourState
    {
        public static MonoBehaviourState Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
