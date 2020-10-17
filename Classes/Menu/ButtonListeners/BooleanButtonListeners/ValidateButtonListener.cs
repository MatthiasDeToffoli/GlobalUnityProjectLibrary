using System;
using System.Collections.Generic;
using System.Text;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.BooleanButtonListeners
{
    /// <summary>
    /// Button listener which only sent true
    /// </summary>
    /// <seealso cref="ABooleanButtonListener"/>
    public class ValidateButtonListener : ABooleanButtonListener
    {
        #region Fields
        /// <summary>
        /// The state of the button
        /// </summary>
        protected override bool mState 
        { 
            get
            {
                return true;
            }
        }
        #endregion Fields
    }
}
