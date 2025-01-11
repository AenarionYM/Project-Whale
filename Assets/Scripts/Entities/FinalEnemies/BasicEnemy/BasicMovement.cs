using System;
using System.Collections;
using Enemies.Abstracts;
using Entities.Abstracts;
using Entities.Interfaces;
using UnityEngine;

namespace Entities.FinalEnemies.BasicEnemy
{
    public class BasicMovement : ADefaultMovement
    {
        [SerializeField] private float sprintAnimationMultiplier;
        // Other modules
        private AnimationController animationController;
        private BasicEnemyStateManager stateManager;
        public Vector2 CurrentPosition => transform.position;
        
        // Entity state updated by `OnStateChange` event
        private IEntityState currentState;

        private void Awake()
        {
            // Get other modules
            animationController = GetComponent<AnimationController>();
            stateManager = GetComponent<BasicEnemyStateManager>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            stateManager.OnStateChange += HandleStateChange;
            Debug.Log(stateManager);
        }

        private void OnDisable()
        {
            stateManager.OnStateChange -= HandleStateChange;
        }


        private void HandleStateChange(IEntityState newState)
        {
            currentState = newState;
        }
        
        private void Walk(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * Time.deltaTime);
            Rigidbody.MovePosition(Rigidbody.position + movement);
            animationController.TriggerAnimation("Walk");
        }

        private void Sprint(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * SprintMultiplier * Time.deltaTime);
            Rigidbody.MovePosition(Rigidbody.position + movement);
            animationController.TriggerAnimation("Walk", 1.5f);
        }

        public override void MoveInDirection(Vector2 direction)
        {
            Vector2 movement = direction * (MovementSpeed * Time.deltaTime);
        }

        public override void MoveTo(Vector2 targetPosition, Action onComplete = null)
        {
            StartCoroutine(MoveToCoroutine(targetPosition, onComplete));
        }

        private IEnumerator MoveToCoroutine(Vector2 targetPosition, Action onComplete)
        {
            while (Vector2.Distance(Rigidbody.position, targetPosition) > 0.1f)
            {
                Walk(targetPosition);
                yield return null;
            }

            onComplete?.Invoke();
        }
    }
}