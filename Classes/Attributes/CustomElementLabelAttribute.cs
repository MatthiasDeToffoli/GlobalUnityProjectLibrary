using System;
using System.Collections.Generic;
using System.Text;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes
{
    /// <summary>
    /// Attribute for define a costum label for a List or array element
    /// </summary>
    /// <seealso cref="CustomLabelAttribute"/>
    public class CustomElementLabelAttribute : CustomLabelAttribute
    {
        #region Properties
        /// <summary>
        /// the new label to set
        /// </summary>
        public string?[] elmentsFixedLabels
        {
            get;
            private set;
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="CustomElementLabelAttribute"/>
        /// </summary>
        /// <param name="pLabel">the new label to set</param>
        /// <remarks>if <paramref name="pLabel"/> is null the inspector will show the default label</remarks>
        public CustomElementLabelAttribute(string? pLabel) : base(pLabel)
        {
            elmentsFixedLabels = new string?[0];
        }

        /// <summary>
        /// Initialize an instance of the class <see cref="CustomElementLabelAttribute"/>
        /// </summary>
        /// <param name="pFixedLabels">fixed labels for the elements</param>
        /// <remarks>for all elements which has index superior or equal to <paramref name="pFixedLabels"/> size, the inspector will show the default label </remarks>
        public CustomElementLabelAttribute(string?[] pFixedLabels) : base(null)
        {
            elmentsFixedLabels = pFixedLabels;
        }

        /// <summary>
        /// Initialize an instance of the class <see cref="CustomElementLabelAttribute"/>
        /// </summary>
        /// <param name="pLabel">the new label to set</param>
        /// <param name="pFixedLabels">fixed labels for the elements</param>
        /// <remarks>for all elements which has index superior or equal to <paramref name="pFixedLabels"/> size, the inspector will <paramref name="pLabel"/> + the index of the element </remarks>
        /// <remarks>if <paramref name="pLabel"/> is null the inspector will show the default label</remarks>
        public CustomElementLabelAttribute(string? pLabel, string?[] pFixedLabels) : base(pLabel)
        {
            elmentsFixedLabels = pFixedLabels;
        }
        #endregion Constructors
    }
}
