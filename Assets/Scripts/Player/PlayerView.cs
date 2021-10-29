using UnityEngine;
using Asteroids.Interface;
using System;
using Asteroids.Enemy;
using Asteroids.Dataset;


namespace Asteroids
{
    public class PlayerView : MonoBehaviour, IHit, IPlayer
    {
        public event Action<float> OnHitChange = delegate (float f) { };

        [SerializeField] private AudioSource _audioSource;

        private DataWeapon _dataWeapon;
        private Health _health;

        private void Start()
        {
            //_audioSource = GetComponent<AudioSource>();
            //_dataWeapon.AudioSourcePlayer = _audioSource;
        }

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
