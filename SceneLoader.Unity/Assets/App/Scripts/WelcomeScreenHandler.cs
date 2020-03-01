using AVR.Utils.StateMachines;
using Innerspace.TestApp.States;
using UnityEngine;

namespace Innerspace.TestApp
{
    public class WelcomeScreenHandler : MonoBehaviour
    {
        public void OnLoadClick()
        {
            StateController.Instance.SwitchState(MainSceneLoadingState.Instance);
        }
    }
}
