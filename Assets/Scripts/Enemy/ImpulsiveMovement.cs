using UnityEngine;
using Asteroids.Interface;


namespace Asteroids.Enemy
{
    class ImpulsiveMovement: IMove
    {
        public float Speed { get; protected set; }

        private Transform _enemyShipTransform;
        private Transform _playerShipTransform;

        public ImpulsiveMovement(Transform enemyShipTransform, Transform playerShipTransform, float speed)
        {
            _enemyShipTransform = enemyShipTransform;
            _playerShipTransform = playerShipTransform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime) { }

        public void Move()
        {
            _enemyShipTransform.transform.up = _playerShipTransform.transform.position - _enemyShipTransform.transform.position;
            _enemyShipTransform.GetComponent<Rigidbody2D>().AddForce(_enemyShipTransform.transform.up * Speed, ForceMode2D.Impulse);
        }
    }
}
