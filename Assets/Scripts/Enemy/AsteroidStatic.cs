using Asteroids.Interface;
using System;
using UnityEngine;

namespace Asteroids.Enemy
{
    public class AsteroidStatic : EnemyClass, IHit
    {
        public event Action<float> OnHitChange = delegate (float f) { };

        private Health _health;

        public void SetHealth(Health health)
        {
            if(Equals(_health, null))
            {
                _health = health;
            }
        }

        public void Damage(float point)
        {
            _health.Damages(point);
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
            Damage(damage);
        }

        
    }
}