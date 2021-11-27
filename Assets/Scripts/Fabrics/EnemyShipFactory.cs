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
        private readonly ListenerShowMessageDeathEnemy _listenerShowMessageDeathEnemy;

        public EnemyShipFactory(Data data, ListenerShowMessageDeathEnemy listenerShowMessageDeathEnemy)
        {
            _dataEnemies = data.Enemies;
            _dataPlayer = data.Player;
            _listenerShowMessageDeathEnemy = listenerShowMessageDeathEnemy;
        }

        public IEnemy Create(Health health)
        {
            var enemy = Object.Instantiate(_dataEnemies.EnemyShipPrefab);
            ManipulationWithEnemy(enemy, health);
            return enemy;
        }

        private void ManipulationWithEnemy(EnemyShipView enemy, Health health)
        {
            enemy.SetHealth(health);
            enemy.KillPoint = _dataEnemies.EnemyShipKillPoint;
            health.OnDeath += enemy.Death;
            _listenerShowMessageDeathEnemy.Add(enemy);
            new EnemiesSpawn(_dataPlayer).RandomSpawnLocation(enemy);
        }
    }
}
