using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// the parent of all menu manager
    /// </summary>
    /// <remarks>see also <seealso cref="AManagerWithList{T}"/> and <see cref="AMenuScreen"/></remarks>
    public abstract class AMenuManager:AManagerWithList<AMenuScreen>
    {
        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake()
        {
            //Active all pages for call their Awake and start
            foreach(AMenuScreen lPage in objects)
            {
                lPage?.gameObject.SetActive(true);
            }
        }

        /// <summary>
        /// init the manager, this function is called by the main manager
        /// </summary>
        public override void Init()
        {
            int l = objects.Length;

            //Unactive all screen for unshow them
            if (l > 0)
                for(int i = 1; i < l; i++)
                {
                    objects[i].gameObject.SetActive(false);
                }
        }
        #endregion //Methods
    }
}
