using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.BooleanButtonListeners;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens
{
    /// <summary>
    /// Screen show for validate or not
    /// </summary>
    /// <seealso cref="AMenuScreen"/>
    public abstract class AValidationScreen : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// The validate button
        /// </summary>
        [CustomLabel("Validate Button")]
        [SerializeField]
        private ValidateButtonListener mValidateBtn;

        /// <summary>
        /// The invalidate button
        /// </summary>
        [CustomLabel("Invalidate Button")]
        [SerializeField]
        private InvalidateButtonListener mInvalidateBtn;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Listen all the events
        /// </summary>
        protected override void ListenToEvents()
        {
            if(mValidateBtn != null)
                mValidateBtn.OnClick += OnValidation;


            if (mInvalidateBtn != null)
                mInvalidateBtn.OnClick += OnValidation;
        }

        /// <summary>
        /// Unlisten all the events
        /// </summary>
        protected override void UnlistenToEvents()
        {
            if (mValidateBtn != null)
                mValidateBtn.OnClick -= OnValidation;


            if (mInvalidateBtn != null)
                mInvalidateBtn.OnClick -= OnValidation;
        }

        /// <summary>
        /// When a validation button was clicked
        /// </summary>
        /// <param name="pState"></param>
        protected abstract void OnValidation(bool pState);
        #endregion Methods
    }
}
