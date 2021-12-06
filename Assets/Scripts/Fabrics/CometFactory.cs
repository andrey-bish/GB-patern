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
        private readonly ListenerShowMessageDeathEnemy _listenerShowMessageDeathEnemy;

        public CometFactory(Data data, ListenerShowMessageDeathEnemy listenerShowMessageDeathEnemy)
        {
            _dataEnemies = data.Enemies;
            _dataPlayer = data.Player;
            _listenerShowMessageDeathEnemy = listenerShowMessageDeathEnemy;
        }

        public IEnemy Create()
        {
            return Object.Instantiate(_dataEnemies.CometPrefab);
        }

        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemies.CometPrefab);
            ManipulationWithEnemy(enemy, health);
            return enemy;
        }

        private void ManipulationWithEnemy(CometView enemy, Health health)
        {
            enemy.SetHealth(health);
            enemy.KillPoint = _dataEnemies.CometKillPoint;
            health.OnDeath += enemy.Death;
            _listenerShowMessageDeathEnemy.Add(enemy);
            new EnemiesSpawn(_dataPlayer).RandomSpawnLocation(enemy);
        }
    }
}
