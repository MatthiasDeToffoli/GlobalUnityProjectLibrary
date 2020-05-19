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
        public T[] objects;
        #endregion Properties
    }
}
