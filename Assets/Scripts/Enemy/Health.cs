using System;
using UnityEngine;

namespace Asteroids.Enemy
{
    public sealed class Health
    {
        public event Action Death;
        public float Max { get; }
        public float Current { get; private set; }

        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }
        public Health(float current)
        {
            Current = current;
        }

        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }

        public void Damages(float point)
        {
            Current -= point;
            Debug.Log("Current HP " + Current);
            if(Current <= 0)
            {
                Death?.Invoke();
            }
        }
    }
}
