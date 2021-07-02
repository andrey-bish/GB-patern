using UnityEngine;


namespace Asteroids.Enemy
{
    class EnemyShipMove : MoveTransform
    {
        private Transform _playerShipTransform;
        private Transform _enemyShipTransform;

        public EnemyShipMove(Transform enemyShipTransform, Transform playerShipTransform, float speed) : base(enemyShipTransform, speed)
        {
            _enemyShipTransform = enemyShipTransform;
            _playerShipTransform = playerShipTransform;
        }

        public void EnemyShipPursuit(float deltaTime)
        {
            if ((_playerShipTransform.position - _enemyShipTransform.position).sqrMagnitude >= 2.0f)
            {
                Move(_playerShipTransform.position.x - _enemyShipTransform.position.x, _playerShipTransform.position.y - _enemyShipTransform.position.y, deltaTime);
                Debug.Log("If EnemyShipMove");
            }
            else
                Debug.Log("Else EnemyShipMove");
        }

    }
}
