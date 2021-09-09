using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.ObjectPool;


namespace Asteroids
{
    class Weapon : IWeapon
    {
        private readonly LineRenderer _playerLineRenderer;
        private readonly AudioSource _audioSource;

        private DataWeapon _dataWeapon;
        private Transform _barrelPlayer;
        private AudioClip _audioClip;
        private Material _viewLaserAim;

        private float _damage;
        private float _lastFireTime = 0.0f;

        private bool _isWeaponLocked; 

        public Weapon(Data data, Transform playerTransform)
        {
            _dataWeapon = data.Weapon;
            _barrelPlayer = playerTransform.Find("Barrel");
            _audioSource = data.Weapon.AudioSourcePlayer;
            _audioClip = data.Weapon.OneShotAudioClip;
            _damage = data.Weapon.Damage;
            _viewLaserAim = data.Weapon.RedLaserAim;
            _playerLineRenderer = playerTransform.GetComponent<LineRenderer>();
            _isWeaponLocked = data.Weapon.IsWeaponLocked;
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

        public void SetAimLaser(Material aimLaserMaterial)
        {
            _viewLaserAim = aimLaserMaterial;
            _playerLineRenderer.material = _viewLaserAim;
        }

        public void SetWeaponLockeD(bool isWeaponLocked)
        {
            _isWeaponLocked = isWeaponLocked;
        }

        public void Shooting()
        {
            if (_isWeaponLocked)
            {
                Debug.Log("Weapon locked!");
            }
            else
            {
                if (_lastFireTime + _dataWeapon.FireCooldown < Time.time)
                {
                    _lastFireTime = Time.time;
                    var bullet = BulletObjectPool.GetBullet(_dataWeapon.BulletPrefab, _barrelPlayer.position, _damage);
                    bullet.AddForce(_barrelPlayer.up * _dataWeapon.Force, ForceMode2D.Impulse);
                    _audioSource.PlayOneShot(_audioClip);
                }
            }
        }
    }
}
