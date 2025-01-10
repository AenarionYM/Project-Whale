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

        private readonly IdleState idleState = new IdleState();
        private readonly ChasingState chasingState = new ChasingState();
        private readonly AttackState attackingState = new AttackState();
        private readonly WanderingState wanderingState = new WanderingState();

        public IMovement Movement { get; set; }
        public AnimationController AnimationController { get; set; }

        private void Start()
        {
            Movement = GetComponent<IMovement>();
            AnimationController = GetComponent<AnimationController>();

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
        }
    }
}