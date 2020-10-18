using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using System.Linq;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager
{
    /// <summary>
    /// manage all the menu
    /// </summary>
    /// <seealso cref="AManagerWithList{T}"/> 
    /// <seealso cref="AMenuScreen"/>
    public class MenuManager:AManagerWithList<AMenuScreen>
    {
        #region Constants
        /// <summary>
        /// Error when we try to close a screen which not exist
        /// </summary>
        private const string ERROR_TO_CLOSE_NOT_EXIST = "Try to close the screen {0} which not exist";

        /// <summary>
        /// Error when we try to open a screen which not exist
        /// </summary>
        private const string ERROR_TO_OPEN_NOT_EXIST = "Try to open the screen {0} which not exist";

        /// <summary>
        /// Error when we try to open a screen at an index which not exist
        /// </summary>
        private const string ERROR_INDEX = "No screen exist at the index {0}";
        #endregion Constants

        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        /// <remarks>Init all the properties and Fields here</remarks>
        protected override void Awake()
        {
            base.Awake();

            //Active all pages for call their Awake
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
        /// <param name="pScreenToOpenParams">the parametters of the screen to open</param>
        public void SwitchScreen<TToClose,TToOpen>(params object[] pScreenToOpenParams) where TToClose:AMenuScreen where TToOpen:AMenuScreen
        {
            SwitchScreen(
                items.FirstOrDefault(pElm => pElm is TToClose), 
                items.FirstOrDefault(pElm => pElm is TToOpen), 
                typeof(TToOpen).Name, 
                typeof(TToClose).Name, 
                pScreenToOpenParams
            );
        }

        /// <summary>
        /// switch two screen
        /// </summary>
        /// <param name="pIndexToClose">index of the screen to close</param>
        /// <param name="pIndexToOpen">index of the screen to open</param>
        /// <param name="pScreenToOpenParams">the parametters of the screen to open</param>
        public void SwitchScreen(int pIndexToClose, int pIndexToOpen, params object[] pScreenToOpenParams)
        {
            //Use it for has all the errors
            bool lCanOpen = true;

            if (items.Count < pIndexToClose)
            {
                Debug.LogError(string.Format(ERROR_INDEX, pIndexToClose));
                lCanOpen = false;
            } 
            
            if(items.Count < pIndexToOpen)
            {
                Debug.LogError(string.Format(ERROR_INDEX, pIndexToOpen));
                lCanOpen = false;
            }
            
            if(lCanOpen)
            {
                items[pIndexToClose]?.Close();
                items[pIndexToOpen]?.Open(pScreenToOpenParams);
            }
        }

        /// <summary>
        /// switch two screen
        /// </summary>
        /// <param name="pScreenToClose"></param>
        /// <param name="pScreenToOpen"></param>
        /// <param name="pToCloseTypeName">the name of the type of screen to close used for the error message</param>
        /// <param name="pToOpenTypeName">the name of the type of screen to open used for the error message</param>
        /// <param name="pScreenToOpenParams">the parametters of the screen to open</param>
        public void SwitchScreen(
            AMenuScreen pScreenToClose, 
            AMenuScreen pScreenToOpen, 
            string pToOpenTypeName, 
            string pToCloseTypeName, 
            params object[] pScreenToOpenParams
        )
        {
            //Use it for has all the errors
            bool lCanOpen = true;

            if (pScreenToClose == null)
            {
                Debug.LogError(string.Format(ERROR_TO_CLOSE_NOT_EXIST, pToCloseTypeName));
                lCanOpen = false;
            }
            
            if (pScreenToOpen == null)
            {
                Debug.LogError(string.Format(ERROR_TO_OPEN_NOT_EXIST,pToOpenTypeName));
                lCanOpen = false;
            }

            if(lCanOpen)
            {
                pScreenToClose.Close();
                pScreenToOpen.Open(pScreenToOpenParams);
            }
        }

        /// <summary>
        /// open a screen
        /// </summary>
        /// <typeparam name="TToOpen">type of the screen to open</typeparam>
        /// <param name="pParams">the parametters of the screen to open</param>
        public void OpenScreen<TToOpen>(params object[] pParams) where TToOpen : AMenuScreen
        {
            OpenScreen(items.FirstOrDefault(pElm => pElm is TToOpen),typeof(TToOpen).Name, pParams);
        }

        /// <summary>
        /// open a screen
        /// </summary>
        /// <param name="pIndexToOpen">index of the screen to open</param>
        /// <param name="pParams">the parametters of the screen to open</param>
        public void OpenScreen(int pIndexToOpen, params object[] pParams)
        {
            if (items.Count < pIndexToOpen)
            {
                Debug.LogError(string.Format(ERROR_INDEX,pIndexToOpen));
            }
            else
            {
                items[pIndexToOpen]?.Open(pParams);
            }
        }

        /// <summary>
        /// open a screen
        /// </summary>
        /// <param name="pScreenToOpen"></param>
        /// <param name="pTypeName">the name of the type for the error message</param>
        /// <param name="pParams">the parametters of the screen to open</param>
        public void OpenScreen(AMenuScreen pScreenToOpen, string pTypeName, params object[] pParams)
        {
            if (pScreenToOpen == null)
            {
                Debug.LogError(string.Format(ERROR_TO_OPEN_NOT_EXIST,pTypeName));
            }
            else
            {
                pScreenToOpen.Open(pParams);
            }
        }

        /// <summary>
        /// close a screen
        /// </summary>
        /// <typeparam name="TToClose">type of the screen to close</typeparam>
        public void CloseScreen<TToClose>() where TToClose : AMenuScreen
        {
            CloseScreen(items.FirstOrDefault(pElm => pElm is TToClose), typeof(TToClose).Name);
        }

        /// <summary>
        /// close a screen
        /// </summary>
        /// <param name="pIndexToClose">index of the screen to close</param>
        public void CloseScreen(int pIndexToClose)
        {
            if (items.Count < pIndexToClose)
            {
                Debug.LogError(string.Format(ERROR_INDEX, pIndexToClose));
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
        /// <param name="pTypeName">the name of the type for the error message</param>
        public void CloseScreen(AMenuScreen pScreenToClose, string pTypeName)
        {
            if (pScreenToClose == null)
            {
                Debug.LogError(string.Format(ERROR_TO_CLOSE_NOT_EXIST,pTypeName));
            }
            else
            {
                pScreenToClose.Close();
            }
        }
        #endregion Methods
    }
}
