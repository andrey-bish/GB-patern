using UnityEngine;
using Asteroids.Enemy;
using Asteroids.Interface;

namespace Asteroids.Scripts
{
    public class Bullet : MonoBehaviour
    {
        //public float Damage = 20.0f;
        public Meteors Meteors;
        public Asteroid Asteroid;

        private void Start()
        {
            var listenerHitShowDamage = new ListenerHitShowDamage();
            listenerHitShowDamage.Add(Meteors);
            listenerHitShowDamage.Add(Asteroid);
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
