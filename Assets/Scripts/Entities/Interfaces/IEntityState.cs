using Entities.States.Enums;

namespace Entities.Interfaces
{
    public interface IEntityState
    {
        public MovementType MovementType { get; }
        public Interactivity Interactivity { get; }
        
        void EnterState(IEntityStateManager entity);
        void UpdateState(IEntityStateManager entity);
        void ExitState(IEntityStateManager entity);
    }
}