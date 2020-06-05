using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers
{
    /// <summary>
    /// The main manager will managed all the manager
    /// </summary>
    /// <typeparam name="TMain">the type of the main manager use for the singleton instance</typeparam>
    /// <seealso cref="AMonoBehaviourSingleton{T}"/>
    public abstract class AMainManager<TMain> : AMonoBehaviourSingleton<TMain>, IManager where TMain : AMonoBehaviour, IManager, ISingleton
    {
        #region Properties
        /// <summary>
        /// All managers managed by the main manager
        /// </summary>
        [HideInInspector]
        public List<AManagedManager> managers;

        /// <summary>
        /// the current state of the game
        /// </summary>
        [HideInInspector]
        public GameState currentGameState;
        #endregion Properties

        #region Method

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake()
        {
            base.Awake();
            managers = new List<AManagedManager>();
            managers.AddRange(FindObjectsOfType<AManagedManager>());
            currentGameState = GameState.LOADING;
        }
        #endregion Unity

        /// <summary>
        /// Add the manager in the current list
        /// </summary>
        /// <param name="pManager">the manager to add</param>
        public void AddManagedManager(AManagedManager pManager)
        {
            managers.Add(pManager);
        }

        /// <summary>
        /// Call the frame after the start
        /// </summary>
        protected override void AfterStart()
        {
            base.AfterStart();
            managers.Sort(SortByInitOrder);
            Init();
        }

        /// <summary>
        /// Function used for sort the managers by they init order
        /// </summary>
        /// <param name="pElemA">the first element to compare</param>
        /// <param name="pElemB">the second element to compare</param>
        /// <returns><c>-1</c> if element A have to have an index smaller than Elem B, <c>0</c> if element A and B have the same init order, <c>1</c> otherwhise</returns>
        private int SortByInitOrder(AManagedManager pElemA, AManagedManager pElemB)
        {
            uint lAOrder = pElemA.initOrder;
            uint lBOrder = pElemB.initOrder;

            if(lAOrder < lBOrder)
            {
                return -1;
            }

            if(lAOrder == lBOrder)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// init the manager
        /// </summary>
        public void Init()
        {
            //init all manager in the good order
            foreach(AManagedManager lManager in managers)
            {
                lManager.Init();
            }
        }

        /// <summary>
        /// Get the first manager
        /// </summary>
        /// <returns>the first manager</returns>
        public AManagedManager GetFirstManager()
        {
            if(managers.Count > 0)
            {
                return managers[0];
            }

            return null;
        }

        /// <summary>
        /// get the first manager of a specified type
        /// </summary>
        /// <typeparam name="TMangaged">the type of the manager we want</typeparam>
        /// <returns>the first manager of the type set</returns>
        public TMangaged GetFirstManager<TMangaged>() where TMangaged : AManagedManager
        {
            foreach(AManagedManager lManager in managers)
            {
                if(lManager is TMangaged)
                {
                    return lManager as TMangaged;
                }
            }

            return null;
        }

        /// <summary>
        /// Clear the Manager properties
        /// </summary>
        public virtual void Clear()
        {
            foreach(AManagedManager lManaged in managers)
            {
                lManaged.Clear();
            }

            managers.Clear();
        }
        #endregion Methods
    }
}
