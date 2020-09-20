using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils.Enums;
using System;
using System.Collections;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks
{
    /// <summary>
    /// Visual feedback which is unshow after a time
    /// </summary>
    /// <seealso cref="AVisualFeedBack"/> 
    public abstract class AShortLivedVisualFeedback : AVisualFeedBack
    {
        #region Fields
        /// <summary>
        /// The type of wait for the coroutine
        /// </summary>
        protected CoroutineTypeOfWait mTypeOfWait;

        /// <summary>
        /// The time to wait for the couroutine
        /// </summary>
        protected float mTimeToWait;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The instance of the coroutine
        /// </summary>
        public IEnumerator coroutineUnShowInstance;
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="AShortLivedVisualFeedback"/>
        /// </summary>
        /// <param name="pPoolManager"></param>
        /// <param name="pTypeOfWait"></param>
        /// <param name="pTime"></param>
        public AShortLivedVisualFeedback(IPoolManager pPoolManager, CoroutineTypeOfWait pTypeOfWait, float pTime) 
            : base(pPoolManager)
        {
            mTypeOfWait = pTypeOfWait;
            mTimeToWait = pTime;
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Show the visual feed back
        /// </summary>
        /// <param name="pNewTransform">the transforms contains position size and rotation of the feed back</param>
        /// <remarks>it search a game object in the pool</remarks>
        public override GameObject Show(Transform pNewTransform)
        {
            GameObject lGO = base.Show(pNewTransform);
            coroutineUnShowInstance = UnShowCoroutine(lGO);
            return lGO;
        }

        /// <summary>
        /// Unshow the feedback
        /// </summary>
        /// <param name="pObject">the object to unshow</param>
        public override void UnShow(GameObject pObject)
        {
            
            base.UnShow(pObject);
        }

        /// <summary>
        /// The coroutine for call unshow
        /// </summary>
        /// <param name="pObject">the object to unshow</param>
        /// <returns></returns>
        private IEnumerator UnShowCoroutine(GameObject pObject)
        {
            if(mTypeOfWait == CoroutineTypeOfWait.SECONDS)
            {
                yield return new WaitForSeconds(mTimeToWait);
            }
            else
            {
                for(int i = 0; i < mTimeToWait; i++)
                {
                    switch (mTypeOfWait)
                    {
                        case CoroutineTypeOfWait.END_OF_FRAME:
                            yield return new WaitForEndOfFrame();
                            break;

                        case CoroutineTypeOfWait.FIXED_UPDATE:
                            yield return new WaitForFixedUpdate();
                            break;
                    }
                }
            }

            UnShow(pObject);
        }
        #endregion Methods
    }
}
