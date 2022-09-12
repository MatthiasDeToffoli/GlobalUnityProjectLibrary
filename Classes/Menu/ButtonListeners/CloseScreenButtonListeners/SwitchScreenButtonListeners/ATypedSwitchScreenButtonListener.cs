using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.CloseScreenButtonListeners.SwitchScreenButtonListeners
{
    /// <summary>
    /// SwitchScreenButtonListener
    /// </summary>
    /// <typeparam name="TToOpen">Type of the screen to open</typeparam>
    /// <typeparam name="TToClose">Type of the screen to close</typeparam>
    /// <seealso cref="ASwitchScreenButtonListener"/>
    /// <seealso cref="AMenuScreen"/>
    /// <remarks>We don't use <see cref="ATypedCloseScreenButtonListener{T}"/> for can add the class in the editor</remarks>
    public abstract class ATypedSwitchScreenButtonListener<TToOpen,TToClose> : ASwitchScreenButtonListener
        where TToOpen : AMenuScreen 
        where TToClose : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// The new screen to open
        /// </summary>
        [SerializeField]
        private TToOpen mScreenToOpen;

        /// <summary>
        /// the screen to close
        /// </summary>
        /// <remarks>if it's the parent the property is not used</remarks>
        [SerializeField]
        private TToClose mScreenToClose;
        #endregion //Fields

        #region Methods
        /// <summary>
        /// Close the parent screen
        /// </summary>
        protected override void CloseParentScreen()
        {
            SwitchScreen(gameObject.GetComponentInParent<TToClose>());
        }

        /// <summary>
        /// Close a screen which is not the parent screen
        /// </summary>
        protected override void CloseNotParentScreen()
        {
            SwitchScreen(mScreenToClose);
        }

        /// <summary>
        /// Sweetch the screens
        /// </summary>
        /// <param name="pScreenToClose">the screen to close</param>
        private void SwitchScreen(AMenuScreen pScreenToClose)
        {
            mMainManager?.menuManager?.SwitchScreen(pScreenToClose, mScreenToOpen);
        }
        #endregion Methods
    }
}
