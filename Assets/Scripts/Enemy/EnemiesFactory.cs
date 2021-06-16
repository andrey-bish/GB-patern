using Asteroids.Interface;
using Asteroids.Enemy;
using UnityEngine;
using Asteroids.Dataset;

namespace Asteroids
{
    class EnemiesFactory : IEnemiesFactory
    {
        private DataEnemies _dataEnemies;

        public EnemiesFactory(DataEnemies dataEnemies)
        {
            _dataEnemies = dataEnemies;
        }
        public IEnemy Create()
        {
            return Object.Instantiate(_dataEnemies.AsteroidPref);
        }
    }
}
