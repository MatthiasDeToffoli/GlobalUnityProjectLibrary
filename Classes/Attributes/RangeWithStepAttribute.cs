using System;
using UnityEngine;

namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes
{
    /// <summary>
    /// Attribute for define a range with a step
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class RangeWithStepAttribute : PropertyAttribute
    {
        #region Properties
        /// <summary>
        /// The min value
        /// </summary>
        public float min
        {
            get;
            private set;
        }

        /// <summary>
        /// The max value
        /// </summary>
        public float max
        {
            get;
            private set;
        }

        /// <summary>
        /// the step value
        /// </summary>
        public float step
        {
            get;
            private set;
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="RangeWithStepAttribute"/>
        /// </summary>
        /// <param name="pMin">the min value</param>
        /// <param name="pMax">the max value</param>
        /// <param name="pStep">the step</param>
        public RangeWithStepAttribute(float pMin, float pMax, float pStep)
        {
            step = pStep;
            min = pMin;
            max = pMax;
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Format a number with the step
        /// </summary>
        /// <param name="pValue">the value to format</param>
        /// <returns>the value formated</returns>
        public float FormatWithStep(float pValue)
        {
            if(pValue % step != 0)
            {
                pValue = (float)Math.Round(pValue / step) * step;
            }

            //major and minor the value
            return Math.Min(Math.Max(pValue,min),max);
        }

        /// <summary>
        /// Format a number with the step
        /// </summary>
        /// <param name="pValue">the value to format</param>
        /// <returns>the value formated</returns>
        public int FormatWithStep(int pValue)
        {
            return (int)FormatWithStep((float)pValue);
        }
        #endregion Methods
    }
}
