using System;
using UnityEngine;

namespace Entities.Interfaces
{
    public interface IMovement
    {
        float MaxMovementSpeed { get; set; }
        float MovementSpeed { get; set; }
        float SprintMultiplier { get; set; }
        void Initialize(Rigidbody2D entityRigidbody);
        void MoveInDirection(Vector2 direction);
        void MoveTo(Vector2 targetPosition, Action onComplete = null);
    }
}