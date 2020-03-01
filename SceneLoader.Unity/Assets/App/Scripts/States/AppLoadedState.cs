using AVR.Utils.StateMachines;

namespace Innerspace.TestApp.States
{
    public class AppLoadedState : MonoBehaviourState
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
