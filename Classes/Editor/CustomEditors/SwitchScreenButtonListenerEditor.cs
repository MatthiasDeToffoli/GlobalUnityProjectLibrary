﻿using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Utils;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.CustomEditors
{
    /// <summary>
    /// Custom Editor for the switch screen button listener class
    /// </summary>
    /// <seealso cref="CloseScreenButtonListenerEditor"/> 
    /// <seealso cref="SwitchScreenButtonListener"/>
    [CustomEditor(typeof(SwitchScreenButtonListener),true)]
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
            EditorGUILayout.LabelField(OPEN_TITLE, GUIStyles.titleStyle);
            EditorGUILayout.LabelField(string.Empty);
            EditorGUILayout.PropertyField(mScreenToOpenProperty, new GUIContent(SCREEN_TO_OPEN_TITLE));
            EditorGUILayout.LabelField(Constants.PersonalEditor.SEPARATOR);
            EditorGUILayout.LabelField(string.Empty);

            //the to close part
            EditorGUILayout.LabelField(CLOSE_TITLE, GUIStyles.titleStyle);
            EditorGUILayout.LabelField(string.Empty);
            base.CreateProperties();
        }
        #endregion Methods
    }
}

