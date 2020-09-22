using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using System;
using System.Security.Cryptography;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks
{
    /// <summary>
    /// Parent of all visual feed backs managed by the code
    /// </summary>
    public abstract class AVisualFeedBack
    {
        #region Fields
        /// <summary>
        /// The pool manager
        /// </summary>
        private IPoolManager mPoolManager;

        /// <summary>
        /// The ID of the pool for get the visual feedback
        /// </summary>
        protected abstract string mPoolID
        {
            get;
        }
        #endregion Fields

        #region Properties
        /// <summary>
        /// THe unic id of the feeback
        /// </summary>
        public string unicId
        {
            get;
            private set;
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="AVisualFeedBack"/>
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        public AVisualFeedBack(IPoolManager pPoolManager)
        {
            mPoolManager = pPoolManager;
            unicId = Guid.NewGuid().ToString();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Show the visual feed back
        /// </summary>
        /// <param name="pNewTransform">the transforms contains position size and rotation of the feed back</param>
        /// <remarks>it search a game object in the pool</remarks>
        public virtual GameObject Show(Transform pNewTransform)
        {
            GameObject lGO = null;

            if (mPoolManager != null)
            {
                //Get the gameobject from the pool
                 lGO = mPoolManager.GetElement<GameObject>(mPoolID);

                //set the local scale
                lGO.transform.localScale = pNewTransform.localScale;

                //Set the new position
                lGO.transform.position = pNewTransform.position;

                //Set the rotation
                lGO.transform.rotation = pNewTransform.rotation;

                lGO.SetActive(true);
            }

            return lGO;
        }

        /// <summary>
        /// Unshow the feedback
        /// </summary>
        /// <param name="pObject">the object to unshow</param>
        public virtual void UnShow(GameObject pObject)
        {
            if(mPoolManager != null)
            {
                mPoolManager.StockElement(mPoolID, pObject);
            }
        }
        #endregion Methods
    }
}
