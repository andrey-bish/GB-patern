using Asteroids.Interface;
using Asteroids.ObjectPool;
using Asteroids.Dataset;
using UnityEngine;

namespace Asteroids.Enemy
{
    //Можно переименовать в enemycontroller
    class EnemyInitializator : MoveTransform, IInitialization, IUpdateble, IFixUpdateble
    {

        #region Fields

        private readonly IEnemiesFactory _enemiesFactory;
        private readonly Data _data;
        private Transform _enemyShipPosition;
        private Transform _playerShipTranform;
        private EnemyShipView _enemyShip;
        private EnemyShipMove _enemyShipMove;
        private EnemyShipRotation _enemyShipRotation;
        private EnemyShipShooting _enemyShipShooting;
        private readonly float _speed;

        #endregion


        public EnemyInitializator(IEnemiesFactory enemiesFactory, Data data, float speed, Transform enemyShipPosition) : base(enemyShipPosition, speed)
        {
            _enemiesFactory = enemiesFactory;
            _data = data;
            _speed = speed;
            _enemyShipPosition = enemyShipPosition;
            _playerShipTranform = _data.Player.PlayerPrefab.transform;
        }
        public void Initialization()
        {
            //Создание противника через статический метод
            //EnemyClass.CreateAsteroidEnemy(new Health(40.0f));

            //Создание противника через фабрику
            //_enemiesFactory.Create(new Health(40.0f));

            //Создание противника в PoolObject'е
            EnemyObjectPool.GetEnemy<AsteroidView>(_data);
            EnemyObjectPool.GetEnemy<CometView>(_data);
            var enemy = EnemyObjectPool.GetEnemy<EnemyShipView>(_data);

            var playerShip = GameObject.FindGameObjectWithTag("Player");

            _enemyShip = enemy;
            _enemyShipMove = new EnemyShipMove(_enemyShip.transform, playerShip.transform, _speed);
            _enemyShipRotation = new EnemyShipRotation(_enemyShip.transform);
            new Ship(_enemyShipMove, _enemyShipRotation);
            _enemyShipShooting = new EnemyShipShooting(_enemyShip.transform, playerShip.transform, _data.Bullet);
        }

        public void Updateble(float deltaTime)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                EnemyObjectPool.GetEnemy<AsteroidView>(_data);
            }
        }

        public void FixUpdateble(float deltaTime)
        {
            var currectPlayerShipPosition = GameObject.FindGameObjectWithTag("Player");
            
            if(_enemyShip.gameObject.activeSelf)
            {
                _enemyShipMove.EnemyShipPursuit(deltaTime);
                _enemyShipRotation.Rotation(currectPlayerShipPosition.transform.position - _enemyShip.transform.position);
                _enemyShipShooting.Shooting();
            }
        }
    }
}
