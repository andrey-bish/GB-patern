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
        public event Action<IEnemy> EnemyDead;
        public event Action<IEnemy> TestEnemyDead;

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
           
            Damage(damage);
            //Destroy();
        }

        private void Destroy()
        {
            TestEnemyDead?.Invoke(this);
            //EnemyDead?.Invoke(this);
            EnemyObjectPool.ReturnToPool(this);
            Score?.Invoke("5990");
        }

        private void OnDisable()
        {
            new ListenerShowMessageDeathEnemy().Remove(this);
            //_health.Death -= Death;
        }
    }
}
