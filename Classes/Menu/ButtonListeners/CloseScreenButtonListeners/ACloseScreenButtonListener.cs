using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.CloseScreenButtonListeners
{
    /// <summary>
    /// Class used for make a button close a screen
    /// </summary>
    public abstract class ACloseScreenButtonListener : AMenuInteractibleButtonListener
    {
        #region Fields
        /// <summary>
        /// If the screen to close is the parent of the button or another screen
        /// </summary>
        [SerializeField]
        private bool mScreenToCloseIsParent;
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
                CloseParentScreen();
            }
            else
            {
                //else close the screen to close
                CloseNotParentScreen();
            }
        }

        /// <summary>
        /// Close the parent screen
        /// </summary>
        protected abstract void CloseParentScreen();

        /// <summary>
        /// Close a screen which is not the parent screen
        /// </summary>
        protected abstract void CloseNotParentScreen();

        /// <summary>
        /// Close a screen
        /// </summary>
        /// <param name="pScreenToClose">Screen to close</param>
        protected void CloseScreen(AMenuScreen pScreenToClose)
        {
            mMainManager?.menuManager?.CloseScreen(pScreenToClose);
        }
        #endregion Methods
    }
}
