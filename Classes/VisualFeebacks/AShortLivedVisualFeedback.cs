using Fr.Matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils.Enums;
using System.Collections;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks
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
        #endregion Fields

        #region Properties
        /// <summary>
        /// The instance of the coroutine
        /// </summary>
        public IEnumerator coroutineUnShowInstance;

        /// <summary>
        /// The time to wait for the couroutine
        /// </summary>
        public float timeToWait;
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="AShortLivedVisualFeedback"/>
        /// </summary>
        /// <param name="pTypeOfWait"></param>
        public AShortLivedVisualFeedback(CoroutineTypeOfWait pTypeOfWait) 
            : base()
        {
            mTypeOfWait = pTypeOfWait;
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Show the visual feed back
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        /// <param name="pNewTransform">the transforms contains position size and rotation of the feed back</param>
        /// <remarks>it search a game object in the pool</remarks>
        public override void Show(IPoolManager pPoolManager, Transform pNewTransform)
        {
            base.Show(pPoolManager, pNewTransform);
            coroutineUnShowInstance = UnShowCoroutine(pPoolManager);
        }

        /// <summary>
        /// Unshow the feedback
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        public override void UnShow(IPoolManager pPoolManager)
        {
            coroutineUnShowInstance = null;
            base.UnShow(pPoolManager);
        }

        /// <summary>
        /// The coroutine for call unshow
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        /// <returns></returns>
        private IEnumerator UnShowCoroutine(IPoolManager pPoolManager)
        {
            if(mTypeOfWait == CoroutineTypeOfWait.SECONDS)
            {
                yield return new WaitForSeconds(timeToWait);
            }
            else
            {
                for(int i = 0; i < timeToWait; i++)
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

            UnShow(pPoolManager);
        }
        #endregion Methods
    }
}
