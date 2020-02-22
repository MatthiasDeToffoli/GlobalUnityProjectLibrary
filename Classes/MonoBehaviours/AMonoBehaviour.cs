using System.Collections;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors
{
    /// <summary>
    /// Abstract class implement some functions of MonoBehaviour
    /// </summary>
    /// <remarks> see also <seealso cref="MonoBehaviour"/></remarks>
    public abstract class AMonoBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected virtual void Awake() { }

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
        protected virtual void ListenToEvents() { }

        /// <summary>
        /// Call the frame after the start
        /// </summary>
        protected virtual void AfterStart() { }

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
        /// Destroy of the behaviour
        /// </summary>
        protected virtual void OnDestroy()
        {
            UnlistenToEvents();
        }
    }
}
