using Enemies.Abstracts;
using Entities.Interfaces;
using Entities.States;
using UnityEngine;

namespace Entities.Abstracts
{
    public class EnemyStateManager : MonoBehaviour, IEntityStateManager
    {
        public IEntityState CurrentState { get; private set; }

        public IdleState IdleState = new IdleState();
        public ChasingState ChasingState = new ChasingState();
        public AttackState AttackingState = new AttackState();
        // Add other states here...

        public IMovement Movement { get; private set; }
        public AnimationController AnimationController { get; private set; }

        private void Start()
        {
            Movement = GetComponent<IMovement>();
            AnimationController = GetComponent<AnimationController>();

            TransitionToState(IdleState);  // Start with IdleState
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
        }

        // Example methods for determining conditions
        public bool CanSeePlayer() { /* Implement logic */ return false; }
        public bool IsInAttackRange() { /* Implement logic */ return false; }
        public Vector2 GetDirectionToTarget() { /* Implement logic */ return Vector2.zero; }
    }
}