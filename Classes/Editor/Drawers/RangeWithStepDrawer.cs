using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using System;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditors.Drawers
{
    /// <summary>
    /// Property drawer for the attribute RangeWithStep
    /// </summary>
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
        /// <param name="position">the gui position</param>
        /// <param name="property">the property link to the gui</param>
        /// <param name="label">the label of the gui</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            RangeWithStepAttribute lAttribute = attribute as RangeWithStepAttribute;

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                //Use integer slider and format the value for add the step on it
                mIntValue = lAttribute.FormatWithStep(
                    EditorGUI.IntSlider(position, label, mIntValue, (int)lAttribute.min, (int)lAttribute.max));
                //Set the value in the property
                property.intValue = mIntValue;
            }
            else if(property.propertyType == SerializedPropertyType.Float)
            {
                //Use slider and format the value for add the step on it
                mFloatValue = lAttribute.FormatWithStep(
                    EditorGUI.Slider(position, label, mFloatValue, lAttribute.min, lAttribute.max));

                //Set the value in the property
                property.floatValue = mFloatValue * lAttribute.step;
            }
        }
        #endregion Methods
    }
}
