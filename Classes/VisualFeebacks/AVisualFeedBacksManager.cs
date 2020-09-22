using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Collections.Generic;
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
        /// Contain all feedback show
        /// </summary>
        protected Dictionary<string,GameObject> mListFeedBackShowed;
        #endregion Fields

        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            mListFeedBackShowed = new Dictionary<string, GameObject>();
        }
        #endregion Unity
        /// <summary>
        /// Show a feed back
        /// </summary>
        /// <param name="pFeedBack">the feed back to show</param>
        /// <param name="pTransform">the transform for place the feed back</param>
        protected virtual void ShowFeedBack(AVisualFeedBack pFeedBack, Transform pTransform)
        {
            mListFeedBackShowed.Add(pFeedBack.unicId, pFeedBack.Show(pTransform));
        }

        /// <summary>
        /// Show a short lived feedback
        /// </summary>
        /// <param name="pFeedBack">the feedback to show</param>
        /// <param name="pTransform">the transform for place the feed back</param>
        /// <param name="pTime">the time of live of the feedback (the unit is define in the constructor)</param>
        protected virtual void ShowShortLivedFeedBack(AShortLivedVisualFeedback pFeedBack, Transform pTransform, float pTime)
        {
            ShowFeedBack(pFeedBack, pTransform);

            if(pFeedBack.coroutineUnShowInstance != null)
            {
                pFeedBack.timeToWait = pTime;
                StartCoroutine(pFeedBack.coroutineUnShowInstance);
            }
            
        }

        /// <summary>
        /// Unshow a  feedback
        /// </summary>
        /// <param name="pFeedBack">the feedback to unshow</param>
        protected virtual void UnshowFeedBack(AVisualFeedBack pFeedBack)
        {
            if (mListFeedBackShowed != null && mListFeedBackShowed.ContainsKey(pFeedBack.unicId))
            {
                pFeedBack.UnShow(mListFeedBackShowed[pFeedBack.unicId]);
                mListFeedBackShowed.Remove(pFeedBack.unicId);
            }
        }

        /// <summary>
        /// Unshow a short lived feedback
        /// </summary>
        /// <param name="pFeedBack">the feedback to unshow</param>
        protected virtual void UnshowShortLivedFeedBack(AShortLivedVisualFeedback pFeedBack)
        {
            if(pFeedBack.coroutineUnShowInstance != null)
            {
                StopCoroutine(pFeedBack.coroutineUnShowInstance);
            }

            UnshowFeedBack(pFeedBack);
        }
        #endregion Methods
    }
}
