using fr.matthiasdetoffoli.GlobalProjectCode.Classes.Pooling;
using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling.PoolElements;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Pooling
{
    /// <summary>
    /// Used for initialized the pool (already contain a list of gameobject)
    /// </summary>
    /// <seealso cref="APoolInitializerContainer"/>
    [Serializable]
    public class PoolInitializerContainer : APoolInitializerContainer
    {
        #region Fields
        /// <summary>
        /// The game objects pool initializer
        /// </summary>
        [SerializeField]
        protected List<GameObjectPoolElement> mGameObjectsPoolInitializer;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The list of pool elements
        /// </summary>
        public override List<IPoolElement> elements
        {
            get
            {
                return mGameObjectsPoolInitializer.ToList<IPoolElement>();
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Add item to the list
        /// </summary>
        /// <param name="pItem">the item to add</param>
        public override void Add(IPoolElement pItem)
        {
            if(pItem is GameObjectPoolElement)
            {
                Add(pItem as GameObjectPoolElement);
            }
        }

        /// <summary>
        /// Add item to the list
        /// </summary>
        /// <param name="pItem">the item to add</param>
        public void Add(GameObjectPoolElement pItem)
        {
            mGameObjectsPoolInitializer.Add(pItem);
        }
        #endregion Methods
    }
}
