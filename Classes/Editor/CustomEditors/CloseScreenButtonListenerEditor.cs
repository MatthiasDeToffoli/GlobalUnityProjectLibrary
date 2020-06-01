using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.CustomEditors
{
    /// <summary>
    /// Custom Editor for the close menu button listener class
    /// </summary>
    /// <seealso cref="Editor"/> 
    /// <seealso cref="CloseScreenButtonListener"/>
    [CustomEditor(typeof(CloseScreenButtonListener),true)]
    class CloseScreenButtonListenerEditor : Editor
    {
        #region Constants
        /// <summary>
        /// string of the variale mScreenToCloseIsParent
        /// </summary>
        private const string SCREEN_TO_CLOSE_IS_PARENT = "mScreenToCloseIsParent";

        /// <summary>
        /// the title show in inspector for the screen to close is parent property
        /// </summary>
        private const string SCREEN_TO_CLOSE_IS_PARENT_TITLE = "Screen to close is parent ?";
        /// <summary>
        /// string of the variale screenToClose
        /// </summary>
        private const string SCREEN_TO_CLOSE = "mScreenToClose";

        /// <summary>
        /// the title show in inspector for the screen to close property
        /// </summary>
        private const string SCREEN_TO_CLOSE_TITLE = "Screen to close";
        #endregion Constants

        #region Fields
        /// <summary>
        /// The screen to close is parent serialized property
        /// </summary>
        private SerializedProperty mScreenToCloseIsParentProperty;

        /// <summary>
        /// The screen to close serialized property
        /// </summary>
        private SerializedProperty mScreenToCloseProperty;
        #endregion Fields

        #region Methods
        /// <summary>
        /// When the GUI is enable
        /// </summary>
        protected virtual void OnEnable()
        {
            //we get the property
            mScreenToCloseIsParentProperty = serializedObject.FindProperty(SCREEN_TO_CLOSE_IS_PARENT);
            mScreenToCloseProperty = serializedObject.FindProperty(SCREEN_TO_CLOSE);
        }
        /// <summary>
        /// When the inspector is updated
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            CreateProperties();

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();


        }

        /// <summary>
        /// Create all the properties
        /// </summary>
        protected virtual void CreateProperties()
        {
            EditorGUILayout.PropertyField(mScreenToCloseIsParentProperty, new GUIContent(SCREEN_TO_CLOSE_IS_PARENT_TITLE));

            //we show the screen to close in function of the boolean value
            if (!mScreenToCloseIsParentProperty.boolValue)
            {
                mScreenToCloseProperty.objectReferenceValue = EditorGUILayout.ObjectField(SCREEN_TO_CLOSE_TITLE, mScreenToCloseProperty.objectReferenceValue, typeof(AMenuScreen), true);
            }
        }
        #endregion Methods
    }
}
