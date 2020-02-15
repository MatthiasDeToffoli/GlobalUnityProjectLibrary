using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces;
using System;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors
{

    /// <summary>
    /// Singleton implementing mono behaviour methods
    /// </summary>
    public abstract class AMonoBehaviourSingleton<T> : AMonoBehaviour where T : AMonoBehaviour
    {
        #region Fields
        /// <summary>
        /// unique instance of the class
        /// </summary>
        protected static T mInstance;
        #endregion //Fields

        #region Properties
        /// <summary>
        /// unique instance of the class
        /// </summary>
        public static T instance
        {
            get
            {
                return mInstance;
            }
        }

        [Header("Singleton")]
        [SerializeField]
        private bool replaceIfAlwaysExist = true;
        [SerializeField]
        private bool dontDestroyGameObjectOnLoad = true;
        #endregion //Properties

        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        override protected void Awake()
        {
            string className = "" + GetType();
            className = className.Substring(className.LastIndexOf('.')).Replace(".", "");

            string throwMessage = "Attempting to create another instance of " + className + " while it is a singleton.";

            if (mInstance != null)
            {
                if (replaceIfAlwaysExist)
                {
                    Destroy(instance.gameObject);
                    throwMessage += " We have replaced the old version by this one";
                }
                else
                {
                    Destroy(gameObject);
                    throwMessage += " We have destroyed this version";
                }
                throw new Exception(throwMessage);
            }

            if (replaceIfAlwaysExist || (!replaceIfAlwaysExist && mInstance == null))
            {
                if(this is T)
                {
                    mInstance = this as T;
                } else
                {
                    throw new Exception(string.Format("the type {0} is not a child of  {1}", typeof(T).Name, GetType().Name));
                }
            }
                mInstance = this as T;

            if (dontDestroyGameObjectOnLoad) DontDestroyOnLoad(gameObject);
        }
        #endregion //Methods
    }
}