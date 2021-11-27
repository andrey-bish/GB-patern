using Asteroids.Interface;
using UnityEngine;


namespace Asteroids.Enemy
{
    class EnemyController : IMove, IRotation, IShooting
    {
        private IMove _move;
        private IRotation _rotation;
        private IShooting _shooting;

        public float Speed => _move.Speed;

        public EnemyController(IMove move, IRotation rotation, IShooting shooting)
        {
            _move = move;
            _rotation = rotation;
            _shooting = shooting;
        }

        public EnemyController(IMove move)
        {
            _move = move;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _move.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotation.Rotation(direction);
        }

        public void Shooting()
        {
            _shooting.Shooting();
        }

        public void Move()
        {
            _move.Move();
        }
    }
}
