using System;
using Enemies;
using Enemies.Interfaces;
using UnityEngine;

namespace Controllers
{ 
    public class EnemyController : MonoBehaviour
    {
        // Unity components
        private Animator _animator;
        private Rigidbody2D _rigidBody;
        
        // Define modules of the enemy
        private IHealth _health;
        private IMovement _movement;
        private IEnemyState _state;

        private void Awake()
        {
            // Get Unity components
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
            
            // Setup health
            _health = GetComponent<IHealth>();
            _health.Initialize(_animator);

            // Setup movement
            _movement = GetComponent<IMovement>();
            _movement.Initialize(_rigidBody, _animator);
            
            // Setup states
            _state = GetComponent<IEnemyState>();
        }
        
        private void Update()
        {
            Move(Vector2.right);
        }

        public void TakeDamage(float damage)
        {
            _health.Damage(damage);
        }

        public void HealDamage(float amount)
        {
            _health.Heal(amount);
        }

        public void Move(Vector2 direction)
        {
            _movement.Move(direction);
        }
    }
}
