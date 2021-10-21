using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.OpenScreenButtonListeners
{
    /// <summary>
    /// Button listener which open a screen
    /// </summary>
    /// <typeparam name="T">Type of the screen to open</typeparam>
    /// <seealso cref="AButtonListener"/>
    /// <seealso cref="AMenuScreen"/>
    public abstract class AOpenScreenButtonListener<T> : AButtonListener where T : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// The new screen to open
        /// </summary>
        [SerializeField]
        private T mScreenToOpen;
        #endregion //Fields

        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            //open the screen to open
            mScreenToOpen?.Open();
        }
        #endregion Methods
    }
}
