﻿using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// the parent of all menu manager
    /// </summary>
    /// <seealso cref="AManagerWithList{T}"/> 
    /// <seealso cref="AMenuScreen"/>
    public abstract class AMenuManager:AManagerWithList<AMenuScreen>
    {
        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake()
        {
            //Active all pages for call their Awake and start
            foreach(AMenuScreen lPage in items)
            {
                lPage?.gameObject.SetActive(true);
            }
        }
        #endregion Unity

        /// <summary>
        /// init the manager, this function is called by the main manager
        /// </summary>
        public override void Init()
        {
            int l = items.Count;

            //Unactive all screen for unshow them
            if (l > 0)
                for(int i = 1; i < l; i++)
                {
                    items[i].gameObject.SetActive(false);
                }
        }
        #endregion Methods
    }
}
