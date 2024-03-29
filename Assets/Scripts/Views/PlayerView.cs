﻿using System;
using UnityEngine;
using Asteroids.Interface;
using Asteroids.Enemy;


namespace Asteroids
{
    public class PlayerView : MonoBehaviour, IHit, IPlayer
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

        public Health GetHealth()
        {
            return _health;
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
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }

        private void OnDisable()
        {
            _health.OnDeath -= Death;
        }
    }
}
