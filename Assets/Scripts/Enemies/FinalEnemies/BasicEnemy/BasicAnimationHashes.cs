using Enemies.Interfaces;
using UnityEngine;

namespace Enemies.FinalEnemies.BasicEnemy
{
    public static class BasicAnimationHashes
    {
        public static readonly int TakeDmg = Animator.StringToHash("TakeDmg");
        public static readonly int Die = Animator.StringToHash("Die");
        public static readonly int Walk = Animator.StringToHash("isMoving");
    }
}