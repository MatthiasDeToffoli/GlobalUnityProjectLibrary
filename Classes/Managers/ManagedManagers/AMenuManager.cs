using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu;
using System.Linq;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// the parent of all menu manager
    /// </summary>
    /// <seealso cref="AManagerWithList{T}"/> 
    /// <seealso cref="AMenuScreen"/>
    public abstract class AMenuManager:AManagerWithList<AMenuScreen>
    {
        #region Constants
        /// <summary>
        /// Error when we try to close a screen which not exist
        /// </summary>
        private const string ERROR_TO_CLOSE_NOT_EXIST = "Try to close a screen which not exist";

        /// <summary>
        /// Error when we try to open a screen which not exist
        /// </summary>
        private const string ERROR_TO_OPEN_NOT_EXIST = "Try to open a screen which not exist";
        #endregion Constants

        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake()
        {
            //Active all pages for call their Awake and start
            foreach(AMenuScreen lPage in items)
            {
                lPage?.gameObject.SetActive(true);
            }
        }
        #endregion Unity

        /// <summary>
        /// init the manager
        /// </summary>
        /// <remarks>this function is called by the main manager</remarks>
        public override void Init()
        {
            foreach(AMenuScreen lScreen in items)
            {
                lScreen?.gameObject.SetActive(false);
            }
        }


        /// <summary>
        /// switch two screen
        /// </summary>
        /// <typeparam name="TToClose">type of the screen to close</typeparam>
        /// <typeparam name="TToOpen">type of the screen to open</typeparam>
        public void SwitchScreen<TToClose,TToOpen>() where TToClose:AMenuScreen where TToOpen:AMenuScreen
        {
            SwitchScreen(items.FirstOrDefault(pElm => pElm is TToClose), items.FirstOrDefault(pElm => pElm is TToOpen));
        }

        /// <summary>
        /// switch two screen
        /// </summary>
        /// <param name="pIndexToClose">index of the screen to close</param>
        /// <param name="pIndexToOpen">index of the screen to open</param>
        public void SwitchScreen(int pIndexToClose, int pIndexToOpen)
        {
            if(items.Count < pIndexToClose)
            {
                Debug.LogError(ERROR_TO_CLOSE_NOT_EXIST);
            } 
            else if(items.Count < pIndexToOpen)
            {
                Debug.LogError(ERROR_TO_OPEN_NOT_EXIST);
            }
            else
            {
                items[pIndexToClose]?.Close();
                items[pIndexToOpen]?.Open();
            }
        }

        /// <summary>
        /// switch two screen
        /// </summary>
        /// <param name="pScreenToClose"></param>
        /// <param name="pScreenToOpen"></param>
        public void SwitchScreen(AMenuScreen pScreenToClose, AMenuScreen pScreenToOpen)
        {
            if (pScreenToClose == null)
            {
                Debug.LogError(ERROR_TO_CLOSE_NOT_EXIST);
            }
            else if (pScreenToOpen == null)
            {
                Debug.LogError(ERROR_TO_OPEN_NOT_EXIST);
            }
            else
            {
                pScreenToClose.Close();
                pScreenToOpen.Open();
            }
        }

        /// <summary>
        /// open a screen
        /// </summary>
        /// <typeparam name="TToOpen">type of the screen to open</typeparam>
        public void OpenScreen<TToOpen>() where TToOpen : AMenuScreen
        {
            OpenScreen(items.FirstOrDefault(pElm => pElm is TToOpen));
        }

        /// <summary>
        /// open a screen
        /// </summary>
        /// <param name="pIndexToOpen">index of the screen to open</param>
        public void OpenScreen(int pIndexToOpen)
        {
            if (items.Count < pIndexToOpen)
            {
                Debug.LogError(ERROR_TO_OPEN_NOT_EXIST);
            }
            else
            {
                items[pIndexToOpen]?.Open();
            }
        }

        /// <summary>
        /// open a screen
        /// </summary>
        /// <param name="pScreenToOpen"></param>
        public void OpenScreen(AMenuScreen pScreenToOpen)
        {
            if (pScreenToOpen == null)
            {
                Debug.LogError(ERROR_TO_OPEN_NOT_EXIST);
            }
            else
            {
                pScreenToOpen.Open();
            }
        }

        /// <summary>
        /// close a screen
        /// </summary>
        /// <typeparam name="TToClose">type of the screen to close</typeparam>
        public void CloseScreen<TToClose>() where TToClose : AMenuScreen
        {
            CloseScreen(items.FirstOrDefault(pElm => pElm is TToClose));
        }

        /// <summary>
        /// close a screen
        /// </summary>
        /// <param name="pIndexToClose">index of the screen to close</param>
        public void CloseScreen(int pIndexToClose)
        {
            if (items.Count < pIndexToClose)
            {
                Debug.LogError(ERROR_TO_CLOSE_NOT_EXIST);
            }
            else
            {
                items[pIndexToClose]?.Close();
            }
        }

        /// <summary>
        /// close a screen
        /// </summary>
        /// <param name="pScreenToClose"></param>
        public void CloseScreen(AMenuScreen pScreenToClose)
        {
            if (pScreenToClose == null)
            {
                Debug.LogError(ERROR_TO_CLOSE_NOT_EXIST);
            }
            else
            {
                pScreenToClose.Close();
            }
        }
        #endregion Methods
    }
}
