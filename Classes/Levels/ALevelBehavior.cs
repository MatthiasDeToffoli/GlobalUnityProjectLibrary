using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;

namespace Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Levels
{
    /// <summary>
    /// Behavior for the levels
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/>
    public abstract class ALevelBehavior : AMonoBehaviour
    {
        /// <summary>
        /// Active and init the level
        /// </summary>
        public virtual void Activate()
        {
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// Deactive the level
        /// </summary>
        public virtual void Deactivate()
        {
            this.gameObject.SetActive(false);
        }
    }
}
