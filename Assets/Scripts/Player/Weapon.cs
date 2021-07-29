using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.ObjectPool;


namespace Asteroids
{
    class Weapon : IWeapon
    {
        private DataBullet _dataBullet;
        private Transform _barrelPlayer;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;

        private float _damage;

        private float _lastFireTime = 0.0f;

        public Weapon(Data data, Transform playerTransform)
        {
            _dataBullet = data.Bullet;
            _barrelPlayer = playerTransform.Find("Barrel");
            _audioSource = data.Bullet.AudioSourcePlayer;
            _audioClip = data.Bullet.OneShotAudioClip;
            _damage = data.Bullet.Damage;
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
            _damage = damage;
        }

        public void Shooting()
        {
            if (_lastFireTime + _dataBullet.FireCooldown < Time.time)
            {
                _lastFireTime = Time.time;
                var bullet = BulletObjectPool.GetBullet(_dataBullet.BulletPrefab, _barrelPlayer.position, _damage);
                bullet.AddForce(_barrelPlayer.up * _dataBullet.Force, ForceMode2D.Impulse);
                _audioSource.PlayOneShot(_audioClip);
            }
        }

    }
}
