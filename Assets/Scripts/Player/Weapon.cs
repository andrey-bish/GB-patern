using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.ObjectPool;


namespace Asteroids
{
    class Weapon : MonoBehaviour, IWeapon
    {
        private readonly LineRenderer _playerLineRenderer;
        private readonly AudioSource _audioSource;

        private DataWeapon _dataWeapon;
        private Transform _barrelPlayer;
        private Material _viewLaserAim;

        private float _damage;
        private float _lastFireTime = 0.0f;
        private float _shotVolume;

        private bool _isWeaponLocked; 

        public Weapon(Data data, Transform playerTransform)
        {
            _audioSource = playerTransform.GetComponent<AudioSource>();
            _dataWeapon = data.Weapon;
            _barrelPlayer = playerTransform.Find("Barrel");
            _audioSource.clip = data.Weapon.OneShotAudioClip;
            _audioSource.volume = data.Weapon.DefaultShotVolume;
            _damage = data.Weapon.Damage;
            _shotVolume = data.Weapon.DefaultShotVolume;
            _viewLaserAim = data.Weapon.RedLaserAim;
            _playerLineRenderer = playerTransform.GetComponent<LineRenderer>();
            _isWeaponLocked = data.Weapon.IsWeaponLocked;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPlayer = barrelPosition;
        }

        public void SetDamage(float damage)
        {
            _damage = damage;
        }

        public void SetShotVolume(float shotVolume)
        {
            _shotVolume = shotVolume;
        }

        public void SetAimLaser(Material aimLaserMaterial)
        {
            _viewLaserAim = aimLaserMaterial;
            _playerLineRenderer.material = _viewLaserAim;
        }

        public void SetWeaponLocked(bool isWeaponLocked)
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
                    _audioSource.volume = _shotVolume;
                    _audioSource.PlayOneShot(_audioSource.clip);
                    _lastFireTime = Time.time;
                    var bullet = BulletObjectPool.GetBullet(_dataWeapon.BulletPrefab, _barrelPlayer.position, _damage);
                    bullet.AddForce(_barrelPlayer.up * _dataWeapon.Force, ForceMode2D.Impulse);
                }
            }
        }

        
    }
}
