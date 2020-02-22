using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Class used for make a button close a screen and open another one
    /// </summary>
    /// <remarks>see also <seealso cref="AButtonListener"/></remarks>
    public class SwitchMenuButtonListener : AButtonListener
    {
        #region Const
        /// <summary>
        /// string of the variale screenToCloseIsParent
        /// </summary>
        public const string STRING_TO_CLOSE_IS_PARENT = "screenToCloseIsParent";

        /// <summary>
        /// string of the variale screenToClose
        /// </summary>
        public const string STRING_TO_CLOSE = "screenToClose";

        /// <summary>
        /// the title show in inspector for the screen to close property
        /// </summary>
        public const string STRING_TO_CLOSE_TITLE = "Screen to close";
        #endregion //Const

        #region Properties
        /// <summary>
        /// The new screen to open
        /// </summary>
        [SerializeField]
        private AMenuScreen screenToOpen;

        /// <summary>
        /// If the screen to close is the parent of the button or another screen
        /// </summary>
        [SerializeField]
        private bool screenToCloseIsParent;

        /// <summary>
        /// the screen to close
        /// </summary>
        /// <remarks>if it's the parent the property is not used</remarks>
        [HideInInspector]
        public AMenuScreen screenToClose;
        #endregion //Properties

        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            //open the screen to open
            screenToOpen?.Open();

            if (screenToCloseIsParent)
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
        #endregion //Methods
    }
}
