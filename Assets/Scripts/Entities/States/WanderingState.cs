using Entities.Interfaces;
using Entities.States.Enums;
using UnityEngine;

namespace Entities.States
{
    public class WanderingState : IEntityState
    {
        private Vector2 initialPosition;
        private Vector2 targetPosition;
        
        public MovementType MovementType => MovementType.Walk;
        public Interactivity Interactivity => Interactivity.Active;

        public WanderingState(Vector2 initialPosition)
        {
            this.initialPosition = initialPosition;
        }


        public void EnterState(IEntityStateManager entity)
        {
            SetNewTargetPosition();
            entity.Movement.MoveTo(targetPosition);
        }

        public void UpdateState(IEntityStateManager entity)
        {
            // Currently no per frame logic needed
        }

        public void ExitState(IEntityStateManager entity)
        {
            // Currently no cleanup logic needed
        }

        private void SetNewTargetPosition()
        {
            Vector2 randomDirection = Random.insideUnitCircle * 10f;
            targetPosition = initialPosition + randomDirection;
        }

        public void SetNewInitialPosition(Vector2 newInitialPosition)
        {
            initialPosition = newInitialPosition;
        }
    }
}