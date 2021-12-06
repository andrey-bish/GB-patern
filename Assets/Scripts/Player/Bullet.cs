using UnityEngine;
using Asteroids.Interface;
using Asteroids.ObjectPool;


namespace Asteroids
{
    public class Bullet : MonoBehaviour, IAmmunition
    {
        private float _damage;

        public static Bullet CreateBullet(GameObject gameObject, float damage)
        {
            var bullet = Instantiate(gameObject).AddComponent<Bullet>();
            bullet._damage = damage;
            return bullet;
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IHit>(out var hitObject)) 
            {
                hitObject.Hit(_damage);
                Destroy();
            }
        }

        private void OnBecameInvisible()
        {
            Destroy();
        }

        private void Destroy()
        {
            BulletObjectPool.ReturnToPool(this);
        }

    }
}
