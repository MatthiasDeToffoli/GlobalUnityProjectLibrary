using System;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes
{
    /// <summary>
    /// Attribute for define a costum label for a property
    /// </summary>
    /// <remarks>Don't work on list and array</remarks>
    /// <seealso cref="PropertyAttribute"/>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class CustomLabelAttribute : PropertyAttribute
    {
        #region Properties
        /// <summary>
        /// the new label to set
        /// </summary>
        public string? label
        {
            get;
            private set;
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="CustomLabelAttribute"/>
        /// </summary>
        /// <param name="pLabel">the new label to set</param>
        /// <remarks>if <paramref name="pLabel"/> is null the inspector will show the property name</remarks>
        public CustomLabelAttribute(string? pLabel)
        {
            label = pLabel;
        }
        #endregion Constructors
    }
}
