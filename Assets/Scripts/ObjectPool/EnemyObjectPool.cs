using System;
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
        private static readonly Dictionary<string, HashSet<IEnemy>> _enemyCollection = new Dictionary<string, HashSet<IEnemy>>();

        private static Data _data;

       private static IEnemy CreateEnemy(string typeEnemies)
        {
            IEnemy enemy = null;
            switch(typeEnemies)
            {
                case "AsteroidView":
                    Debug.Log("AsteroidView");
                    enemy = new AsteroidFactory(_data).Create(new Enemy.Health(_data.Enemies.Hp));
                    break;
                case "CometView":
                    Debug.Log("CometView");
                    enemy = new CometFactory(_data).Create(new Enemy.Health(_data.Enemies.Hp));
                    break;
                case "EnemyShipView":
                    Debug.Log("EnemyShipView");
                    enemy = new EnemyShipFactory(_data).Create(new Enemy.Health(_data.Enemies.Hp));
                    break;
                default:
                    throw new NullReferenceException("nema");
            }
            return enemy;
        }

        private static HashSet<IEnemy> GetListEnemy(string typeEnemies)
        {
            if (_enemyCollection.ContainsKey(typeEnemies))
                return _enemyCollection[typeEnemies];
            else
                return _enemyCollection[typeEnemies] = new HashSet<IEnemy>();
        }

        public static T GetEnemy<T>(Data data) where T: IEnemy
        {
            _data = data;
            var type = typeof(T).Name;

            var enemy = GetListEnemy(type).FirstOrDefault(x => !(x as MonoBehaviour).gameObject.activeSelf);

            if(enemy == null)
            {
                Debug.Log("Empty enemy. Create new enemy");
                enemy = CreateEnemy(type);
                _enemyCollection[type].Add(enemy);
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
