using UnityEngine;
using Assets.Scripts.Enemy;
using Assets.Scripts.Interface;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        //public float Damage = 20.0f;
        public Meteors meteors;
        private void Start()
        {
            var listenerHitShowDamage = new ListenerHitShowDamage();
            listenerHitShowDamage.Add(meteors);
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IHit>(out var enemy))
            {
                Debug.Log("damage");
                enemy.Hit(20.0f);
            }
        }
        //public void OnTriggerEnter2D(Collider2D col)
        //{
            
        //}
    }
}
