using System;
using System.Collections.Generic;
using Controllers;
using Entities.States.Enums;

namespace Entities.Interfaces
{
    public interface IEntityStateManager
    {
        // Other entity modules
        public IMovement Movement { get; set; }
        public AnimationController AnimationController { get; set; }
        // Subscriptable event for other scripts
        public event Action<IEntityState> OnStateChange;
        // Dictionary of all states used by entity
        public Dictionary<StateType, IEntityState> States { get; set; }
    }
}