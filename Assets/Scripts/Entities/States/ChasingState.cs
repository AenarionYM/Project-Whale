using Entities.Interfaces;
using Entities.States.Enums;

namespace Entities.States
{
    public class ChasingState : IEntityState
    {
        public MovementType MovementType => MovementType.Sprint;
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