using Asteroids.Interface;
using Asteroids.ObjectPool;
using Asteroids.Dataset;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;


namespace Asteroids.Enemy
{
    class EnemyInitializator : IInitialization, IUpdateble
    {
        private MainControllers _mainControllers;
        private readonly Data _data;


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
            Debug.Log(string.Join("\n", EnemyObjectPool._enemyCollection.Select(o=> $"{o.Key}-{o.Value}")));
            
        }

        private void CreateEnemiesAndAddToObjectPool()
        {
            EnemyObjectPool.GetEnemy<AsteroidView>(_data);
            EnemyObjectPool.GetEnemy<CometView>(_data);
            EnemyObjectPool.GetEnemy<EnemyShipView>(_data);
        }

        public void Updateble(float deltaTime)
        {
        }
    }
}
