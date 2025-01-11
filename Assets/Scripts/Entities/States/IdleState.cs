﻿using Entities.Interfaces;
using Entities.States.Enums;

namespace Entities.States
{
    public class IdleState : IEntityState
    {
        public MovementType MovementType => MovementType.Immobile;
        public Interactivity Interactivity => Interactivity.Active;

        public void EnterState(IEntityStateManager entity)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateState(IEntityStateManager entity)
        {
            throw new System.NotImplementedException();
        }

        public void ExitState(IEntityStateManager entity)
        {
            throw new System.NotImplementedException();
        }
    }
}