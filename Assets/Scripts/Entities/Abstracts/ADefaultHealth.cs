using Enemies.Abstracts;
using Entities.Interfaces;
using UnityEngine;

namespace Entities.Abstracts
{
    public abstract class ADefaultHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private float currHealth;
        private AnimationController animationController;

        private void Start()
        {
            animationController = GetComponent<AnimationController>();
        }

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
        
        public void Damage(float amount)
        {
            CurrHealth -= amount;
            animationController.TriggerAnimation("TakeDmg");

            if (CurrHealth <= 0f)
            {
                currHealth = 0f;
                animationController.TriggerAnimation("Die");
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