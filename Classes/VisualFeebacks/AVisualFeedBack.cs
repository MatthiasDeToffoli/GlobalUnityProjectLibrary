using Fr.Matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using System;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks
{
    /// <summary>
    /// Parent of all visual feed backs managed by the code
    /// </summary>
    public abstract class AVisualFeedBack
    {
        #region Fields
        /// <summary>
        /// The ID of the pool for get the visual feedback
        /// </summary>
        protected abstract string mPoolID
        {
            get;
        }

        /// <summary>
        /// the game object of the feedback show
        /// </summary>
        protected GameObject mObject;
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
        public AVisualFeedBack()
        {
            unicId = Guid.NewGuid().ToString();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Show the visual feed back
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        /// <param name="pTransform">the transforms contains position size and rotation of the feed back</param>
        /// <remarks>it search a game object in the pool</remarks>
        public virtual void Show(IPoolManager pPoolManager, Transform pTransform)
        {
            Show(pPoolManager, pTransform.localScale, pTransform.position, pTransform.rotation);
        }

        /// <summary>
        /// Show the visual feed back
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        /// <param name="pScale">the scale of the feedback</param>
        /// <param name="pPosition">the position of the feddback</param>
        /// <param name="pRotation">the rotation of the feedback</param>
        /// <remarks>it search a game object in the pool</remarks>
        public virtual void Show(IPoolManager pPoolManager, Vector3 pScale, Vector3 pPosition, Quaternion pRotation)
        {
            if (pPoolManager != null)
            {
                //Get the gameobject from the pool
                mObject = pPoolManager.GetElement<GameObject>(mPoolID);

                //set the local scale
                mObject.transform.localScale = pScale;

                //Set the new position
                mObject.transform.position = pPosition;

                //Set the rotation
                mObject.transform.rotation = pRotation;

                mObject.SetActive(true);
            }
        }

        /// <summary>
        /// Unshow the feedback
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        public virtual void UnShow(IPoolManager pPoolManager)
        {
            if(pPoolManager != null)
            {
                pPoolManager.StockElement(mPoolID, mObject);
                mObject = null;
            }
        }
        #endregion Methods
    }
}
