using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditor
{
    /// <summary>
    /// Custom Editor for the switch menu button listener class
    /// </summary>
    [CustomEditor(typeof(SwitchMenuButtonListener),true)]
    public class SwitchMenuButtonListenerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //we get the property
            SerializedProperty lScreenToCloseIsParentProperty = serializedObject.FindProperty("screenToCloseIsParent");
            SerializedProperty lScreenToCloseProperty = serializedObject.FindProperty("screenToClose");

            //we draw the base inspector
            DrawDefaultInspector();

            EditorGUI.BeginChangeCheck();

            Object lScreenToClose = lScreenToCloseProperty.objectReferenceValue;

            //we show the screen to close in function of the boolean value
            if (!lScreenToCloseIsParentProperty.boolValue)
            {
                lScreenToCloseProperty.objectReferenceValue = EditorGUILayout.ObjectField("Screen to close",lScreenToClose,typeof(GameObject),true);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}

