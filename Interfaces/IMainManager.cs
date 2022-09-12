using Fr.Matthiasdetoffoli.GlobalProjectCode.Interfaces;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Interfaces
{
    /// <summary>
    /// Interface representing the main manager
    /// </summary>
    public interface IMainManager : IManager
    {
        #region Properties
        /// <summary>
        /// The menu manager
        /// </summary>
        MenuManager menuManager
        {
            get;
        }
        #endregion Properties
    }
}
