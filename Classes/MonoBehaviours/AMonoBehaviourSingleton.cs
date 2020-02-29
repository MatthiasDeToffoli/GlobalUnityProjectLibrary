using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces;
using System;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors
{

    /// <summary>
    /// Singleton implementing mono behaviour methods
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/> 
    /// <seealso cref="ISingleton"/>
    public abstract class AMonoBehaviourSingleton<T> : AMonoBehaviour, ISingleton where T : AMonoBehaviour, ISingleton
    {
        #region Fields
        /// <summary>
        /// unique instance of the class
        /// </summary>
        private static T mInstance;
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

        /// <summary>
        /// If it's true the old value of the singleton will be replaced
        /// </summary>
        [Header("Singleton")]
        [SerializeField]
        private bool replaceIfAlreadyExist = true;
        /// <summary>
        /// if it's true the gameobject will not be destroy when we will change the scene
        /// </summary>
        [SerializeField]
        private bool dontDestroyGameObjectOnLoad = true;

        /// <summary>
        /// The unique id of the singleton
        /// </summary>
        [HideInInspector]
        public string uniqueId
        {
            get;
            private set;
        }
        #endregion //Properties

        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        override protected void Awake()
        {
            //find the class name for error message
            string className = "" + GetType();
            className = className.Substring(className.LastIndexOf('.')).Replace(".", "");

            string throwMessage = "Attempting to create another instance of " + className + " while it is a singleton.";

            if (mInstance != null)
            {
                //Chose if we keep the old or the new version
                if (replaceIfAlreadyExist)
                {
                    Destroy(instance.gameObject);
                    throwMessage = string.Format("{0} We have replaced the old version by this one",throwMessage);
                    
                    return;
                }
                else
                {
                    Destroy(gameObject);
                    throwMessage = string.Format("{0} We have destroyed this version", throwMessage);
                }
                throw new Exception(throwMessage);
            }

            //set the instance
            if (replaceIfAlreadyExist || (!replaceIfAlreadyExist && mInstance == null))
            {
                if(this is T)
                {
                    mInstance = this as T;
                } else
                {
                    throw new Exception(string.Format("the type {0} is not a child of  {1}", typeof(T).Name, GetType().Name));
                }
            }

            if (dontDestroyGameObjectOnLoad) DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Remove the current instance of the singleton and Replace it by another one
        /// </summary>
        /// <param name="pNewInstance">the new isntance to set</param>
        public void Replace(ISingleton pNewInstance)
        {
            if (pNewInstance is T)
            {
                SetInstance(pNewInstance as T);
                Remove();
            }
        }

        /// <summary>
        /// remove the current instance of the singleton
        /// </summary>
        public virtual void Remove()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// set the instance of the singleton if it not have another instance
        /// </summary>
        /// <param name="pInstance">the instance to set</param>
        private static void SetInstance(T pInstance)
        {
            if (pInstance != null)
            {
                mInstance = pInstance;
            }
        }
        #endregion //Methods
    }
}