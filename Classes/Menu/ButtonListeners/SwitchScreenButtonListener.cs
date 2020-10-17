using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Class used for make a button close a screen and open another one
    /// </summary>
    /// <seealso cref="CloseScreenButtonListener"/>
    public class SwitchScreenButtonListener : CloseScreenButtonListener
    {
        #region Fields
        /// <summary>
        /// The new screen to open
        /// </summary>
        [SerializeField]
        private AMenuScreen mScreenToOpen;
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
        #endregion Methods
    }
}
