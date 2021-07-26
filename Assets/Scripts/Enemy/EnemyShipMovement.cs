using UnityEngine;
using Asteroids.Interface;


namespace Asteroids.Enemy
{
    class EnemyShipMovement : IMove
    {
        public float Speed { get; protected set; }

        private Transform _playerShipTransform;
        private Transform _enemyShipTransform;
        private Vector3 _move;

        public EnemyShipMovement(Transform enemyShipTransform, Transform playerShipTransform, float speed)
        {
            _enemyShipTransform = enemyShipTransform;
            _playerShipTransform = playerShipTransform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            if ((_playerShipTransform.position - _enemyShipTransform.position).sqrMagnitude >= 2.0f)
            {
                var speed = deltaTime * Speed;
                _move.Set(horizontal * speed, vertical * speed, 0.0f);
                _enemyShipTransform.localPosition += _move;
            }
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
