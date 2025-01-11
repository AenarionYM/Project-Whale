using System;
using Enemies.Abstracts;
using Entities.Interfaces;
using Entities.States;
using UnityEngine;

namespace Entities.FinalEnemies.BasicEnemy
{
    public class BasicEnemyStateManager : MonoBehaviour, IEntityStateManager
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public IEntityState CurrentState { get; private set; }

        // Define other modules
        public IMovement Movement { get; set; }
        public AnimationController AnimationController { get; set; }

        // Define active states
        private IdleState idleState;
        private ChasingState chasingState;
        private AttackState attackingState;
        private WanderingState wanderingState;
        
        // Subscriptable event for other scripts
        public event Action<IEntityState> OnStateChanged;

        private void Start()
        {
            // Create instances of all used states
            idleState = new IdleState();
            chasingState = new ChasingState();
            attackingState = new AttackState();
            wanderingState = new WanderingState(transform.position);
            
            // Get other modules
            Movement = GetComponent<IMovement>();
            AnimationController = GetComponent<AnimationController>();

            // Set initial state
            TransitionToState(wanderingState);
        }

        private void Update()
        {
            CurrentState.UpdateState(this);
        }

        private void TransitionToState(IEntityState newState)
        {
            CurrentState?.ExitState(this);
            CurrentState = newState;
            CurrentState.EnterState(this);
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}