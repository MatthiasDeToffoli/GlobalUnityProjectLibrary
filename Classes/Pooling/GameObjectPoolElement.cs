using Fr.Matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling.PoolElements;
using System;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Pooling
{
    /// <summary>
    /// Pool element for Game objects
    /// </summary>
    [Serializable]
    public class GameObjectPoolElement : IPoolElementWithType<GameObject>
    {
        #region Constants
        /// <summary>
        /// Error showed when the user try to reset an object which is not 
        /// </summary>
        private const string ERROR_TRY_TO_RESET_NOT_EQUAL = "The object you try to reset is not equivalent to the pool element";
        #endregion Constants

        #region Fields
        /// <summary>
        /// the id of the element
        /// </summary>
        [SerializeField]
        private string mId;

        /// <summary>
        /// The number of elements to create
        /// </summary>
        [SerializeField]
        private uint mNbToCreate;

        /// <summary>
        /// The value of the element
        /// </summary>
        [SerializeField]
        private GameObject mValue;
        #endregion Fields

        #region Properties
        /// <summary>
        /// the id of the element
        /// </summary>
        public string id
        {
            get
            {
                return mId;
            }
        }

        /// <summary>
        /// The number of elements to create
        /// </summary>
        public uint nbToCreate
        {
            get
            {
                return mNbToCreate;
            }
            set
            {
                mNbToCreate = value;
            }
        }

        /// <summary>
        /// The value of the element
        /// </summary>
        public object value
        {
            get
            {
                return typedValue;
            }
        }

        /// <summary>
        /// The value of the pool element
        /// </summary>
        public GameObject typedValue
        {
            get
            {
                return CreateInstanceOfObject();
            }
        }

        #endregion Properties

        #region Methods
        /// <summary>
        /// Create an instance of the object in the scenario
        /// </summary>
        private GameObject CreateInstanceOfObject()
        {
            GameObject lObject = GameObject.Instantiate(mValue);
            //If the first prefab was active true
            lObject.SetActive(false);
            return lObject;

        }

        /// <summary>
        /// If an object is equivalent to the value of the element
        /// </summary>
        /// <param name="pObject">the object to test</param>
        /// <returns></returns>
        public bool IsEquivalent(object pObject)
        {
            if(pObject is GameObject)
            {
                //Check just the type and the name for let us modify the object as we want
                GameObject lObject = pObject as GameObject;
                return lObject.name.Contains(mValue.name) || mValue.name.Contains(lObject.name);
            }

            return false;
        }

        /// <summary>
        /// reset the properties of the object with the elements value
        /// </summary>
        /// <param name="pObject">the object to reset</param>
        /// <returns>the object reset</returns>
        public object Reset(object pObject)
        {
            if(!IsEquivalent(pObject))
            {
                Debug.LogError(ERROR_TRY_TO_RESET_NOT_EQUAL);
            }
            else
            {
                GameObject lObject = pObject as GameObject;

                lObject.name = mValue.name;
                lObject.SetActive(false);
                lObject.transform.position = mValue.transform.position;
                lObject.transform.rotation = mValue.transform.rotation;
                lObject.transform.localScale = mValue.transform.localScale;
                return lObject;
            }

            return pObject;
        }
        #endregion Methods
    }
}
