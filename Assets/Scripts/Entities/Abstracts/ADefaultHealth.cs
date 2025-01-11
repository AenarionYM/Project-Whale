using Entities.Interfaces;
using UnityEngine;

namespace Entities.Abstracts
{
    public abstract class ADefaultHealth : MonoBehaviour, IHealth
    {
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float currHealth;

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

        public abstract void Damage(float amount);

        public abstract void Heal(float amount);

        public abstract void Death();
    }
}