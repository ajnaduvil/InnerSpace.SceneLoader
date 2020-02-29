using AVR.Utils.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Innerspace.TestApp.States
{
    public class MainSceneLoading : MonoBehaviourState
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

        public SceneLoadingHandler sceneLodingHandler;
        public override void OnEnter()
        {
            base.OnEnter();
            StartCoroutine(sceneLodingHandler.StartLoadingScene());
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
