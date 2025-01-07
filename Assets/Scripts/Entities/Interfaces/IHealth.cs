namespace Entities.Interfaces
{
    public interface IHealth
    {
        public float MaxHealth { get; set; }
        public float CurrHealth { get; set; }
        public void Damage(float amount);
        public void Heal(float amount);
        public void Death();
    }
}