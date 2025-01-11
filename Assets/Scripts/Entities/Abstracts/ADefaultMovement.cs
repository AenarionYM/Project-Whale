using System;
using Entities.Interfaces;
using UnityEngine;

namespace Entities.Abstracts
{
    public abstract class ADefaultMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float movementSpeed;
        [SerializeField] private float maxMovementSpeed;
        [SerializeField] private float sprintMultiplier;

        protected Rigidbody2D Rigidbody;
        protected Animator Animator;

        public float SprintMultiplier
        {
            get => sprintMultiplier;
            set => sprintMultiplier = value;
        }

        public float MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = value;
        }

        public float MaxMovementSpeed
        {
            get => maxMovementSpeed;
            set => maxMovementSpeed = value;
        }

        public abstract void MoveInDirection(Vector2 direction);

        public abstract void MoveTo(Vector2 targetPosition, Action onComplete = null);
    }
}