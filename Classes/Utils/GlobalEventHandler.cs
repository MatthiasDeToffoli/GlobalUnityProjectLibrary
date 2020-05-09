using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils
{
    /// <summary>
    /// Static class keep all global static events wich can be called in the project
    /// </summary>
    public static class GlobalEventHandler
    {
        #region Objects
        /// <summary>
        /// All global static event used in the manager
        /// </summary>
        public static class Manager
        {
            #region Events
            /// <summary>
            /// event fired for tell a managed manager is created (it will be used for add the managed manager in main manager)
            /// </summary>
            public static event Action<AManagedManager> ManagedManagerCreatedEvent;
            #endregion Events

            #region Methods
            /// <summary>
            /// Fire the ManagedManagerCreated Event
            /// </summary>
            /// <param name="pManager">the manager created</param>
            public static void NotifyManagedManagerCreated(AManagedManager pManager)
            {
                if(ManagedManagerCreatedEvent != null)
                {
                    ManagedManagerCreatedEvent.Invoke(pManager);
                }
            }
            #endregion Methods
        }
        #endregion Objects
    }
}
