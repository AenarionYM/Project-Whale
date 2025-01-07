using System;
using Enemies;
using Entities.Interfaces;
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
        private IEntityStateManager stateManager;

        private void Awake()
        {
            // Get Unity components
            _rigidBody = GetComponent<Rigidbody2D>();
            
            // Setup health
            _health = GetComponent<IHealth>();

            // Setup movement
            _movement = GetComponent<IMovement>();
            _movement.Initialize(_rigidBody);
            
            // Setup states
            stateManager = GetComponent<IEntityStateManager>();
        }
        
        private void Update()
        {
        }

        public void TakeDamage(float damage)
        {
            _health.Damage(damage);
        }

        public void HealDamage(float amount)
        {
            _health.Heal(amount);
        }
    }
}
