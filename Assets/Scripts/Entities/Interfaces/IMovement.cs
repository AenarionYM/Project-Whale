using UnityEngine;

namespace Entities.Interfaces
{
    public interface IMovement
    {
        float MaxMovementSpeed { get; set; }
        float MovementSpeed { get; set; }
        float SprintMultiplier { get; set; }
        void Initialize(Rigidbody2D entityRigidbody);
        void Walk(Vector2 direction);
        void Sprint(Vector2 direction);
    }
}