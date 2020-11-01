using System;
using System.Collections.Generic;
using System.Text;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.BooleanButtonListeners
{
    /// <summary>
    /// Boolean button listener which only sent false
    /// </summary>
    /// <seealso cref="ABooleanButtonListener"/>
    public class InvalidateButtonListener : ABooleanButtonListener
    {
        #region Fields
        /// <summary>
        /// The state of the button
        /// </summary>
        protected override bool mState
        {
            get
            {
                return false;
            }
        }
        #endregion Fields
    }
}
