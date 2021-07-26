using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Enemy
{
    class EnemyActionController : IInitialization, IFixUpdateble
    {
        #region Fields

        private readonly MainControllers _mainControllers;
        private readonly Data _data;

        private EnemyController _enemyController;

        private Transform _enemyShipTranform;
        private Transform _playerShipTranform;

        #endregion


        #region Constructor

        public EnemyActionController(MainControllers mainControllers, Data data)
        {
            _mainControllers = mainControllers;
            _mainControllers.Add(this);
            _data = data;
        }

        #endregion


        #region Initialization

        public void Initialization()
        {
            _playerShipTranform = GameObject.FindGameObjectWithTag("Player").transform;

            var asteroid = GameObject.FindObjectOfType<AsteroidView>().transform;
            var comet = GameObject.FindObjectOfType<CometView>().transform;
            _enemyShipTranform = GameObject.FindObjectOfType<EnemyShipView>().transform;

            new EnemyController(new ImpulsiveMovement(asteroid.transform, _playerShipTranform, _data.Enemies.ImpulseStrenge)).Move();
            new EnemyController(new ImpulsiveMovement(comet.transform, _playerShipTranform, _data.Enemies.ImpulseStrenge)).Move();

            _enemyController = new EnemyController(new EnemyShipMovement(_enemyShipTranform, _playerShipTranform, _data.Enemies.Speed), new EnemyShipRotation(_enemyShipTranform),
                new EnemyShipShooting(_enemyShipTranform, _playerShipTranform, _data.Bullet));
        }

        #endregion


        #region FixUpdateble

        public void FixUpdateble(float deltaTime)
        {
            _playerShipTranform = GameObject.FindGameObjectWithTag("Player").transform;

            if (_enemyShipTranform.gameObject.activeSelf)
            {
                _enemyController.Move(_playerShipTranform.position.x - _enemyShipTranform.position.x, _playerShipTranform.position.y - _enemyShipTranform.position.y, deltaTime);
                _enemyController.Rotation(_playerShipTranform.position - _enemyShipTranform.position);
                _enemyController.Shooting();
            }
        }

        #endregion
    }
}
