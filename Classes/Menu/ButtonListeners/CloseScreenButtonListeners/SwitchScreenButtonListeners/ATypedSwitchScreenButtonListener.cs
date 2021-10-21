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
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            //Close the screen to close
            base.OnButtonClicked();

            //open the screen to open
            mScreenToOpen?.Open();
        }

        /// <summary>
        /// Close the parent screen
        /// </summary>
        protected override void CloseParentScreen()
        {
            gameObject.GetComponentInParent<TToClose>()?.Close();
        }

        /// <summary>
        /// Close a screen which is not the parent screen
        /// </summary>
        protected override void CloseNotParentScreen()
        {
            mScreenToClose?.Close();
        }
        #endregion Methods
    }
}
