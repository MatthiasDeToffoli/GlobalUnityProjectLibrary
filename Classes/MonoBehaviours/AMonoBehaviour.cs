using System.Collections;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors
{
    /// <summary>
    /// Abstract class implement some functions of MonoBehaviour
    /// </summary>
    public abstract class AMonoBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected abstract void Awake();

        /// <summary>
        /// Start of the behaviour
        /// </summary>
        protected virtual void Start()
        {
            ListenToEvents();
            StartCoroutine(AfterStartCoroutine());
        }

        /// <summary>
        /// Listen all events here
        /// </summary>
        protected abstract void ListenToEvents();

        /// <summary>
        /// Call the frame after the start
        /// </summary>
        protected abstract void AfterStart();

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
        protected abstract void UnlistenToEvents();

        /// <summary>
        /// Destroy of the behaviour
        /// </summary>
        protected virtual void OnDestroy()
        {
            UnlistenToEvents();
        }
    }
}
