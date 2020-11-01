namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.BooleanButtonListeners
{
    /// <summary>
    /// Delegate will send the state of the button listener
    /// </summary>
    /// <param name="pState">the state to send</param>
    public delegate void SendStateDelegate(bool pState);

    /// <summary>
    /// Button listener which send a boolean
    /// </summary>
    /// <seealso cref="AButtonListener"/>
    public abstract class ABooleanButtonListener : AButtonListener
    {
        #region Events
        /// <summary>
        /// event fire when we click on the button
        /// </summary>
        public event SendStateDelegate OnClick;
        #endregion Events

        #region Fields
        /// <summary>
        /// The state of the button
        /// </summary>
        protected virtual bool mState
        {
            get;
            set;
        }
        #endregion Fields

        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            if(OnClick != null)
            {
                OnClick.Invoke(mState);
            }
        }
        #endregion Methods
    }
}
