namespace Entities.Interfaces
{
    public interface IEntityState
    {
        void EnterState(IEntityStateManager entity);
        void UpdateState(IEntityStateManager entity);
        void ExitState(IEntityStateManager entity);
    }
}