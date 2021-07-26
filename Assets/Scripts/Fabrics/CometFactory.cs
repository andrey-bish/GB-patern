using Asteroids.Interface;
using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Enemy;

namespace Asteroids.Fabrics
{
    class CometFactory : IEnemiesFactory
    {
        private readonly DataEnemies _dataEnemies;
        private readonly DataPlayer _dataPlayer;

        public CometFactory(Data data)
        {
            _dataEnemies = data.Enemies;
            _dataPlayer = data.Player;
        }

        public IEnemy Create()
        {
            return Object.Instantiate(_dataEnemies.CometPrefab);
        }

        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemies.CometPrefab);
            enemy.SetHealth(health);
            health.Death += enemy.Death;

            new EnemiesSpawn(_dataPlayer).RandomSpawnLocation(enemy);

            return enemy;
        }
    }
}
