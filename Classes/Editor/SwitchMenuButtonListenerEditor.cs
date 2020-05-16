using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditor
{
    /// <summary>
    /// Custom Editor for the switch menu button listener class
    /// </summary>
    /// <seealso cref="Editor"/> 
    /// <seealso cref="SwitchMenuButtonListener"/>
    [CustomEditor(typeof(SwitchMenuButtonListener),true)]
    public class SwitchMenuButtonListenerEditor : Editor
    {
        #region Constants
        /// <summary>
        /// string of the variale mScreenToOpen
        /// </summary>
        private const string SCREEN_TO_OPEN = "mScreenToOpen";

        /// <summary>
        /// the title show in inspector for the screen to open property
        /// </summary>
        private const string SCREEN_TO_OPEN_TITLE = "Screen to open";

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
        private const string SCREEN_TO_CLOSE = "screenToClose";

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

        /// <summary>
        /// The screen to open serialized property
        /// </summary>
        private SerializedProperty mScreenToOpenProperty;
        #endregion Fields

        #region Methods
        /// <summary>
        /// When the GUI is enable
        /// </summary>
        private void OnEnable()
        {
            //we get the property
            mScreenToCloseIsParentProperty = serializedObject.FindProperty(SCREEN_TO_CLOSE_IS_PARENT);
            mScreenToCloseProperty = serializedObject.FindProperty(SCREEN_TO_CLOSE);
            mScreenToOpenProperty = serializedObject.FindProperty(SCREEN_TO_OPEN);
        }
        /// <summary>
        /// When the inspector is updated
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(mScreenToOpenProperty, new GUIContent(SCREEN_TO_OPEN_TITLE));
            EditorGUILayout.PropertyField(mScreenToCloseIsParentProperty, new GUIContent(SCREEN_TO_CLOSE_IS_PARENT_TITLE));

            EditorGUI.BeginChangeCheck();

            //we show the screen to close in function of the boolean value
            if (!mScreenToCloseIsParentProperty.boolValue)
            {
                mScreenToCloseProperty.objectReferenceValue = EditorGUILayout.ObjectField(SCREEN_TO_CLOSE_TITLE, mScreenToCloseProperty.objectReferenceValue, typeof(AMenuScreen),true);
            }

            serializedObject.ApplyModifiedProperties();


        }
        #endregion Methods
    }
}

