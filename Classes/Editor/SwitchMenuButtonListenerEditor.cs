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
        /// <summary>
        /// When the inspector is updated
        /// </summary>
        public override void OnInspectorGUI()
        {
            //we get the property
            SerializedProperty lScreenToCloseIsParentProperty = serializedObject.FindProperty(SwitchMenuButtonListener.STRING_TO_CLOSE_IS_PARENT);
            SerializedProperty lScreenToCloseProperty = serializedObject.FindProperty(SwitchMenuButtonListener.STRING_TO_CLOSE);

            //we draw the base inspector
            DrawDefaultInspector();

            EditorGUI.BeginChangeCheck();

            Object lScreenToClose = lScreenToCloseProperty.objectReferenceValue;

            //we show the screen to close in function of the boolean value
            if (!lScreenToCloseIsParentProperty.boolValue)
            {
                lScreenToCloseProperty.objectReferenceValue = EditorGUILayout.ObjectField(SwitchMenuButtonListener.STRING_TO_CLOSE_TITLE, lScreenToClose,typeof(GameObject),true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

