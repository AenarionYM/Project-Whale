using Controllers;
using Entities.Abstracts;
using Entities.States.Enums;

namespace Entities.FinalEnemies.BasicEnemy
{
    public class BasicHealth : ADefaultHealth
    {
        private AnimationController animationController;
        private BasicEnemyStateManager stateManager;

        private void Start()
        {
            animationController = GetComponent<AnimationController>();
            stateManager = GetComponent<BasicEnemyStateManager>();
        }

        public override void Damage(float amount)
        {
            CurrHealth -= amount;
            animationController.TriggerAnimation("TakeDmg");

            if (CurrHealth <= 0f)
            {
                currHealth = 0f;
                animationController.TriggerAnimation("Die");
            }
        }

        public override void Heal(float amount)
        {
            // Prevent overheal
            if (CurrHealth + amount > MaxHealth)
            {
                CurrHealth = MaxHealth;
                return;
            }

            CurrHealth += amount;
        }

        public override void Death()
        {
            stateManager.TransitionToState(stateManager.States[StateType.Dying]);
            gameObject.SetActive(false);
        }
    }
}