using System;
using System.Collections.Generic;
using Controllers;
using Entities.Interfaces;
using Entities.States;
using Entities.States.Enums;
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

        // Dictionary of all possible states
        public Dictionary<StateType, IEntityState> States { get; set; }

        // Subscriptable event for other scripts
        public event Action<IEntityState> OnStateChange;

        private void Awake()
        {
            // Create instances of all used states
            States = new Dictionary<StateType, IEntityState>
            {
                { StateType.Idle, new IdleState() },
                { StateType.Attacking, new AttackState() },
                { StateType.Chasing, new ChasingState() },
                { StateType.Wandering, new WanderingState(transform.position) }, // Add other states here
                { StateType.Dying, new DyingState() }, // Add other states here
            };

            // Get other modules
            Movement = GetComponent<IMovement>();
            AnimationController = GetComponent<AnimationController>();

            // Set initial state
            TransitionToState(States[StateType.Wandering]);
        }

        private void Update()
        {
            CurrentState.UpdateState(this);
        }

        public void TransitionToState(IEntityState newState)
        {
            CurrentState?.ExitState(this);
            CurrentState = newState;
            CurrentState.EnterState(this);
            OnStateChange?.Invoke(CurrentState);
        }
    }
}