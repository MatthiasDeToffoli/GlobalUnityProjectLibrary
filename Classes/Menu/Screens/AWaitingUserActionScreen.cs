using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens
{
    /// <summary>
    /// Screen waiting an user action to do something
    /// </summary>
    /// <seealso cref="AMenuScreen"/>
    public abstract class AWaitingUserActionScreen : AMenuScreen, IPointerClickHandler
    {
        #region Fields
        /// <summary>
        /// If we allow click and touch or not
        /// </summary>
        [SerializeField]
        private bool mAllowClickAndTouch;

        /// <summary>
        /// If we allow the keyboard or not
        /// </summary>
        [SerializeField]
        private bool mAllowKeyboard;

        /// <summary>
        /// The UI text on the screen
        /// </summary>
        [SerializeField]
        private Text mTextHandler;

        /// <summary>
        /// The text show at first when we wait the user action
        /// </summary>
        [SerializeField]
        private string mWaitingText;

        /// <summary>
        /// The text show when we load stuff if we had to
        /// </summary>
        [SerializeField]
        private string mLoadingText;
        #endregion Fields

        #region Methods
        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            SetTextHandlerText(mWaitingText);
        }

        /// <summary>
        /// Update of the behavior
        /// </summary>
        public void Update()
        {
            if (Input.anyKey)
            {
                if(!Input.GetKey(KeyCode.Mouse0)
                    && !Input.GetKey(KeyCode.Mouse1) 
                    && !Input.GetKey(KeyCode.Mouse2)
                    && !Input.GetKey(KeyCode.Mouse3)
                    && !Input.GetKey(KeyCode.Mouse4)
                    && !Input.GetKey(KeyCode.Mouse5)
                    && !Input.GetKey(KeyCode.Mouse6)
                    && mAllowKeyboard)
                {
                    StartLoading();
                }
            }
        }
        /// <summary>
        /// WHen the pointer click on the screen
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            if (mAllowClickAndTouch)
            {
                StartLoading();
            }
        }
        #endregion Unity

        /// <summary>
        /// Start the loading
        /// </summary>
        protected void StartLoading()
        {
            SetTextHandlerText(mLoadingText);
            LoadingEnded(true);
        }

        /// <summary>
        /// Set the text handler text
        /// </summary>
        /// <param name="pText"></param>
        protected void SetTextHandlerText(string pText)
        {
            if(mTextHandler != null)
            {
                mTextHandler.text = pText;
            }
        }

        /// <summary>
        /// Call when the loading ended
        /// </summary>
        /// <param name="pSucceed"><c>True</c> if the loading succeed, <c>False</c> otherwise</param>
        protected abstract void LoadingEnded(bool pSucceed);
        #endregion Methods
    }
}
