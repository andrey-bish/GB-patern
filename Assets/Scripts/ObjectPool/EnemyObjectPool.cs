﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Asteroids.Interface;
using Asteroids.Fabrics;
using Asteroids.Dataset;


namespace Asteroids.ObjectPool
{
    class EnemyObjectPool
    {
        public static readonly Dictionary<string, HashSet<IEnemy>> _enemyCollection = new Dictionary<string, HashSet<IEnemy>>();

        private static Data _data;

       private static IEnemy CreateEnemy(string typeEnemies)
        {
            IEnemy enemy = null;
            switch(typeEnemies)
            {
                case "AsteroidView":
                    enemy = new AsteroidFactory(_data).Create(new Enemy.Health(_data.Enemies.Hp));
                    break;
                case "CometView":
                    enemy = new CometFactory(_data).Create(new Enemy.Health(_data.Enemies.Hp));
                    break;
                case "EnemyShipView":
                    enemy = new EnemyShipFactory(_data).Create(new Enemy.Health(_data.Enemies.Hp));
                    break;
                default:
                    throw new NullReferenceException("The specified enemy type was not found.");
            }
            return enemy;
        }

        private static HashSet<IEnemy> GetListEnemy(string typeEnemies)
        {
            if (_enemyCollection.ContainsKey(typeEnemies))
            {   
                Debug.Log(_enemyCollection[typeEnemies]);
                return _enemyCollection[typeEnemies];
            }
                
            else
                return _enemyCollection[typeEnemies] = new HashSet<IEnemy>();
                
        }

        public static T GetEnemy<T>(Data data) where T: IEnemy
        {
            _data = data;
            var type = typeof(T).Name;
            var list = GetListEnemy(type);

            var enemy = list.FirstOrDefault(x => !(x as MonoBehaviour).gameObject.activeSelf);
            if (enemy == null)
            {
                enemy = CreateEnemy(type);
                list.Add(enemy);
            }
            else
            {
                Debug.Log("Return enemy");
                
            }
            (enemy as MonoBehaviour).gameObject.SetActive(true);
            return (T)enemy;
        }

        public static void ReturnToPool(IEnemy enemy)
        {
            var go = (enemy as MonoBehaviour).gameObject;
            go.SetActive(false);
        }
    }
}
