using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// Abstract class for all managers managed by the <see cref="Managers.AMainManager{TMain}" />
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/>
    /// <seealso cref="IManager"/>
    public abstract class AManagedManager: AMonoBehaviour, IManager
    {
        #region Properties
        /// <summary>
        /// The order the main manager will call the init method
        /// </summary>
        public uint initOrder;
        #endregion Properties

        #region Methods
        /// <summary>
        /// init the manager, this function is called by the main manager
        /// </summary>
        public virtual void Init() { }

        /// <summary>
        /// Clear the manager
        /// </summary>
        public virtual void Clear() { }
        #endregion Methods
    }
}
