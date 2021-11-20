using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Asteroids.Interface;
using Asteroids.Fabrics;
using Asteroids.Dataset;
using Asteroids.Enemy;


namespace Asteroids.ObjectPool
{
    class EnemyObjectPool
    {
        public static readonly Dictionary<string, HashSet<IEnemy>> _enemyCollection = new Dictionary<string, HashSet<IEnemy>>();

        private static Data _data;

        public static ListenerShowMessageDeathEnemy _listenerHitShowDamage;

       private static IEnemy CreateEnemy(string typeEnemies)
        {
            IEnemy enemy = null;
            switch (typeEnemies)
            {
                case "AsteroidView":
                    //if(!isCreated)
                    //enemy = new AsteroidFactory(_data, _listenerHitShowDamage).Create(new Health(_data.Enemies.Hp));
                    //else
                    //enemy = new AsteroidFactory(_data, _listenerHitShowDamage).ManipulationWithEnemy(, new Health(_data.Enemies.Hp));
                    enemy = new AsteroidFactory(_data, _listenerHitShowDamage).Create(new Health(_data.Enemies.Hp));
                    break;
                case "CometView":
                    enemy = new CometFactory(_data, _listenerHitShowDamage).Create(new Health(_data.Enemies.Hp));
                    break;
                case "EnemyShipView":
                    enemy = new EnemyShipFactory(_data, _listenerHitShowDamage).Create(new Health(_data.Enemies.Hp));
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
                Debug.Log("Added enemy: " + enemy);
                list.Add(enemy);
            }
            else
            {
                //подписка на Observer
                //выдать хп
                _listenerHitShowDamage.Add(enemy);
                enemy.Recreate();
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
