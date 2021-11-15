using System;
using UnityEngine;

namespace Asteroids.Enemy
{
    public sealed class Health
    {
        public event Action Death;
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
            //Debug.Log("Current HP " + CurrentHP);
            if(CurrentHP <= 0)
            {
                Death?.Invoke();
            }
        }
    }
}
