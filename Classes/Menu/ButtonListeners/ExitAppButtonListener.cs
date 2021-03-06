﻿using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Component used for make a button close the app
    /// </summary> 
    /// <seealso cref="AButtonListener"/>
    public class ExitAppButtonListener : AButtonListener
    {
        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            Application.Quit();
        }
        #endregion Methods
    }
}
