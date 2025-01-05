namespace Enemies.Interfaces
{
    public interface IAnimationHashes
    {
        /*
         * This is a container (JAMES) for static references to precalculated hashes for each animation of the entity
         * Like this:
         * public static readonly int TakeDmg = Animator.StringToHash("TakeDmg");
         * Used simply as:
         * animator.SetTrigger(AnimationHashes.TakeDmg)
         */
    }
}