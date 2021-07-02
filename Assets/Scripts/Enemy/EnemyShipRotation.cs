using UnityEngine;
using Asteroids.Interface;

namespace Asteroids.Enemy
{
    internal sealed class EnemyShipRotation : IRotation
    {
        private Transform _enemyShipTransform;

        public EnemyShipRotation(Transform enemyShipTransform)
        {
            _enemyShipTransform = enemyShipTransform;
        }

        public void Rotation(Vector3 direction)
        {
            _enemyShipTransform.up = direction;
            Debug.Log(_enemyShipTransform);
        }

    }
}
