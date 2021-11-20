using Asteroids.Interface;
using Asteroids.ObjectPool;
using Asteroids.Dataset;


namespace Asteroids.Enemy
{
    class EnemyInitializator : IInitialization
    {
        private readonly Data _data;

        private MainControllers _mainControllers;


        public EnemyInitializator( MainControllers mainControllers, Data data)
        {
            _mainControllers = mainControllers;
            _data = data;
        }

        public void Initialization()
        {
            EnemyObjectPool._listenerHitShowDamage = new ListenerShowMessageDeathEnemy();
            CreateEnemiesAndAddToObjectPool();
            new EnemyActionController(_mainControllers, _data);
        }

        private void CreateEnemiesAndAddToObjectPool()
        {
            EnemyObjectPool.GetEnemy<AsteroidView>(_data);
            EnemyObjectPool.GetEnemy<CometView>(_data);
            EnemyObjectPool.GetEnemy<EnemyShipView>(_data);
        }
    }
}
