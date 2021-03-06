using UnityEngine;
using Asteroids.Interface;
using System;
using Asteroids.Enemy;


namespace Asteroids
{
    public class PlayerView : MonoBehaviour, IHit
    {
        public event Action<float> OnHitChange = delegate (float f) { };

        private Health _health;

        public void SetHealth(Health health)
        {
            if (_health == null)
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
            Destroy();
        }

        public void Hit(float damage)
        {
            OnHitChange.Invoke(damage);
            Damage(damage);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
