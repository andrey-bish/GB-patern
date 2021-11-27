using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.Enemy;


namespace Asteroids.Fabrics
{
    class AsteroidFactory : IEnemiesFactory
    {
        private readonly DataEnemies _dataEnemies;
        private readonly DataPlayer _dataPlayer;
        private readonly ListenerShowMessageDeathEnemy _listenerShowMessageDeathEnemy;

        public AsteroidFactory(Data data, ListenerShowMessageDeathEnemy listenerShowMessageDeathEnemy)
        {
            _dataEnemies = data.Enemies;
            _dataPlayer = data.Player;
            _listenerShowMessageDeathEnemy = listenerShowMessageDeathEnemy;
        }

        public IEnemy Create()
        {
            return Object.Instantiate(_dataEnemies.AsteroidPrefab);
        }

        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemies.AsteroidPrefab);
            ManipulationWithEnemy(enemy, health);
            return enemy;
        }

        private void ManipulationWithEnemy(AsteroidView enemy, Health health)
        {
            enemy.SetHealth(health);
            enemy.KillPoint = _dataEnemies.AsteroidKillPoint;
            health.OnDeath += enemy.Death;
            _listenerShowMessageDeathEnemy.Add(enemy);
            new EnemiesSpawn(_dataPlayer).RandomSpawnLocation(enemy);
        }
    }
}
