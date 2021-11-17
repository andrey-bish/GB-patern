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

        public void Move(float horizontal, float vertical, float deltaTime) { }

        public void Move()
        {
            foreach(var ss in _enemyObjects)
            {

                (ss as MonoBehaviour).transform.up = _playerShipTransform.transform.position - (ss as MonoBehaviour).transform.position;
                (ss as MonoBehaviour).GetComponent<Rigidbody2D>().AddForce((ss as MonoBehaviour).transform.up * Speed, ForceMode2D.Impulse);
            }
        }
    }
}
