using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using UnityEditor;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.Drawers
{
    /// <summary>
    /// Drawer for Costum element label attribute
    /// </summary>
    /// <seealso cref="PropertyDrawer"/>
    /// <seealso cref="CustomElementLabelAttribute"/>
    [CustomPropertyDrawer(typeof(CustomElementLabelAttribute))]
    public class CustomElementLabelDrawer : PropertyDrawer
    {
        #region Constants
        /// <summary>
        /// Used for test if it's the element of a list or an array
        /// </summary>
        private string DATA = ".data[";

        /// <summary>
        /// The old name of the element
        /// </summary>
        private string ELEMENT = "Element ";

        /// <summary>
        /// Error show when we try to use the custom label on an array or a list
        /// </summary>
        private string ERROR_NOT_USE_ON_ARRAY = "Custom label work only on array or list elements, for change a not list or array property label use CustomLabel Attribute";
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
            if (!pProperty.propertyPath.Contains(DATA))
            {
                Debug.LogError(ERROR_NOT_USE_ON_ARRAY);
            }
            else
            {
                CustomElementLabelAttribute lTypedAttribute = (attribute as CustomElementLabelAttribute);

                string lElmIndexStr = pLabel.text.Replace(ELEMENT, string.Empty);
                int lIndex;

                if(int.TryParse(lElmIndexStr,out lIndex) && lIndex < lTypedAttribute.elmentsFixedLabels.Length)
                {
                    pLabel.text = lTypedAttribute.elmentsFixedLabels[lIndex];
                }
                else if(lTypedAttribute.label != null)
                {
                    pLabel.text = string.Format("{0} {1}", lTypedAttribute.label, lElmIndexStr);
                }

                EditorGUI.PropertyField(pPosition, pProperty, pLabel);
            }
        }
        #endregion Methods
    }
}
