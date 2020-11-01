using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.BooleanButtonListeners
{
    /// <summary>
    /// A Boolean button listener which can be configurable in the inspector
    /// </summary>
    /// <seealso cref="ABooleanButtonListener"/>
    public class BooleanButtonListenerConfigurable : ABooleanButtonListener
    {
        #region Fields
        /// <summary>
        /// The state of the button
        /// </summary>
        [CustomLabel("State")]
        [SerializeField]
        protected bool mConfigurableState;

        /// <summary>
        /// The state of the button
        /// </summary>
        protected override bool mState
        {
            get
            {
                return mConfigurableState;
            }
        }
        #endregion Fields
    }
}
