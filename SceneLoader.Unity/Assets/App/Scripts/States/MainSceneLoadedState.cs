using AVR.Utils.StateMachines;

namespace Innerspace.TestApp.States
{
    public class MainSceneLoadedState : MonoBehaviourState
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
    }
}
