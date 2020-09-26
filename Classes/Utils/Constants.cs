namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Utils
{
    /// <summary>
    /// All project global constants
    /// </summary>
    public static class Constants
    {
        #region Objects
        /// <summary>
        /// All constants used in the custom editor
        /// </summary>
        public static class PersonalEditor
        {
            /// <summary>
            /// Line for separate elements in inspector 
            /// </summary>
            public const string SEPARATOR = "___________________";

            /// <summary>
            /// the array size word (used for the title of array side)
            /// </summary>
            public const string ARRAY_SIZE = "Size";

            /// <summary>
            /// The array element words (used the title of array elements)
            /// </summary>
            /// <remarks>used that with string.Format and put the index of the element at first parameter</remarks>
            public const string ARRAY_ELEMENT = "Element {0}";
        }
        #endregion Objects
    }
}
