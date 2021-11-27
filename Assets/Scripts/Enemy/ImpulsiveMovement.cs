using UnityEngine;
using Asteroids.Interface;


namespace Asteroids.Enemy
{
    class ImpulsiveMovement: IMove
    {
        public float Speed { get; protected set; }

        private IEnemy[] _enemyObjects;
        private Transform _playerShipTransform;

        public ImpulsiveMovement(IEnemy[] enemyShip, Transform playerShipTransform, float speed)
        {
            _enemyObjects = enemyShip;
            _playerShipTransform = playerShipTransform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime) {throw new System.NotImplementedException();}

        public void Move()
        {
            foreach(var enemy in _enemyObjects)
            {
                (enemy as MonoBehaviour).transform.up = _playerShipTransform.transform.position - (enemy as MonoBehaviour).transform.position;
                (enemy as MonoBehaviour).GetComponent<Rigidbody2D>().AddForce((enemy as MonoBehaviour).transform.up * Speed, ForceMode2D.Impulse);
            }
        }
    }
}
