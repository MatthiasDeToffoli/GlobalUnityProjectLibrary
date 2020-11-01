using Fr.Matthiasdetoffoli.GlobalProjectCode.Classes.Pooling;
using Fr.Matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using Fr.Matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling.PoolElements;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Pooling
{
    /// <summary>
    /// Manage all the pools
    /// </summary>
    /// <typeparam name="T">the type of the initializer</typeparam>
    public abstract class APoolManager<T> : AManagedManager, IPoolManager where T:PoolInitializerContainer
    {
        #region Constants
        /// <summary>
        /// Error showed when you try to stock an element in the pool which never was in it
        /// </summary>
        private const string ERROR_STOCK_UNKNOW = "You try to stock an element which is not in the pool, if you want to create a new pool use the init container";
        #endregion Constants

        #region Fields
        /// <summary>
        /// The initializer container
        /// </summary>
        [SerializeField]
        protected T mInitContainer;

        /// <summary>
        /// The pool container
        /// </summary>
        protected PoolContainer mContainer;
        #endregion Fields

        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            mContainer = new PoolContainer(mInitContainer);
        }
        #endregion Unity

        /// <summary>
        /// Create and Init the pool
        /// </summary>
        public void CreatePool()
        {
            mContainer.Init();
        }

        /// <summary>
        /// Get a pool element
        /// </summary>
        /// <typeparam name="T">the type of the element</typeparam>
        /// <param name="pRef">the id of the element</param>
        /// <returns>the pool element</returns>
        public T GetElement<T>(string pRef) where T : class
        {
            return mContainer.Get<T>(pRef);
        }

        /// <summary>
        /// Stock an element in the pool
        /// </summary>
        /// <param name="pRef">the id of the element</param>
        /// <param name="pElm">the element to stock</param>
        public void StockElement(string pRef, object pElm)
        {
            IPoolElement lElm = mInitContainer.Get<IPoolElement>(pRef);

            if(lElm == null)
            {
                Debug.LogError(ERROR_STOCK_UNKNOW);
            }
            else
            {
                lElm.Reset(pElm);
                mContainer.Add(pRef, pElm);
            }
        }
        #endregion Methods
    }
}
