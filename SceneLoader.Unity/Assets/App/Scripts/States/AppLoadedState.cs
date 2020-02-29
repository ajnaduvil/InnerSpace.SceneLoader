using AVR.Utils.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Innerspace.TestApp.States
{
    public class AppLoadedState : MonoBehaviourState
    {
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
