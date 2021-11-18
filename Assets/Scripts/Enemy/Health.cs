using System;
using Asteroids.Interface;

namespace Asteroids.Enemy
{
    public sealed class Health: IDeath
    {
        public event Action OnDeathChange;
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
        }

        public void ChangeCurrentHealth(float hp)
        {
            CurrentHP = hp;
        }

        public void Damages(float point)
        {
            CurrentHP -= point;
            if(CurrentHP <= 0)
            {
                OnDeathChange?.Invoke();
            }
        }
    }
}
