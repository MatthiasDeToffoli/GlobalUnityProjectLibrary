using System.Collections.Generic;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// Parent of all manager wich manage an objects array
    /// </summary>
    /// <typeparam name="T">the type of the object managed by the manager</typeparam>
    /// <seealso cref="AManagedManager"/>
    public abstract class AManagerWithList<T> : AManagedManager
    {
        #region Properties
        /// <summary>
        /// the list of object managed by the manager
        /// </summary>
        public List<T> items;
        #endregion Properties

        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            items = new List<T>();
        }
        #endregion Methods
    }
}
