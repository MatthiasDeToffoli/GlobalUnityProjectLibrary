using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Button listener which interact with menu
    /// </summary>
    public abstract class AMenuInteractibleButtonListener : AButtonListener
    {
        #region Fields
        /// <summary>
        /// Get the main manager
        /// </summary>
        protected abstract IMainManager mMainManager
        {
            get;
        }
        #endregion Fields
    }
}
