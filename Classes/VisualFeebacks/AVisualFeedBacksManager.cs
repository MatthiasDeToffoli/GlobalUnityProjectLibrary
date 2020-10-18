using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Linq;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks
{
    /// <summary>
    /// Abstract class use for manage all visual feedback
    /// </summary>
    /// <seealso cref="AManagerWithList{T}"/>
    public abstract class AVisualFeedBacksManager : AManagerWithList<AVisualFeedBack>
    {
        #region Fields
        /// <summary>
        /// The pool manager
        /// </summary>
        protected abstract IPoolManager mPoolManager
        {
            get;
            set;
        }
        #endregion Fields

        #region Methods
        /// <summary>
        /// Show a feed back
        /// </summary>
        /// <param name="pFeedBack">the feed back to show</param>
        /// <param name="pTransform">the transform for place the feed back</param>
        /// <returns>the unic id of the feedback</returns>
        public virtual string ShowFeedBack(AVisualFeedBack pFeedBack, Transform pTransform)
        {
            pFeedBack.Show(mPoolManager, pTransform);
            items.Add(pFeedBack);
            return pFeedBack.unicId;
        }

        /// <summary>
        /// Show a short lived feedback
        /// </summary>
        /// <param name="pFeedBack">the feedback to show</param>
        /// <param name="pTransform">the transform for place the feed back</param>
        /// <param name="pTime">the time of live of the feedback (the unit is define in the constructor)</param>
        /// <returns>the unic id of the feedback</returns>
        public virtual string ShowShortLivedFeedBack(AShortLivedVisualFeedback pFeedBack, Transform pTransform, float pTime)
        {
            string lId = ShowFeedBack(pFeedBack, pTransform);

            if (pFeedBack.coroutineUnShowInstance != null)
            {
                pFeedBack.timeToWait = pTime;
                StartCoroutine(pFeedBack.coroutineUnShowInstance);
            }
            return lId;
        }

        /// <summary>
        /// Unshow a  feedback
        /// </summary>
        /// <param name="pFeedBackRef">the unic id of the feedback</param>
        public virtual void UnshowFeedBack(string pFeedBackRef)
        {
            AVisualFeedBack lFeedBack = items.FirstOrDefault(pElm => pElm.unicId == pFeedBackRef);

            if(lFeedBack != null)
            {

                if (lFeedBack is AShortLivedVisualFeedback)
                {
                    StopShortLivedFeedBackCoroutine(lFeedBack as AShortLivedVisualFeedback);
                }

                lFeedBack.UnShow(mPoolManager);
                items.Remove(lFeedBack);
            }
        }

        /// <summary>
        /// stop the short lived feedback coroutine
        /// </summary>
        /// <param name="pFeedBack">the feedback to stop the coroutine</param>
        public virtual void StopShortLivedFeedBackCoroutine(AShortLivedVisualFeedback pFeedBack)
        {
            if(pFeedBack.coroutineUnShowInstance != null)
            {
                StopCoroutine(pFeedBack.coroutineUnShowInstance);
            }
        }
        #endregion Methods
    }
}
