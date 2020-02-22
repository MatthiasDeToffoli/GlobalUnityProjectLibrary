﻿using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using UnityEngine;
using UnityEngine.UI;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Class listen button click
    /// </summary>
    /// <remarks>see also <seealso cref="AMonoBehaviour"/> annd <see cref="Button"/></remarks>
    [RequireComponent(typeof(Button))]
    public abstract class AButtonListener : AMonoBehaviour
    {
        #region Methods
        /// <summary>
        /// Listen all events here
        /// </summary>
        protected override void ListenToEvents()
        {
            gameObject?.GetComponent<Button>()?.onClick.AddListener(OnButtonClicked);
        }

        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected abstract void OnButtonClicked();

        /// <summary>
        /// unlisten all events here
        /// </summary>
        protected override void UnlistenToEvents()
        {
            gameObject?.GetComponent<Button>()?.onClick.RemoveListener(OnButtonClicked);
        }
        #endregion //Methods
    }
}
