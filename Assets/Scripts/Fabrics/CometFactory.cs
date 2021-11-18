using Asteroids.Interface;
using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Enemy;
using Asteroids.Models;


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
            enemy.SetHealth(health);
            //health.Death += enemy.Death;
            //enemy.EnemyDead += ConcreteMediator.Get().Notify;
            enemy.Score += Interpreter.Get().Scoring;
            _listenerShowMessageDeathEnemy.Add(enemy);
            //Debug.Log(enemy + " подписан");
            new EnemiesSpawn(_dataPlayer).RandomSpawnLocation(enemy);

            return enemy;
        }
    }
}
