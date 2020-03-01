using AVR.Utils.StateMachines;

namespace Innerspace.TestApp.States
{
    public class MainSceneLoadingState : MonoBehaviourState
    {
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
