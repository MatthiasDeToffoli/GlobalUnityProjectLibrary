using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens
{
    /// <summary>
    /// Parent of all menu screen, implement methods for open and close
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/>
    public abstract class AMenuScreen : AMonoBehaviour
    {
        #region Methods
        /// <summary>
        /// show the screen
        /// </summary>
        public virtual void Open(params object[] pParams)
        {
            gameObject?.SetActive(true);
        }

        /// <summary>
        /// unshow the screen
        /// </summary>
        public virtual void Close()
        {
            gameObject?.SetActive(false);
        }
        #endregion Methods
    }
}
