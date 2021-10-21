using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.CloseScreenButtonListeners.SwitchScreenButtonListeners;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Utils;
using UnityEditor;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.CustomEditors
{
    /// <summary>
    /// Custom Editor for the switch screen button listener class
    /// </summary>
    /// <seealso cref="CloseScreenButtonListenerEditor"/> 
    /// <seealso cref="ASwitchScreenButtonListener"/>
    [CustomEditor(typeof(ASwitchScreenButtonListener),true)]
    internal class SwitchScreenButtonListenerEditor : CloseScreenButtonListenerEditor
    {
        #region Constants
        /// <summary>
        /// Title for screen to open property
        /// </summary>
        private const string OPEN_TITLE = "To open :";

        /// <summary>
        /// Title for screen to close properties
        /// </summary>
        private const string CLOSE_TITLE = "To close :";
        /// <summary>
        /// string of the variale mScreenToOpen
        /// </summary>
        private const string SCREEN_TO_OPEN = "mScreenToOpen";

        /// <summary>
        /// the title show in inspector for the screen to open property
        /// </summary>
        private const string SCREEN_TO_OPEN_TITLE = "Screen to open";
        #endregion Constants

        #region Fields
        /// <summary>
        /// The screen to open serialized property
        /// </summary>
        private SerializedProperty mScreenToOpenProperty;
        #endregion Fields

        #region Methods
        /// <summary>
        /// When the GUI is enable
        /// </summary>
        protected override void OnEnable()
        {
            //we get the property
            base.OnEnable();
            mScreenToOpenProperty = serializedObject.FindProperty(SCREEN_TO_OPEN);
        }

        /// <summary>
        /// Create all the properties
        /// </summary>
        protected override void CreateProperties()
        {
            //the to open part
            if (mScreenToOpenProperty != null)
            {
                EditorGUILayout.LabelField(OPEN_TITLE, GUIStyles.titleStyle);
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(mScreenToOpenProperty, new GUIContent(SCREEN_TO_OPEN_TITLE));
                EditorGUILayout.LabelField(Constants.PersonalEditor.SEPARATOR);
                EditorGUILayout.Space();
            }

            //the to close part
            EditorGUILayout.LabelField(CLOSE_TITLE, GUIStyles.titleStyle);
            EditorGUILayout.Space();
            base.CreateProperties();
        }
        #endregion Methods
    }
}

