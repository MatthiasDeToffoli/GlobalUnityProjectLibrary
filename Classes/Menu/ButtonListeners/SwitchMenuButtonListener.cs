using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Class used for make a button close a screen and open another one
    /// </summary>
    /// <seealso cref="AButtonListener"/>
    public class SwitchMenuButtonListener : AButtonListener
    {
        #region Fields
        /// <summary>
        /// The new screen to open
        /// </summary>
        [SerializeField]
        private AMenuScreen mScreenToOpen;

        /// <summary>
        /// If the screen to close is the parent of the button or another screen
        /// </summary>
        [SerializeField]
        private bool mScreenToCloseIsParent;
        #endregion //Fields

        #region Properties
        /// <summary>
        /// the screen to close
        /// </summary>
        /// <remarks>if it's the parent the property is not used</remarks>
        [HideInInspector]
        public AMenuScreen screenToClose;
        #endregion Properties

        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            //open the screen to open
            mScreenToOpen?.Open();

            if (mScreenToCloseIsParent)
            {
                //if the screen to close is parent so close the parent
                gameObject.GetComponentInParent<AMenuScreen>()?.Close();
            }
            else
            {
                //else close the screen to close
                screenToClose?.Close();
            }
        }
        #endregion Methods
    }
}
