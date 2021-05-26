using UnityEngine;
using Asteroids.Interface;
using System;

namespace Asteroids.Enemy
{
    public class Meteors : MonoBehaviour, IHit
    {
        public float Hp;

        public event Action<float> OnHitChange = delegate(float f) { };

        public void Hit(float damage)
        {
            Debug.Log($"Damage {damage}");
            OnHitChange.Invoke(damage);


            Hp -= damage;
            if(Hp <= 0)
            {
                Destroy(gameObject);
            }
        }


        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.TryGetComponent<IDamageble>(out var damageble))
        //    {
        //        damageble.Damage(5.0f);
        //    }
        //}
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
            
        //}
    }
}