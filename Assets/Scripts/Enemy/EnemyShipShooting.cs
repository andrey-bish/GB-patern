using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.ObjectPool;


namespace Asteroids.Enemy
{
    class EnemyShipShooting: IShooting
    {
        private readonly DataBullet _dataBullet;

        private Transform _enemyShipTransform;
        private Transform _playerShipTransform;
        private Transform _enemyShipBarrel;

        private float _lastFireTime = 0.0f;
        private float _rangeAttack;


        public EnemyShipShooting(Transform enemyShipTransform, Transform playerShipTransform, DataBullet dataBullet, float rangeAttack)
        {
            _enemyShipTransform = enemyShipTransform;
            _playerShipTransform = playerShipTransform;
            _enemyShipBarrel = _enemyShipTransform.GetChild(0);
            _dataBullet = dataBullet;
            _rangeAttack = rangeAttack;
        }


        public void Shooting()
        {
            if ((_playerShipTransform.position - _enemyShipTransform.position).sqrMagnitude >= _rangeAttack)
            {
                if (_lastFireTime + _dataBullet.FireCooldown < Time.time)
                {
                    _lastFireTime = Time.time;
                    var bullet = BulletObjectPool.GetBullet(_dataBullet.BulletPrefab, _enemyShipBarrel.position, _dataBullet.Damage);
                    bullet.AddForce(_enemyShipBarrel.up * _dataBullet.Force, ForceMode2D.Impulse);
                }
            }
        }

    }
}
