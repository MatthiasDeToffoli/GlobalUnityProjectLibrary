using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Class used for make a button close a screen
    /// </summary>
    /// <seealso cref="AButtonListener"/>
    public class CloseScreenButtonListener : AButtonListener
    {
        #region Fields
        /// <summary>
        /// If the screen to close is the parent of the button or another screen
        /// </summary>
        [SerializeField]
        private bool mScreenToCloseIsParent;

        /// <summary>
        /// the screen to close
        /// </summary>
        /// <remarks>if it's the parent the property is not used</remarks>
        [SerializeField]
        private AMenuScreen mScreenToClose;
        #endregion //Fields

        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            if (mScreenToCloseIsParent)
            {
                //if the screen to close is parent so close the parent
                gameObject.GetComponentInParent<AMenuScreen>()?.Close();
            }
            else
            {
                //else close the screen to close
                mScreenToClose?.Close();
            }
        }
        #endregion Methods
    }
}
