using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.Drawers
{
    /// <summary>
    /// Property drawer for the attribute RangeWithStep
    /// </summary>
    /// <seealso cref="PropertyDrawer"/>
    /// <seealso cref="RangeWithStepAttribute"/>
    [CustomPropertyDrawer(typeof(RangeWithStepAttribute))]
    internal class RangeWithStepDrawer : PropertyDrawer
    {
        #region Fields
        /// <summary>
        /// The int value
        /// </summary>
        private int mIntValue;

        /// <summary>
        /// The float value
        /// </summary>
        private float mFloatValue;
        #endregion Fields

        #region Methods
        /// <summary>
        /// When the gui is refresh
        /// </summary>
        /// <param name="pPosition">the gui position</param>
        /// <param name="pProperty">the property link to the gui</param>
        /// <param name="pLabel">the label of the gui</param>
        public override void OnGUI(Rect pPosition, SerializedProperty pProperty, GUIContent pLabel)
        {
            RangeWithStepAttribute lAttribute = attribute as RangeWithStepAttribute;

            if (pProperty.propertyType == SerializedPropertyType.Integer)
            {
                //Use integer slider and format the value for add the step on it
                mIntValue = lAttribute.FormatWithStep(
                    EditorGUI.IntSlider(pPosition, pLabel, pProperty.intValue, (int)lAttribute.min, (int)lAttribute.max));
                //Set the value in the property
                pProperty.intValue = mIntValue;
            }
            else if(pProperty.propertyType == SerializedPropertyType.Float)
            {
                //Use slider and format the value for add the step on it
                mFloatValue = lAttribute.FormatWithStep(
                    EditorGUI.Slider(pPosition, pLabel, pProperty.floatValue, lAttribute.min, lAttribute.max));

                //Set the value in the property
                pProperty.floatValue = mFloatValue;
            }
        }
        #endregion Methods
    }
}
