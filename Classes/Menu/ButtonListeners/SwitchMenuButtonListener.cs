using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    public class SwitchMenuButtonListener : AButtonListener
    {
        #region Properties
        [SerializeField]
        private AMenuScreen screenToOpen;
        [SerializeField]
        private bool screenToCloseIsParent;
        [HideInInspector]
        public AMenuScreen screenToClose;
        #endregion //Properties

        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake(){}

        /// <summary>
        /// Call the frame after the start
        /// </summary>
        protected override void AfterStart(){}

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
