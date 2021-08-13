using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using UnityEngine;
using UnityEngine.UI;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners
{
    /// <summary>
    /// Class listen button click
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/> 
    /// <seealso cref="Button"/>
    [RequireComponent(typeof(Button))]
    public abstract class AButtonListener : AMonoBehaviour
    {
        #region Fields
        /// <summary>
        /// The button
        /// </summary>
        protected Button mButton;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            mButton = gameObject?.GetComponent<Button>();
        }
        /// <summary>
        /// Listen all events here
        /// </summary>
        protected override void ListenToEvents()
        {
            mButton?.onClick.AddListener(OnButtonClicked);
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
            mButton?.onClick.RemoveListener(OnButtonClicked);
        }
        #endregion Methods
    }
}
