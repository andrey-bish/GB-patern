using UnityEngine;
using Asteroids.Interface;
using Asteroids.ObjectPool;
using System;

namespace Asteroids.Enemy
{
    public class CometView : MonoBehaviour, IEnemy, IHit
    {
        public event Action<float> OnHitChange = delegate (float f) { };
        public event Action<string> Score;

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
            //Destroy();
        }

        private void Destroy()
        {
            EnemyObjectPool.ReturnToPool(this);
            Score?.Invoke("5990");
        }
    }
}
