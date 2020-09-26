namespace fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Utils.Enums
{
    /// <summary>
    /// Enum used for say what type of wait we will use in a coroutine
    /// </summary>
    public enum CoroutineTypeOfWait
    {
        /// <summary>
        /// If we wait seconds
        /// </summary>
        SECONDS = 0,
        /// <summary>
        /// If we wait frames
        /// </summary>
        END_OF_FRAME = 1,
        /// <summary>
        /// If we wait fixed update
        /// </summary>
        FIXED_UPDATE = 2
    }
}
