using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.CloseScreenButtonListeners
{
    /// <summary>
    /// Class used for make a button close a screen
    /// </summary>
    /// <typeparam name="T">the type of the screen to close</typeparam>
    /// <seealso cref="ACloseScreenButtonListener"/>
    /// <seealso cref="AMenuScreen"/>
    public abstract class ATypedCloseScreenButtonListener<T> : ACloseScreenButtonListener where T : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// the screen to close
        /// </summary>
        /// <remarks>if it's the parent the property is not used</remarks>
        [SerializeField]
        private T mScreenToClose;
        #endregion //Fields

        #region Methods
        /// <summary>
        /// Close the parent screen
        /// </summary>
        protected override void CloseParentScreen()
        {
            CloseScreen(gameObject.GetComponentInParent<T>());
        }

        /// <summary>
        /// Close a screen which is not the parent screen
        /// </summary>
        protected override void CloseNotParentScreen()
        {
            CloseScreen(mScreenToClose);
        }
        #endregion Methods
    }
}
