using Asteroids.Interface;
using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Enemy;

namespace Asteroids.Fabrics
{
    class AsteroidFactory : IEnemiesFactory
    {
        private readonly DataEnemies _dataEnemies;
        private readonly DataPlayer _dataPlayer;

        public AsteroidFactory(Data data)
        {
            _dataEnemies = data.Enemies;
            _dataPlayer = data.Player;
        }

        public IEnemy Create()
        {
            return Object.Instantiate(_dataEnemies.AsteroidPrefab);
        }

        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemies.AsteroidPrefab);
            enemy.SetHealth(health);
            health.Death += enemy.Death;

            new EnemiesSpawn(_dataPlayer).EnemyFlightDirection(enemy);

            return enemy;
        }
    }
}
