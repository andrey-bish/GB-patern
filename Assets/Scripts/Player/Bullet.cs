using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.ObjectPool;


namespace Asteroids
{
    public class Bullet : MonoBehaviour, IInitialization, ICleanup, IAmmunition
    {
        private float _damage;

        public float Damage => _damage;

        private DataEnemies _dataEnemies;
        private ListenerHitShowDamage _listenerHitShowDamage;


        public Bullet(DataEnemies dataEnemies)
        {
            _dataEnemies = dataEnemies;
        }

        public void Initialization()
        {
            //_listenerHitShowDamage = new ListenerHitShowDamage();
            //_listenerHitShowDamage.Add(_dataEnemies.AsteroidPrefab);
            //_listenerHitShowDamage.Add(_dataEnemies.CometPrefab);
        }

        public void Cleanup()
        {
            //_listenerHitShowDamage = new ListenerHitShowDamage();
            //_listenerHitShowDamage.Remove(_dataEnemies.AsteroidPrefab);
            //_listenerHitShowDamage.Remove(_dataEnemies.CometPrefab);
        }

        private void Destroy()
        {
            BulletObjectPool.ReturnToPool(this);
        }

        //прокинуть сюда вместе с созданием буллета - дамаг и в этот метод его положить
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IHit>(out var enemy) || collision.gameObject.CompareTag("Player")) 
            {
                enemy.Hit(_damage);
                Destroy();
            }
        }

        private void OnBecameInvisible()
        {
            Destroy();
        }

        public static Bullet CreateBullet(GameObject gameObject, float damage)
        {
            var bullet = Instantiate(gameObject).AddComponent<Bullet>();
            bullet._damage = damage;
            return bullet;
        }
    }
}
