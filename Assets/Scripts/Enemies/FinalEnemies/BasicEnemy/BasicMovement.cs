using Enemies.Abstracts;
using UnityEngine;

namespace Enemies.FinalEnemies.BasicEnemy
{
    public class BasicMovement : ADefaultMovement
    {
        [SerializeField] private float sprintAnimationMultiplier;

        public override void Move(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * Time.deltaTime);
            Rigidbody.MovePosition(Rigidbody.position + movement);
            Animator.SetBool(BasicAnimationHashes.Walk, true);
        }


        public override void Sprint(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * SprintMultiplier * Time.deltaTime);
            Rigidbody.MovePosition(Rigidbody.position + movement);
            Animator.SetBool(BasicAnimationHashes.Walk, true);
        }
    }
}