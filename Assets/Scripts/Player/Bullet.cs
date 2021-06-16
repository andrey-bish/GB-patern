using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids
{
    public class Bullet : MonoBehaviour, IInitialization, ICleanup
    {
        private DataEnemies _dataEnemies;
        private ListenerHitShowDamage _listenerHitShowDamage;

        public Bullet(DataEnemies dataEnemies)
        {
            _dataEnemies = dataEnemies;
        }

        public void Initialization()
        {
            _listenerHitShowDamage = new ListenerHitShowDamage();
            _listenerHitShowDamage.Add(_dataEnemies.AsteroidPref);
        }

        public void Cleanup()
        {
            _listenerHitShowDamage = new ListenerHitShowDamage();
            _listenerHitShowDamage.Remove(_dataEnemies.AsteroidPref);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IHit>(out var enemy))
            {
                enemy.Hit(20.0f);
            }
        }
    }
}
