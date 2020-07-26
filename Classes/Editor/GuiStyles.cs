using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors
{
    /// <summary>
    /// Static class for implement default GUI styles used in editor
    /// </summary>
    public static class GUIStyles
    {
        #region Fields
        /// <summary>
        /// The style for a title in gui
        /// </summary>
        private static GUIStyle mTitleStyle;

        /// <summary>
        /// The style for an error in gui
        /// </summary>
        private static GUIStyle mErrorStyle;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The style for a title in gui
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

        /// <summary>
        /// The style for an error in gui
        /// </summary>
        public static GUIStyle errorStyle
        {
            get
            {
                if(mErrorStyle == null)
                {
                    mErrorStyle = new GUIStyle();
                    mErrorStyle.normal.textColor = Color.red;
                    mErrorStyle.fontSize = 12;
                    mErrorStyle.fontStyle = FontStyle.BoldAndItalic;
                }
                return mErrorStyle;
            }
        }
        #endregion Properties
    }
}
