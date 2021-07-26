using Asteroids.Interface;
using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Enemy;

namespace Asteroids.Fabrics
{
    class EnemyShipFactory : IEnemiesFactory
    {
        private readonly DataEnemies _dataEnemies;
        private readonly DataPlayer _dataPlayer;

        public EnemyShipFactory(Data data)
        {
            _dataEnemies = data.Enemies;
            _dataPlayer = data.Player;
        }

        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemies.EnemyShipPrefab);
            enemy.SetHealth(health);
            health.Death += enemy.Death;

            new EnemiesSpawn(_dataPlayer).RandomSpawnLocation(enemy);

            return enemy;
        }
    }
}
