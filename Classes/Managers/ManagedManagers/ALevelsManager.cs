using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Levels;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// manage all levels
    /// </summary>
    /// <typeparam name="T">the type of the levels managed by the manager</typeparam>
    /// <seealso cref="AManagerWithList{T}"/> 
    /// <seealso cref="ALevelBehavior"/>
    public class ALevelsManager<T> : AManagerWithList<T> where T : ALevelBehavior
    {
        #region Fields
        /// <summary>
        /// The current index selected
        /// </summary>
        private int mCurrentIndexSelected;
        #endregion Fields

        #region Methods
        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake()
        {
            base.Awake();

            mCurrentIndexSelected = -1;

            //Active all pages for call their Awake
            foreach (ALevelBehavior lLevel in items)
            {
                lLevel?.gameObject.SetActive(true);
            }
        }
        #endregion Unity

        /// <summary>
        /// init the manager
        /// </summary>
        /// <remarks>this function is called by the main manager</remarks>
        public override void Init()
        {
            foreach (ALevelBehavior lLevel in items)
            {
                lLevel?.gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Select a level and unselect another one
        /// </summary>
        /// <param name="pIndex"></param>
        public virtual void SelectLevel(int pIndex)
        {
            DeactivateCurrentLevel();

            if (pIndex >= 0 && items.Count > pIndex)
            {
                items[pIndex].Activate();
            }

            mCurrentIndexSelected = pIndex;
        }

        /// <summary>
        /// Clear the current map
        /// </summary>
        public virtual void ClearCurrentLevel()
        {
            DeactivateCurrentLevel();
            mCurrentIndexSelected = -1;
        }

        /// <summary>
        /// Deactivate current level
        /// </summary>
        private void DeactivateCurrentLevel()
        {
            if (mCurrentIndexSelected >= 0 && items.Count > mCurrentIndexSelected)
            {
                items[mCurrentIndexSelected].Deactivate();
            }
        }
        #endregion Methods
    }
}
