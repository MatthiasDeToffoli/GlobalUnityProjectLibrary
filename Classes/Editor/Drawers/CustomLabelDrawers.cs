using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.Drawers
{
    /// <summary>
    /// Drawer for Costum label attribute
    /// </summary>
    /// <seealso cref="PropertyDrawer"/>
    /// <seealso cref="CustomLabelAttribute"/>
    [CustomPropertyDrawer(typeof(CustomLabelAttribute))]
    public class CustomLabelDrawers : PropertyDrawer
    {
        #region Constants
        /// <summary>
        /// Used for test if it's the element of a list or an array
        /// </summary>
        private string DATA = ".data[";

        /// <summary>
        /// Error show when we try to use the custom label on an array or a list
        /// </summary>
        private string ERROR_USE_ON_ARRAY = "Custom label not work on array or list, for change the elements label use CustomElementLabel Attribute";
        #endregion Constants

        #region Methods
        /// <summary>
        /// When the gui is refresh
        /// </summary>
        /// <param name="pPosition">the gui position</param>
        /// <param name="pProperty">the property link to the gui</param>
        /// <param name="pLabel">the label of the gui</param>
        public override void OnGUI(Rect pPosition, SerializedProperty pProperty, GUIContent pLabel)
        {
            string? lNewLabel = (attribute as CustomLabelAttribute).label;

            if (pProperty.propertyPath.Contains(DATA))
            {
                Debug.LogError(ERROR_USE_ON_ARRAY);
            }
            else
            {
                if (lNewLabel != null)
                    pLabel.text = lNewLabel;

                EditorGUI.PropertyField(pPosition, pProperty, pLabel);
            }
        }
        #endregion Methods
    }
}
