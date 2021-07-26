using Asteroids.Interface;
using Asteroids.ObjectPool;
using Asteroids.Dataset;


namespace Asteroids.Enemy
{
    class EnemyInitializator : IInitialization
    {
        private readonly IEnemiesFactory _enemiesFactory;

        private MainControllers _mainControllers;
        private readonly Data _data;


        public EnemyInitializator(IEnemiesFactory enemiesFactory, MainControllers mainControllers, Data data)
        {
            _enemiesFactory = enemiesFactory;
            _mainControllers = mainControllers;
            _data = data;
        }

        public void Initialization()
        {
            //Создание противника через статический метод
            //EnemyClass.CreateAsteroidEnemy(new Health(40.0f));

            //Создание противника через фабрику
            //_enemiesFactory.Create(new Health(40.0f));

            //Создание противника в PoolObject'е
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
