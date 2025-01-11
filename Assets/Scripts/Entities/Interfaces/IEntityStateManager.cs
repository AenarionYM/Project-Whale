using System;
using Enemies.Abstracts;

namespace Entities.Interfaces
{
    public interface IEntityStateManager
    {
        public IMovement Movement { get; set; }
        public AnimationController AnimationController { get; set; }
        public event Action<IEntityState> OnStateChanged;
    }
}