using System.Collections;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors
{
    /// <summary>
    /// Abstract class implement some functions of MonoBehaviour
    /// </summary>
    /// <seealso cref="MonoBehaviour"/>
    public abstract class AMonoBehaviour : MonoBehaviour
    {
        #region Fields
        /// <summary>
        /// If we did the start
        /// </summary>
        private bool mDidStart = false;

        /// <summary>
        /// If we did the after start
        /// </summary>
        private bool mDidAfterStart = false;

        /// <summary>
        /// Used for keep the after start coroutine
        /// </summary>
        private IEnumerator AfterStartCoroutineHandler;
        #endregion Fields

        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected virtual void Awake() 
        {
            AfterStartCoroutineHandler = AfterStartCoroutine();
        }

        /// <summary>
        /// Start of the behaviour
        /// </summary>
        protected virtual void Start()
        {
            ListenToEvents();
            StartCoroutine(AfterStartCoroutineHandler);
            mDidStart = true;
        }

        /// <summary>
        /// Destroy of the behaviour
        /// </summary>
        protected virtual void OnDestroy()
        {
            UnlistenToEvents();
        }
        #endregion Unity
        
        /// <summary>
        /// Listen all events here
        /// </summary>
        protected virtual void ListenToEvents() { }

        /// <summary>
        /// Call the frame after the start
        /// </summary>
        protected virtual void AfterStart() 
        {
            mDidAfterStart = true;
        }

        /// <summary>
        /// Wait one frame before fire the after start
        /// </summary>
        /// <returns></returns>
        private IEnumerator AfterStartCoroutine()
        {
            yield return new WaitForEndOfFrame();
            AfterStart();
        }

        /// <summary>
        /// unlisten all events here
        /// </summary>
        protected virtual void UnlistenToEvents() { }

        /// <summary>
        /// when the script is desable
        /// </summary>
        protected virtual void OnDisable()
        {
            if(mDidStart && !mDidAfterStart)
            {
                StopCoroutine(AfterStartCoroutineHandler);
                AfterStart();
            }
        }
        #endregion Methods
    }
}
