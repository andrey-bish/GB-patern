using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Enemy
{
    class EnemyShipMovement : IMove
    {
        public float Speed { get; protected set; }

        private Transform _playerShipTransform;
        private Transform _enemyShipTransform;

        private Vector3 _move;

        private float _rangeAttack;

        public EnemyShipMovement(Transform enemyShipTransform, Transform playerShipTransform, Data data)
        {
            _enemyShipTransform = enemyShipTransform;
            _playerShipTransform = playerShipTransform;
            Speed = data.Enemies.Speed;
            _rangeAttack = data.Enemies.RangeAtack;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            if ((_playerShipTransform.position - _enemyShipTransform.position).sqrMagnitude >= _rangeAttack)
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
