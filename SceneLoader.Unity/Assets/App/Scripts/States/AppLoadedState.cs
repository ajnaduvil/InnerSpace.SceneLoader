using AVR.Utils.StateMachines;
using UnityEngine;

namespace Innerspace.TestApp.States
{
    public class AppLoadedState : MonoBehaviourState
    {
        [SerializeField]
        internal SkyboxChanger skyboxChanger;
        #region Singleton
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
        #endregion

        public override void OnEnter()
        {
            base.OnEnter();
            skyboxChanger.SetSkybox();
        }

    }
}
