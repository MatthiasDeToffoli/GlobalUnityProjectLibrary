using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors
{
    /// <summary>
    /// Static class for implement default GUI styles used in editor
    /// </summary>
    public static class GuiStyles
    {
        #region Fields
        /// <summary>
        /// the style for a title in gui
        /// </summary>
        private static GUIStyle mTitleStyle;
        #endregion Fields

        #region Properties
        /// <summary>
        /// the style for a title in gui
        /// </summary>
        public static GUIStyle titleStyle
        {
            get
            {
                if(mTitleStyle == null)
                {
                    mTitleStyle = new GUIStyle();
                    mTitleStyle.fontSize = 15;
                    mTitleStyle.fontStyle = FontStyle.Bold;
                }
                return mTitleStyle;
            }
        }
        #endregion Properties
    }
}
