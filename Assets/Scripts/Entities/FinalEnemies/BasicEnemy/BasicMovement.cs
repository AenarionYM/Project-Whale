using Enemies.Abstracts;
using Entities.Abstracts;
using UnityEngine;

namespace Entities.FinalEnemies.BasicEnemy
{
    public class BasicMovement : ADefaultMovement
    {
        [SerializeField] private float sprintAnimationMultiplier;
        private AnimationController animationController;

        private void Start()
        {
            animationController = GetComponent<AnimationController>();
        }
        
        public override void Walk(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * Time.deltaTime);
            Rigidbody.MovePosition(Rigidbody.position + movement);
            animationController.TriggerAnimation("Walk");
        }


        public override void Sprint(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * SprintMultiplier * Time.deltaTime);
            Rigidbody.MovePosition(Rigidbody.position + movement);
            animationController.TriggerAnimation("Walk", 1.5f);
        }
    }
}