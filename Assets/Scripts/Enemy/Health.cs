using System;


namespace Asteroids.Enemy
{
    public sealed class Health
    {
        public event Action OnDeath;

        public float Max { get; }
        public float CurrentHP { get; private set; }

        public Health(float max, float current)
        {
            Max = max;
            CurrentHP = current;
        }
        public Health(float current)
        {
            CurrentHP = current;
            Max = current;
        }

        public void SetHp(float? hp = null)
        {
            CurrentHP = hp ?? Max;
        }

        public void Damages(float point)
        {
            CurrentHP -= point;
            if (CurrentHP <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}
