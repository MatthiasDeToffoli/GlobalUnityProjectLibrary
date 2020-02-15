using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu
{
    /// <summary>
    /// Parent of all menu screen, implement methods for open and close
    /// </summary>
    public abstract class AMenuScreen : AMonoBehaviour
    {
        #region Methods
        /// <summary>
        /// show the screen
        /// </summary>
        public void Open()
        {
            gameObject?.SetActive(true);
        }

        /// <summary>
        /// unshow the screen
        /// </summary>
        public void Close()
        {
            gameObject?.SetActive(false);
        }
        #endregion //Methods
    }
}
