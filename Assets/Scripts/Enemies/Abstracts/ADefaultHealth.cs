using Enemies.FinalEnemies.BasicEnemy;
using Enemies.Interfaces;
using UnityEngine;

namespace Enemies.Abstracts
{
    public abstract class ADefaultHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float currHealth;

        public float MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public float CurrHealth
        {
            get => currHealth;
            set => currHealth = value;
        }
        
        private Animator _animator;

        public void Initialize(Animator animator)
        {
            _animator = animator;
        }

        public void Damage(float amount)
        {
            CurrHealth -= amount;
            _animator.SetTrigger(BasicAnimationHashes.TakeDmg);

            if (CurrHealth <= 0f)
            {
                currHealth = 0f;
                _animator.SetTrigger(BasicAnimationHashes.Die);
            }
        }

        public void Heal(float amount)
        {
            // Prevent overheal
            if (CurrHealth + amount > MaxHealth)
            {
                CurrHealth = MaxHealth;
                return;
            }
            
            CurrHealth += amount;
        }

        public void Death()
        {
            gameObject.SetActive(false);
        }
    }
}