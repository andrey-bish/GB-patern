using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.ObjectPool;

namespace Asteroids
{
    class Weapon : IShooting
    {
        private DataBullet _dataBullet;
        private Transform _barrelPlayer;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;

        private float _lastFireTime = 0.0f;

        public Weapon(Data data, Transform playerTransform)
        {
            _dataBullet = data.Bullet;
            _barrelPlayer = playerTransform.Find("Barrel");
            _audioSource = data.Bullet.AudioSourcePlayer;
            _audioClip = data.Bullet.OneShotAudioClip;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPlayer = barrelPosition;
        }

        public void SetDamage(float damage)
        {
            _dataBullet.Damage = damage;
        }

        public void DefaultBarrelPosition(Transform barrelPosition)
        {
            _barrelPlayer = barrelPosition;
        }

        public void DefaultAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public void DefaultDamage(float damage)
        {
            _dataBullet.Damage = damage;
        }

        public void Shooting()
        {
            if (_lastFireTime + _dataBullet.FireCooldown < Time.time)
            {
                _lastFireTime = Time.time;
                var bullet = BulletObjectPool.GetBullet(_dataBullet.BulletPrefab, _barrelPlayer.position, _dataBullet.Damage);
                bullet.AddForce(_barrelPlayer.up * _dataBullet.Force, ForceMode2D.Impulse);
                _audioSource.PlayOneShot(_audioClip);
            }
        }
    }
}
