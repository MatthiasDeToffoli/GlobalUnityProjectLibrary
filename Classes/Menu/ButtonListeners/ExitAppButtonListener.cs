using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    public class ExitAppButtonListener : AButtonListener
    {
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
            Application.Quit();
        }
        #endregion //Methods
    }
}
